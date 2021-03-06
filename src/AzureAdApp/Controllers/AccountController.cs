﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

namespace AzureAdApp.Controllers
{
    public class AccountController : Controller
    {
        public void SignIn()
        {
            try
            {
                // Send an OpenID Connect sign in request.
                if (!Request.IsAuthenticated)
                {
                    HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
                }
            }
            catch (Exception e)
            {
                Response.Redirect("/Error?message=" + e.Message);
            }           
        }

        public void SignOut()
        {
            try
            {
                // Send an OpenID Connect sign out request.
                HttpContext.GetOwinContext().Authentication.SignOut(
                    OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
            }
            catch (Exception e)
            {
                Response.Redirect("/Error?message=" + e.Message);
            }            
        }
    }
}