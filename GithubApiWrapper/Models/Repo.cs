using System.Collections.Generic;
using System.Threading.Tasks;

namespace GithubApiWrapper.Models
{
    public class Repo
    {
        public string Name { get; set; }
        public int Stargazers_Count { get; set; }
    }

    public static partial class GithubApiClientExtensions
    {
        public static List<Repo> GetRepos(this GithubApiClient client, string login)
        {
            return client.Get<List<Repo>>($"users/{login}/repos") ?? new List<Repo>();
        }

        public static async Task<List<Repo>> GetReposAsync(this GithubApiClient client, string login)
        {
            var result = await client.GetAsync<List<Repo>>($"users/{login}/repos");
            return result ?? new List<Repo>();
        }
    }
}
