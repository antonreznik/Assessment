using System.Threading.Tasks;

namespace assessment_platform_developer.Infrastructure.Interfaces.Mediator
{
    public interface IMessageHandler<TCommand, TResult> 
        where TCommand : IMessage<TResult>
        where TResult : IMessageResult
    {
        Task<TResult> Handle(TCommand command);
    }
}
