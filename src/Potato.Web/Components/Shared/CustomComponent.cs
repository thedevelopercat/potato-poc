using Microsoft.AspNetCore.Components;

namespace Potato.Web.Components.Shared
{
    public abstract class CustomComponent : ComponentBase, IDisposable
    {
        private readonly CancellationTokenSource _cancellationTokenSource;
        public readonly CancellationToken CancellationToken;

        protected CustomComponent()
        {
            _cancellationTokenSource = new();
            CancellationToken = _cancellationTokenSource.Token;
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }
}
