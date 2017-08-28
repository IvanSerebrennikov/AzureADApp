using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureAdApp.Utils
{
    public class AzureServiceException : Exception
    {
        public AzureServiceException() : base()
        {
            
        }

        public AzureServiceException(string message) : base("Error while retrieving data from Azure AD with Graph API - " + message)
        {
            
        }
    }
}