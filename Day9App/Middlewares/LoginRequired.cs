using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day9App.Middlewares
{
    public class LoginRequired : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Headers["Token"].ToString() == "hello")
            {
                await next(context);
            }
            else
            {
                await context.Response.WriteAsync("Not Authrnticated");

            }
        }
    }
}
