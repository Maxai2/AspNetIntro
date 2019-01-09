using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCalc.Middleware
{
    public class ErrorLoggingMW
    {
        private RequestDelegate next;

        public ErrorLoggingMW(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                Log.Logger.Error("Error: {0}{1}Stack here: {2}{1}-------------{1}", ex.Message, Environment.NewLine, ex.StackTrace);
                throw ex;
            }
        }
    }
}
