using Lab4.Common;

namespace Lab4.Input;

internal enum InputStrategyType
{
    [StrategyType(typeof(EndPointInputStrategy))]
    EndPoint,
    [StrategyType(typeof(CsvFileInputStrategy))]
    CsvFile,
}