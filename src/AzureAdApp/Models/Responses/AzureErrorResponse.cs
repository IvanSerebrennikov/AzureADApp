using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AzureAdApp.Models.Responses
{
    public class AzureErrorResponse
    {
        [JsonProperty("odata.error")]
        public ODataError ODataError { get; set; }
    }

    public class ODataError
    {
        public string Code { get; set; }

        public ErrorMessage Message { get; set; }
    }

    public class ErrorMessage
    {
        public string Value { get; set; }
    }
}