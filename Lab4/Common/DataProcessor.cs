using Lab4.Input;
using Lab4.Output;

namespace Lab4.Common;

internal sealed class DataProcessor
{
    private readonly IInputStrategy _inputStrategy;
    private readonly IOutputStrategy _outputStrategy;

    public DataProcessor(IInputStrategy? inputStrategy, IOutputStrategy? outputStrategy)
    {
        _inputStrategy = inputStrategy ?? throw new ArgumentNullException(nameof(inputStrategy));
        _outputStrategy = outputStrategy ?? throw new ArgumentNullException(nameof(outputStrategy));
    }

    public async Task Process<T>()
    {
        T[]? models = await _inputStrategy.GetData<T>();
        await _outputStrategy.OutputData(models);
    }
}