using Lab4.Input;
using Newtonsoft.Json;

namespace Lab4.Common;

internal sealed class InputStrategyConfiguration
{
    [JsonProperty]
    public InputStrategyType Type { get; set; }

    [JsonProperty]
    public object?[]? Arguments { get; set; }
}