namespace TrackingCompanies.Application.Dispatcher;

public interface ICommand { }

public interface ICommand<TResult> : ICommand{ }