namespace ExportData;

public interface IExportDataService
{
    Task SaveDataToCsvAsync(IList<ItemModel> objects);
    Task SaveDataToJsonAsync(object obj);
}
