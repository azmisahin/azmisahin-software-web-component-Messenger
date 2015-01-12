using Newtonsoft.Json;
/// <summary>
/// Singlar Models
/// </summary>
namespace @as.Messenger.Models
{
    /// <summary>
    /// Messenger Base Model
    /// </summary>
    public class SignalModel
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("account")]
        public string account { get; set; }

        [JsonProperty("type")]
        public int type { get; set; }
        public object data { get; set; }
    }
}