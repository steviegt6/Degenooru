using System.Collections.Generic;
using Newtonsoft.Json;

namespace Degenooru.Example
{
    public class UserInfo
    {
        [JsonProperty("uuid")] public string Uuid { get; set; } = null!;

        [JsonProperty("name")] public string Name { get; set; } = null!;

        [JsonProperty("title")] public string Title { get; set; } = null!;

        [JsonProperty("rankcolor")] public string RankColor { get; set; } = null!;

        [JsonProperty("tokens")] private double Tokens { get; set; }

        [JsonProperty("stats")] public PlayerStats Stats { get; set; } = null!;

        [JsonProperty("favoritemaps")] public List<object> FavoriteMaps { get; set; } = null!;
    }
}