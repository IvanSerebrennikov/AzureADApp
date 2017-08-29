using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;

namespace AzureAdApp.Utils
{
    /// <summary>
    /// Middleware that catch all owin exceptions and redirect to /Error with exception message
    /// </summary>
    public class GlobalExceptionMiddleware : OwinMiddleware
    {
        public GlobalExceptionMiddleware(OwinMiddleware next) : base(next)
        { }

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception e)
            {
                context.Response.Redirect("/Error?message=" + e.Message);
            }
        }
    }
}