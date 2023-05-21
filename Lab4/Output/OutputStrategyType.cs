using Lab4.Common;

namespace Lab4.Output;

internal enum OutputStrategyType
{
    [StrategyType(typeof(ConsoleOutputStrategy))]
    Console,
    [StrategyType(typeof(RedisOutputStrategy))]
    Redis,
}