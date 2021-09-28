using BackEnd.Models.Repository.VisitorRepository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Middlewares
{
    public class RoutingMiddleware
    {

        private RequestDelegate _next;
       

        public RoutingMiddleware(RequestDelegate next)
        {
   
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IVisitorRepository visitorRepository)
        {

           var va = context.Request.Headers["set-cookie"];

            if (context.Request.Headers["set-cookie"]== "usersession=usersession")
            {

                await _next?.Invoke(context);

            }
            if(context.Request.Headers["set-cookie"] != "usersession=usersession" && context.Request.Method!="OPTIONS" && context.Request.Headers["Accept"] != "image/avif,image/webp,image/apng,image/svg+xml,image/*,*/*;q=0.8")
            {
                context.Response.Cookies.Append("userssesionnn", HashHelper.GetHashString("asdas"));
                visitorRepository.AddNewVisitor();
             

            }
            await  _next?.Invoke(context);
        }
    }
}
