using System.Threading.Tasks;

namespace GithubApiWrapper.Models
{
    public class User
    {
        public string Name { get; set; }
        public int Public_Repos { get; set; }
        public int Followers { get; set; }
    }

    public static partial class GithubApiClientExtensions
    {
        public static User GetUser(this GithubApiClient client, string login)
        {
            return client.Get<User>($"users/{login}");
        }

        public static Task<User> GetUserAsync(this GithubApiClient client, string login)
        {
            return client.GetAsync<User>($"users/{login}");
        }
    }
}
