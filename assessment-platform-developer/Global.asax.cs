﻿using SimpleInjector;
using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector.Diagnostics;
using System.Web.Compilation;
using System.Web.UI;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using SimpleInjector.Integration.Web;
using assessment_platform_developer.Infrastructure.Interfaces.Mediator;
using assessment_platform_developer.Infrastructure.Implementations.Mediator;
using assessment_platform_developer.Infrastructure.Interfaces.Customers;
using assessment_platform_developer.Infrastructure.Implementations.Customers;

namespace assessment_platform_developer
{
    public sealed class PageInitializerModule : IHttpModule
	{
		public static void Initialize()
		{
            DynamicModuleUtility.RegisterModule(typeof(PageInitializerModule));
		}

		void IHttpModule.Init(HttpApplication app)
		{
			app.PreRequestHandlerExecute += (sender, e) =>
			{
				var handler = app.Context.CurrentHandler;
				if (handler != null)
				{
					string name = handler.GetType().Assembly.FullName;
					if (!name.StartsWith("System.Web") &&
						!name.StartsWith("Microsoft"))
					{
						Global.InitializeHandler(handler);
					}
				}
			};
		}

		void IHttpModule.Dispose() { }
	}

	public class Global : HttpApplication
	{
		private static Container container;

		public static void InitializeHandler(IHttpHandler handler)
		{
			var handlerType = handler is Page
				? handler.GetType().BaseType
				: handler.GetType();
			container.GetRegistration(handlerType, true).Registration
				.InitializeInstance(handler);
		}

		void Application_Start(object sender, EventArgs e)
		{

			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);


			Bootstrap();
		}

		private static void Bootstrap()
		{
			// 1. Create a new Simple Injector container.
			var container = new Container();

			container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

			// 2. Configure the container (register)
			container.Register<IMediator>(() => new MediatorService(container));
			container.Register<ICustomerCommandRepository, CustomerCommandRepository>(Lifestyle.Scoped);
			container.Register<ICustomerQueryRepository, CustomerQueryRepository>(Lifestyle.Scoped);
            container.Register(typeof(IMessageHandler<,>), new[] { 
				typeof(IMessageHandler<,>).Assembly,
                Assembly.Load("assessment-platform-developer.Application")
        });

            // Register your Page classes to allow them to be verified and diagnosed.
            RegisterWebPages(container);
			container.Options.ResolveUnregisteredConcreteTypes = true;

			// 3. Store the container for use by Page classes.
			Global.container = container;
			// 3. Verify the container's configuration.
			container.Verify();

			HttpContext.Current.Application["DIContainer"] = container;
		}

		private static void RegisterWebPages(Container container)
		{
			var pageTypes =
				from assembly in BuildManager.GetReferencedAssemblies().Cast<Assembly>()
				where !assembly.IsDynamic
				where !assembly.GlobalAssemblyCache
				from type in assembly.GetExportedTypes()
				where type.IsSubclassOf(typeof(Page))
				where !type.IsAbstract && !type.IsGenericType
				select type;

			foreach (var type in pageTypes)
			{
				var reg = Lifestyle.Transient.CreateRegistration(type, container);
				reg.SuppressDiagnosticWarning(
					DiagnosticType.DisposableTransientComponent,
					"ASP.NET creates and disposes page classes for us.");
				container.AddRegistration(type, reg);
			}
		}

	}
}