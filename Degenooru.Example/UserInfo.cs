using System.Collections.Generic;
using Newtonsoft.Json;

namespace Degenooru.Example
{
    public class UserInfo
    {
        [JsonProperty("uuid")] public string Uuid { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("rankcolor")] public string RankColor { get; set; }

        [JsonProperty("tokens")] private double Tokens { get; set; }

        [JsonProperty("stats")] public PlayerStats Stats { get; set; }

        [JsonProperty("favoritemaps")] public List<object> FavoriteMaps { get; set; }
    }
}