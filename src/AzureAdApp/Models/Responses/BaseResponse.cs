using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureAdApp.Models.Responses
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Value = new List<T>();
        }

        public List<T> Value { get; set; }
    }
}