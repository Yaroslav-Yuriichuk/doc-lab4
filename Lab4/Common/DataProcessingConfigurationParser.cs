using System.Reflection;
using Lab4.Input;
using Lab4.Output;
using Newtonsoft.Json;
#pragma warning disable CS8602

namespace Lab4.Common;

internal sealed class DataProcessingConfigurationParser
{
    private readonly DataProcessingConfiguration? _configuration;

    public DataProcessingConfigurationParser(string path)
    {
        try
        {
            string json = File.ReadAllText(path);
            _configuration = JsonConvert.DeserializeObject<DataProcessingConfiguration>(json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IInputStrategy? GetInputStrategy()
    {
        if (_configuration is null)
        {
            return null;
        }

        InputStrategyType type = _configuration.InputStrategyConfiguration.Type;
        return type.CreateInputStrategy(_configuration?.InputStrategyConfiguration.Arguments);
    }

    public IOutputStrategy? GetOutputStrategy()
    {
        if (_configuration is null)
        {
            return null;
        }

        OutputStrategyType type = _configuration.OutputStrategyConfiguration.Type;
        return type.CreateOutputStrategy(_configuration.OutputStrategyConfiguration.Arguments);
    }
}