namespace GithubApiWrapper.Models.Common
{
    public class Response <T> where T:class, new()
    {
        public Response(string responseString)
        {
            Success = true;
            try
            {
                Data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                if (Data == null)
                {
                    Success = false;
                    NegativeResult = Newtonsoft.Json.JsonConvert.DeserializeObject<NegativeResult>(responseString);
                }
            }
            catch(Newtonsoft.Json.JsonSerializationException e)
            {
                NegativeResult = Newtonsoft.Json.JsonConvert.DeserializeObject<NegativeResult>(responseString);
            }
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
