using Newtonsoft.Json;
#nullable disable

namespace B2C.ApiHelper.Model
{
    public class AuthenticateResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }

        [JsonProperty("as:client_id")]
        public string asclient_id { get; set; }
        public string userName { get; set; }

        [JsonProperty(".issued")]
        public string issued { get; set; }

        [JsonProperty(".expires")]
        public string expires { get; set; }
    }
}
