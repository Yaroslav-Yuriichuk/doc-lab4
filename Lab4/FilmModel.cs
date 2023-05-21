using Newtonsoft.Json;

namespace Lab4;

internal sealed class FilmModel
{
    [JsonProperty("title")]
    public string? Title { get; set; }

    [JsonProperty("release_year")]
    public int? ReleaseYear { get; set; }

    [JsonProperty("locations")]
    public string? Locations { get; set; }

    [JsonProperty("fun_facts")]
    public string? FunFacts { get; set; }

    [JsonProperty("production_company")]
    public string? ProductionCompany { get; set; }

    [JsonProperty("distributor")]
    public string? Distributor { get; set; }

    [JsonProperty("director")]
    public string? Director { get; set; }

    [JsonProperty("writer")]
    public string? Writer { get; set; }

    [JsonProperty("actor_1")]
    public string? Actor1 { get; set; }

    [JsonProperty("actor_2")]
    public string? Actor2 { get; set; }

    [JsonProperty("actor_3")]
    public string? Actor3 { get; set; }

    public override string ToString()
    {
        return $"{Title ?? "___"} --- {(ReleaseYear == null ? "___" : ReleaseYear)} --- {Locations ?? "___"}";
    }
}