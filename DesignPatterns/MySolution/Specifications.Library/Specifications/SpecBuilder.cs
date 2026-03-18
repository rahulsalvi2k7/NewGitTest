using Specifications.Library.Interfaces;

namespace Specifications.Library.Specifications
{
    public class SpecBuilder<T>
    {
        private IAsyncSpecification<T>? _current;

        private string? _name;

        public SpecBuilder<T> When(Func<T, bool> predicate)
        {
            var spec = new ExpressionSpecification<T>(predicate);
            _current = _current == null ? spec : _current.And(spec);
            return this;
        }

        public SpecBuilder<T> WhenAsync(Func<T, Task<bool>> predicate)
        {
            var spec = new AsyncDelegateSpecification<T>(predicate);
            _current = _current == null ? spec : _current.And(spec);
            return this;
        }

        public SpecBuilder<T> And(Func<T, bool> predicate)
            => Combine(new ExpressionSpecification<T>(predicate), isAnd: true);

        public SpecBuilder<T> AndAsync(Func<T, Task<bool>> predicate)
            => Combine(new AsyncDelegateSpecification<T>(predicate), isAnd: true);

        public SpecBuilder<T> Or(Func<T, bool> predicate)
            => Combine(new ExpressionSpecification<T>(predicate), isAnd: false);

        public SpecBuilder<T> OrAsync(Func<T, Task<bool>> predicate)
            => Combine(new AsyncDelegateSpecification<T>(predicate), isAnd: false);

        public SpecBuilder<T> Not(Func<T, bool> predicate)
        {
            var spec = new ExpressionSpecification<T>(predicate).Not();
            return Combine(spec, isAnd: true);
        }

        public SpecBuilder<T> NotAsync(Func<T, Task<bool>> predicate)
        {
            return Combine(new AsyncDelegateSpecification<T>(predicate).Not(), isAnd: true);
        }

        public SpecBuilder<T> Named(string name)
        {
            _name = name;

            return this;
        }

        public string Name => _name ?? string.Empty;

        private SpecBuilder<T> Combine(IAsyncSpecification<T> spec, bool isAnd)
        {
            if (_current == null)
            {
                _current = spec;
            }
            else
            {
                _current = isAnd
                    ? _current.And(spec)
                    : _current.Or(spec);
            }

            return this;
        }

        public IAsyncSpecification<T> Build()
            => _current ?? throw new InvalidOperationException("No specification defined.");
    }
}
