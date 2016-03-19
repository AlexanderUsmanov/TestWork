namespace GithubApiWrapper.Models.Common
{
    public class Response <T> where T:class, new()
    {
        public Response(string responseString)
        {
            NegativeResult = Newtonsoft.Json.JsonConvert.DeserializeObject<NegativeResult>(responseString);
            if (!string.IsNullOrWhiteSpace(NegativeResult.Message))
            {
                return;
            }

            Success = true;
            NegativeResult = null;
            Data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
        }

        public string GetJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public bool Success { get; set; }
        public NegativeResult NegativeResult { get; set; }
        public T Data { get; set; }
    }
}
