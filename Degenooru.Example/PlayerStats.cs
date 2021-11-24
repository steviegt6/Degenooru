using Newtonsoft.Json;

namespace Degenooru.Example
{
    public class PlayerStats
    {
        [JsonProperty("overall")] public GamemodeStats Overall { get; set; } = null!;

        [JsonProperty("solos")] public GamemodeStats Solos { get; set; } = null!;

        [JsonProperty("doubles")] public GamemodeStats Doubles { get; set; } = null!;

        [JsonProperty("threes")] public GamemodeStats Threes { get; set; } = null!;

        [JsonProperty("fours")] public GamemodeStats Fours { get; set; } = null!;
    }
}