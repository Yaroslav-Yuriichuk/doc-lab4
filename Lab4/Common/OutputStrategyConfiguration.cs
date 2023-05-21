using Lab4.Output;
using Newtonsoft.Json;

namespace Lab4.Common;

internal sealed class OutputStrategyConfiguration
{
    [JsonProperty]
    public OutputStrategyType Type { get; set; }

    [JsonProperty]
    public object?[]? Arguments { get; set; }
}