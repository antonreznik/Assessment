using System.Threading.Tasks;

namespace assessment_platform_developer.Infrastructure.Interfaces.Mediator
{
    public interface IMediator
    {
        Task<TResult> Send<TResult>(ICommand<TResult> command) where TResult : ICommandResult;
    }
}
