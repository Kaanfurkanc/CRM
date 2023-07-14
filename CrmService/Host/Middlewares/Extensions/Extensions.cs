using Microsoft.AspNetCore.Builder;
using Repository;
using System.Runtime.CompilerServices;

namespace Host.Middlewares.Extensions
{
    public static class Extensions
    {
        public static IApplicationBuilder UseUnitOfWork(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UnitOfWorkMiddleware>();
        }

        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
