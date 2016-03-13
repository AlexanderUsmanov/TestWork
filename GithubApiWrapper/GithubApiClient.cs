using System;
using System.Net.Http;
using System.Threading.Tasks;
using GithubApiWrapper.Models.Common;
using RestSharp;

namespace GithubApiWrapper
{
    public class GithubApiClient
    {
        private readonly RestClient _restClient;

        public GithubApiClient()
        {
            _restClient = new RestClient("https://api.github.com");
        }

        public Response<T> Execute<T>(string resource, HttpMethod httpMethod) where T:class, new()
        {
            var req = PrepareRequest(resource, httpMethod);
            var resp = _restClient.Execute(req);
            return new Response<T>(resp.Content);
        }

        public T Get<T>(string resource) where T : class, new()
        {
            var result = Execute<T>(resource, HttpMethod.Get);
            if (result.Success)
                return result.Data;
            return null;
        }

        public async Task<Response<T>> ExecuteAsync<T>(string resource, HttpMethod httpMethod) where T : class, new()
        {
            var req = PrepareRequest(resource, httpMethod);
            var resp = await _restClient.ExecuteGetTaskAsync(req);
            return new Response<T>(resp.Content);
        }

        public async Task<T> GetAsync<T>(string resource) where T : class, new()
        {
            var result = await ExecuteAsync<T>(resource, HttpMethod.Get);
            if (result.Success)
                return result.Data;
            return null;
        }

        private RestRequest PrepareRequest(string resource, HttpMethod httpMethod)
        {
            Method method;
            if (!Enum.TryParse(httpMethod.Method, out method))
            {
                method = Method.GET;
            }

            return new RestRequest(resource, method);
        }
    }
}
