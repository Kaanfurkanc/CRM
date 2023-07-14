namespace AdminPortalApi.ClientServices.Interfaces
{
    public interface IClientService<T> where T : class
    {
        Task<HttpResponseMessage> requestProcessAsync(HttpContext httpContext, string endpoint, T entity = null);
    }
}
