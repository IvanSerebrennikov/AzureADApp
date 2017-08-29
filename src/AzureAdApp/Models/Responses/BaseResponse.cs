using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureAdApp.Models.Responses
{
    /// <summary>
    /// Base Graph API response where Value is array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Value = new List<T>();
        }

        public List<T> Value { get; set; }
    }
}