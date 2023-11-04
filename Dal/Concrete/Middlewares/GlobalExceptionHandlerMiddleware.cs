using Dal.Concrete;
using ElektrikDagıtım.Entities.Concrete.General;
using Entities.Concrete.General;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektrikDagıtım.Dal.Concrete.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppDbContext _cnt;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, AppDbContext cnt)
        {
            _next = next;
            _cnt = cnt;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {


                LOGGING newLOGGING = new LOGGING();
                newLOGGING.Date = DateTime.Now;
                newLOGGING.Message = ex.Message;
                _cnt.LOGLAR.Add(newLOGGING);
                await _cnt.SaveChangesAsync();



                var response = context.Response;
                response.ContentType= "application/json";
                response.StatusCode = 500;
                await response.WriteAsync("Custom Global Middleware tarafından yaklanmış hatadır. \n" + 
                    ex.Message + Environment.NewLine + ex.StackTrace);


            }
        }
    }
}
