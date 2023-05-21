namespace Lab4.Output;

internal interface IOutputStrategy
{
    Task OutputData<T>(T[]? models);
}