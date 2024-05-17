namespace assessment_platform_developer.Infrastructure.Interfaces.Mediator
{
    public interface ICommand<TResult> where TResult : ICommandResult
    {
    }
}
