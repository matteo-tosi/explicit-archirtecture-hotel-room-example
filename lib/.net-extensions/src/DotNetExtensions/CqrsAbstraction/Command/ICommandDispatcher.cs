﻿namespace DotNetExtensions.CqrsAbstraction.Command
{
    public interface ICommandDispatcher
    {
        Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand
            where TCommandResult : class;
    }
}
