﻿using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.CompilerServices;

namespace Host.Middlewares.Extensions
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlingMiddleware> logger)
        { 
            _logger = logger;
            _next = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Opps .. Something went wrong : {ex}");

                await HandleExceptionAsync(httpContext, ex);

                //using (var transaction = await context.Database.BeginTransactionAsync())
                //{
                //    await transaction.RollbackAsync();
                //    await transaction.CommitAsync(); // İşlemi onaylamak için
                //}
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var exceptionType = exception.GetType().ToString();

            switch (exceptionType)
            {
                case nameof(ValidationException):
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsync(context.Response.StatusCode + $"Bad Request ! : {exception.Message}");
                    break;
                case nameof(NotFound):
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    await context.Response.WriteAsync(context.Response.StatusCode + $"Not Found ! : {exception.Message}");
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsync(context.Response.StatusCode + $"Internal Server Error ! : {exception.Message}");
                    break;
            }
        }
    }
}
