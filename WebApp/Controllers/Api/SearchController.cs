using System.Threading.Tasks;
using System.Web.Http;
using GithubApiWrapper;
using GithubApiWrapper.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace WebApp.Controllers
{
    [RoutePrefix("search")]
    public class SearchController : ApiController
    {
        private readonly GithubApiClient _client;
        public SearchController(GithubApiClient client)
        {
            _client = client;
        }

        [HttpGet]
        [Route("users/{userName}")]
        public async Task<HttpResponseMessage> Users(string userName)
        {
            var result = await _client.GetUserAsync(userName);
            if (result != null)
            {
                return Request.CreateResponse(result);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"User with login {userName} not found");
        }

        [HttpGet]
        [Route("users/{userName}/repos")]
        public Task<List<Repo>> Repos(string userName)
        {
            return _client.GetReposAsync(userName);
        }

        [HttpGet]
        [Route("users/{userName}/repos/{repoName}/stargazers")]
        public Task<List<Stargazer>> Stargazers(string userName, string repoName)
        {
            return _client.GetStargazersAsync(userName, repoName);
        }
    }
}
