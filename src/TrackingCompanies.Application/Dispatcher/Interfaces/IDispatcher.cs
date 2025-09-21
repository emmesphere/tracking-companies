namespace TrackingCompanies.Application.Dispatcher;

public interface IDispatcher
{
    Task Send<TCommand>(TCommand command, CancellationToken cancellationToken = default) 
        where TCommand : ICommand;
    Task<TResult> Send<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default) 
        where TCommand : ICommand<TResult>;
    Task<TResult> Send<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
}