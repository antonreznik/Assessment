using System.Threading.Tasks;

namespace assessment_platform_developer.Infrastructure.Interfaces.Mediator
{
    public interface ICommandHandler<TCommand, TResult> 
        where TCommand : ICommand<TResult>
        where TResult : ICommandResult
    {
        Task<TResult> Handle(TCommand command);
    }
}
