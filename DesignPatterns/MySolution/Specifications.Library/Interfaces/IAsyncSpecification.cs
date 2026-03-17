namespace Specifications.Library.Interfaces
{
    public interface IAsyncSpecification<T>
    {
        Task<bool> IsSatisfiedByAsync(T candidate, CancellationToken cancellationToken);

        IAsyncSpecification<T> And(IAsyncSpecification<T> other);

        IAsyncSpecification<T> Or(IAsyncSpecification<T> other);

        IAsyncSpecification<T> Not();
    }
}
