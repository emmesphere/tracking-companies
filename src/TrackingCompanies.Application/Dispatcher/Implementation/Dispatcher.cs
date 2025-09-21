using Microsoft.Extensions.DependencyInjection;

namespace TrackingCompanies.Application.Dispatcher.Implementation;

public class Dispatcher : IDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public Dispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    } 

    public async Task Send<TCommand>(TCommand command, CancellationToken cancellationToken = default) 
        where TCommand : ICommand
    {
        var handler = (ICommandHandler<TCommand>?)_serviceProvider
            .GetRequiredService(typeof(ICommandHandler<TCommand>));
        
        if (handler == null)
            throw new InvalidOperationException($"Handler for command {typeof(TCommand).FullName} not registered.");
        
        await handler.Handle(command, cancellationToken);
    }

    public async Task<TResult> Send<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default) 
        where TCommand : ICommand<TResult>
    {
        var handler = (ICommandHandler<TCommand, TResult>?)_serviceProvider
            .GetRequiredService(typeof(ICommandHandler<TCommand, TResult>));
        
        if (handler == null)
            throw new InvalidOperationException($"Handler for command {typeof(TCommand).FullName} not registered.");
        
        return await handler.Handle(command, cancellationToken);
    }

    public async Task<TResult> Send<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
    {
            var handler = (IQueryHandler<TQuery, TResult>?)_serviceProvider
                .GetRequiredService(typeof(IQueryHandler<TQuery, TResult>));
            
            if (handler == null)
                throw new InvalidOperationException($"Handler for query {typeof(TQuery).FullName} not registered.");

            return await handler.Handle(query);
        
    }
}