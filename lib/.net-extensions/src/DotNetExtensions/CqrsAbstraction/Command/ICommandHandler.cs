namespace DotNetExtensions.CqrsAbstraction.Command
{
    public interface ICommandHandler<in TCommand, TCommandResult> where TCommand : ICommand
    {
        Task<TCommandResult> Handle(TCommand command, CancellationToken cancellationToken = default);
    }
}
