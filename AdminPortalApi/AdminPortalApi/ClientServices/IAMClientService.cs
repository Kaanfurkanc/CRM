using AdminPortalApi.ClientServices.Interfaces;

namespace AdminPortalApi.ClientServices
{
    public class IAMClientService<T> : IClientService<T> where T : class
    {
        public Task<HttpResponseMessage> requestProcessAsync(HttpContext httpContext, string endpoint, T entity = null)
        {
            
        }
    }
}
