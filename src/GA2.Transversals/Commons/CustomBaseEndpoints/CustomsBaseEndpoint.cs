using Microsoft.AspNetCore.Mvc;

namespace GA2.Transversals.Commons.CustomBaseEndpoints
{
    /// <summary>
    /// Clase base para crear las peticiones de endpoints.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public static class BaseEndpoint
    {
        public static class WithRequest<TRequest>
        {
            public abstract class WithResponse<TResponse> : BaseEndpointSync
            {
                public abstract ActionResult<TResponse> HandleAsync(TRequest request);
            }

            public abstract class WithResponseCustoms<TResponse> : BaseEndpointSync
            {
                public abstract TResponse HandleAsync(TRequest request);
            }

            public abstract class WithoutResponse : BaseEndpointSync
            {
                public abstract ActionResult HandleAsync(TRequest request);
            }
        }

        public static class WithoutRequest
        {
            public abstract class WithResponse<TResponse> : BaseEndpointSync
            {
                public abstract ActionResult<TResponse> HandleAsync();
            }

            public abstract class WithResponseCustoms<TResponse> : BaseEndpointSync
            {
                public abstract TResponse HandleAsync();
            }

            public abstract class WithoutResponse : BaseEndpointSync
            {
                public abstract ActionResult HandleAsync();
            }
        }
    }

    /// <summary>
    /// A base class for all synchronous endpoints.
    /// </summary>
	[ApiController]
    public abstract class BaseEndpointSync : ControllerBase
    {
    }
}
