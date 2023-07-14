using Core.UnitOfWork;

namespace Host.Middlewares
{
    public class UnitOfWorkMiddleware
    {
        private readonly RequestDelegate _next;
        public UnitOfWorkMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, IUnitOfWork unitOfWork)
        {
            await _next.Invoke(context);
            await unitOfWork.CommitAsync();
        }
    }
}
