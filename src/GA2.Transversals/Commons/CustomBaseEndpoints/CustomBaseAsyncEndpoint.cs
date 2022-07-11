using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Transversals.Commons.CustomBaseEndpoints
{
    public static class BaseAsyncEndpoint
    {
        public static class WithRequest<TRequest>
        {
            public abstract class WithResponse<TResponse> : BaseEndpointAsync
            {
                public abstract Task<ActionResult<TResponse>> HandleAsync(
                    TRequest request,
                    CancellationToken cancellationToken = default
                );
            }

            public abstract class WithResponseCustoms<TResponse> : BaseEndpointAsync
            {
                public abstract Task<TResponse> HandleAsync(
                    TRequest request,
                    CancellationToken cancellationToken = default
                );
            }

            public abstract class WithoutResponse : BaseEndpointAsync
            {
                public abstract Task<ActionResult> HandleAsync(
                    TRequest request,
                    CancellationToken cancellationToken = default
                );
            }
        }

        public static class WithRequestCustoms<TRequestOne, TRequestTwo>
        {
            public abstract class WithResponse<TResponse> : BaseEndpointAsync
            {
                public abstract Task<ActionResult<TResponse>> HandleAsync(
                    TRequestOne requestOne, TRequestTwo requestTwo,
                    CancellationToken cancellationToken = default
                );
            }

            public abstract class WithResponseCustoms<TResponse> : BaseEndpointAsync
            {
                public abstract Task<TResponse> HandleAsync(
                   TRequestOne requestOne, TRequestTwo requestTwo,
                    CancellationToken cancellationToken = default
                );
            }

            public abstract class WithoutResponse : BaseEndpointAsync
            {
                public abstract Task<ActionResult> HandleAsync(
                    TRequestOne requestOne, TRequestTwo requestTwo,
                    CancellationToken cancellationToken = default
                );
            }
        }

        public static class WithoutRequest
        {
            public abstract class WithResponse<TResponse> : BaseEndpointAsync
            {
                public abstract Task<ActionResult<TResponse>> HandleAsync(
                    CancellationToken cancellationToken = default
                );
            }

            public abstract class WithResponseCustoms<TResponse> : BaseEndpointAsync
            {
                public abstract Task<TResponse> HandleAsync(
                    CancellationToken cancellationToken = default
                );
            }

            public abstract class WithoutResponse : BaseEndpointAsync
            {
                public abstract Task<ActionResult> HandleAsync(
                    CancellationToken cancellationToken = default
                );
            }
        }
    }

    /// <summary>
    /// A base class for all asynchronous endpoints.
    /// </summary>
    [ApiController]
    public abstract class BaseEndpointAsync : ControllerBase
    {
    }
}
