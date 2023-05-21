namespace Lab4.Output;

internal sealed class ConsoleOutputStrategy : IOutputStrategy
{
    public async Task OutputData<T>(T[]? models)
    {
        if (models is null)
        {
            return;
        }

        foreach (T model in models)
        {
            Console.WriteLine(model);
            await Task.Yield();
        }
    }
}