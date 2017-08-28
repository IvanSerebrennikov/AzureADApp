using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using AzureAdApp.Models;
using AzureAdApp.Models.Responses;
using AzureAdApp.Utils;
using Newtonsoft.Json;

namespace AzureAdApp.Services
{
    public class AzureService
    {
        public async Task<List<AzureUserModel>> GetUsersAsync()
        {
            var uri = AzureHelper.GenerateUsersApiUrl();

            var response = await GetResponseOrThrowAsync<BaseResponse<AzureUserModel>>(uri);

            return response != null ? response.Value : new List<AzureUserModel>();
        }

        public async Task<List<AzureMembershipModel>> GetUserGroupsAsync(string userId)
        {
            var uri = AzureHelper.GenerateMemberOfUrl(userId);

            var response = await GetResponseOrThrowAsync<BaseResponse<AzureMembershipModel>>(uri);

            return response != null ? response.Value : new List<AzureMembershipModel>();
        }

        private static async Task<T> GetResponseOrThrowAsync<T>(string uri)
        {
            var baseResponse = await GetBaseResponseAsync(uri);

            if (!string.IsNullOrEmpty(baseResponse.ResponseString) && baseResponse.IsSucceeded)
            {
                return JsonConvert.DeserializeObject<T>(baseResponse.ResponseString);
            }
            else if (!string.IsNullOrEmpty(baseResponse.ResponseString) && !baseResponse.IsSucceeded)
            {
                var error = JsonConvert.DeserializeObject<AzureErrorResponse>(baseResponse.ResponseString);

                throw new AzureServiceException(error?.ODataError?.Message?.Value);
            }
            else
            {
                throw new AzureServiceException("Response is empty");
            }
        }

        private static async Task<AzureServiceBaseResult> GetBaseResponseAsync(string url)
        {
            var client = await GetHttpClientWithAuthHeaderAsync();

            var queryString = GetBaseQueryString();

            var urlWithQuery = url + "?" + queryString;

            var response = await client.GetAsync(urlWithQuery);

            string responseString = "";

            if (response.Content != null)
            {
                responseString = await response.Content.ReadAsStringAsync();
            }

            return new AzureServiceBaseResult
            {
                ResponseString = responseString,
                IsSucceeded = response.IsSuccessStatusCode
            };
        }

        private static async Task<HttpClient> GetHttpClientWithAuthHeaderAsync()
        {
            var client = new HttpClient();
            var accessToken = await AzureHelper.GetTokenAsync();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", accessToken);

            return client;
        }

        private static NameValueCollection GetBaseQueryString()
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["api-version"] = "1.6";

            return queryString;
        }
    }
}