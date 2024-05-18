using assessment_platform_developer.Infrastructure.Interfaces.Mediator;
using System;
using System.Threading.Tasks;

namespace assessment_platform_developer.Infrastructure.Implementations.Mediator
{
    public class MediatorService : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public MediatorService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResult> Send<TResult>(IMessage<TResult> command) where TResult : IMessageResult
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var commandHandlerType = typeof(IMessageHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = _serviceProvider.GetService(commandHandlerType);

            return (Task<TResult>)commandHandlerType
                .GetMethod("Handle")
                .Invoke(handler, new object[] { command });
        }
    }
}
