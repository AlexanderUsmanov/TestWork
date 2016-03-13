using System.Threading.Tasks;
using System.Web.Http;
using GithubApiWrapper;
using GithubApiWrapper.Models;
using System.Collections.Generic;

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
        public Task<User> Users(string userName)
        {
            return _client.GetUserAsync(userName);
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
