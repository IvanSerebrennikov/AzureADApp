using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureAdApp.Utils
{
    /// <summary>
    /// Encapsulate all azure app constants and methods for work with azure variables (like a access token, etc.)
    /// </summary>
    public static class AzureHelper
    {
        public static readonly string AppId = ConfigurationManager.AppSettings["AzureAppId"];
        public static readonly string AppName = ConfigurationManager.AppSettings["AzureAppName"];
        public static readonly string AppSecret = ConfigurationManager.AppSettings["AzureAppSecret"];
        public static readonly string RedirectUri = ConfigurationManager.AppSettings["AzureRedirectUri"];

        private static readonly string AzureLoginUrl = "https://login.microsoftonline.com";
        private static readonly string AzureGraphUrl = "https://graph.windows.net";

        public static readonly string Authority = $"{AzureLoginUrl}/{AppName}";

        /// <summary>
        /// Generate Graph API url for users method
        /// </summary>
        /// <returns></returns>
        public static string GenerateUsersApiUrl()
        {
            return $"{AzureGraphUrl}/{AppName}/users";
        }

        /// <summary>
        /// Generate Graph API url for memberOf method
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GenerateMemberOfUrl(string userId)
        {
            return $"{AzureGraphUrl}/{AppName}/users/{userId}/memberOf";
        }

        /// <summary>
        /// Get access token for working with Graph API
        /// </summary>
        /// <returns>Access token</returns>
        public static async Task<string> GetTokenAsync()
        {
            var credential = new ClientCredential(AppId, AppSecret);
            var authContext = new AuthenticationContext(Authority);

            var result = await authContext.AcquireTokenAsync(AzureGraphUrl, credential);

            return result.AccessToken;
        }        
    }
}