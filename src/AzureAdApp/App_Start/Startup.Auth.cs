using System;
using System.Configuration;
using System.Threading.Tasks;
using AzureAdApp.Utils;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

namespace AzureAdApp
{  
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.Use<GlobalExceptionMiddleware>();

            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = AzureHelper.AppId,
                    Authority = AzureHelper.Authority,
                    PostLogoutRedirectUri = AzureHelper.RedirectUri,
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthenticationFailed = context =>
                        {
                            context.HandleResponse();
                            context.Response.Redirect("/Error?message=" + context.Exception.Message);
                            return Task.FromResult(0);
                        }
                    }
                });
        }
    }
}