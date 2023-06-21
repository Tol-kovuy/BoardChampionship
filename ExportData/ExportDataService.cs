using CsvHelper;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExportData;

public class ExportDataService : IExportDataService
{
    private readonly static string _name = Guid.NewGuid().ToString();
    private readonly string _csvFormat = Environment.CurrentDirectory + $"{_name}.csv";
    private readonly JsonSerializerOptions _options =
       new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    private readonly string _jsonFormat = Environment.CurrentDirectory + $"{_name}.json";

    public async Task SaveDataToCsvAsync(IList<ItemModel> items)
    {
        using var writer = new StreamWriter(_csvFormat);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        await csv.WriteRecordsAsync(items);
    }

    public async Task SaveDataToJsonAsync(object obj)
    {
        var options = new JsonSerializerOptions(_options)
        {
            WriteIndented = true
        };
        var jsonString = JsonSerializer.Serialize(obj, options);
        await File.WriteAllTextAsync(_jsonFormat, jsonString);
    }
}
