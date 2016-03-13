using System.Collections.Generic;
using System.Threading.Tasks;

namespace GithubApiWrapper.Models
{
    public class Stargazer
    {
        public string Login { get; set; }
    }

    public static partial class GithubApiClientExtensions
    {
        public static List<Stargazer> GetStargazers(this GithubApiClient client, string login, string repoName)
        {
            return client.Get<List<Stargazer>>($"repos/{login}/{repoName}/stargazers") ?? new List<Stargazer>();
        }

        public static async Task<List<Stargazer>> GetStargazersAsync(this GithubApiClient client, string login, string repoName)
        {
            var result = await client.GetAsync<List<Stargazer>>($"repos/{login}/{repoName}/stargazers");
            return result ?? new List<Stargazer>();
        }
    }
}
