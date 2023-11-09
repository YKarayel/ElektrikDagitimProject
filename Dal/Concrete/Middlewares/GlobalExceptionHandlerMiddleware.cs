using Dal.Concrete;
using ElektrikDagıtım.Entities.Concrete.General;
using Entities.Concrete.General;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ElektrikDagıtım.Dal.Concrete.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                using (var scope = context.RequestServices.CreateScope())
                {
                    var _cnt = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    LOGGING newLOGGING = new LOGGING();
                    newLOGGING.KayıtTarih = DateTime.Now;
                    newLOGGING.Message = ex.Message;
                    _cnt.LOGLAR.Add(newLOGGING);
                    await _cnt.SaveChangesAsync();



                    var response = context.Response;
                    response.ContentType = "application/json";
                    response.StatusCode = 500;
                    await response.WriteAsync("Custom Global Middleware tarafından yaklanmış hatadır. \n" +
                        ex.Message + Environment.NewLine + ex.StackTrace);
                }


            }
        }
    }
}
