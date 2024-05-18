namespace assessment_platform_developer.Infrastructure.Interfaces.Mediator
{
    public interface IMessage<TResult> where TResult : IMessageResult
    {
    }
}
