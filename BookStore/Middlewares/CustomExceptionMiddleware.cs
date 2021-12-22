using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using BookStore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BookStore.Middlewares{

 public class CustomExceptionMiddleware{
     private readonly RequestDelegate _next;
     private readonly ILogger _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger logger)
        {
            this._next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context){
            var time = Stopwatch.StartNew();

            try{
            string message = "[Request] HTTP "+ context.Request.Method +" - " +context.Request.Path;
            _logger.Write(message);
            await _next(context);
            message = "[Request] HTTP" + context.Request.Method +" - " + context.Request.Path +" - "+context.Response.StatusCode+" responded "+ time.ElapsedMilliseconds + "ms";
            _logger.Write(message);
            }
            
            catch(Exception ex){
            time.Stop();
            await HandleException(ex,context,time);
            }
        }

        private Task HandleException(Exception ex, HttpContext context, Stopwatch time)
        {
            context.Response.StatusCode=(int) HttpStatusCode.InternalServerError;
            context.Response.ContentType="application/json";
            string message = "[Error] HTTP "+context.Request.Method+" - "+ context.Response.StatusCode+" Error Message: "+ex.Message+" in "+time.ElapsedMilliseconds+"ms";
            _logger.Write(message);
            var result = JsonConvert.SerializeObject( new {error= ex.Message},Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }
static public class CustomExceptionMiddlewareExtension{
    static public IApplicationBuilder UseCustomExceptionMiddle( this IApplicationBuilder builder){
        return builder.UseMiddleware<CustomExceptionMiddleware>();
        
    }
}

}