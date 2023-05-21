using System.Globalization;
using CsvHelper;

namespace Lab4.Input;

internal sealed class CsvFileInputStrategy : IInputStrategy
{
    private readonly string _filePath;

    public CsvFileInputStrategy(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<T[]?> GetData<T>()
    {
        if (!File.Exists(_filePath))
        {
            return Array.Empty<T>();
        }

        using var streamReader = new StreamReader(_filePath);
        using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

        IAsyncEnumerable<T> csvModels = csvReader.GetRecordsAsync<T>();

        if (csvModels == null)
        {
            return Array.Empty<T>();
        }

        List<T> models = new List<T>();

        await foreach (var model in csvModels)
        {
            models.Add(model);
        }

        return models.ToArray();
    }
}