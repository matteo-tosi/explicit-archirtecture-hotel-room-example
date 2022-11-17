using Microsoft.Extensions.DependencyInjection;

namespace DotNetExtensions.CqrsAbstraction.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand
            where TCommandResult : class
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TCommandResult>>();
            return await handler.Handle(command, cancellationToken);
        }
    }
}
