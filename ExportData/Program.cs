using ExportData;

public class Program
{
    public static async Task Main(string[] args)
    {
        var list = new List<ItemModel>
        {
           new ItemModel{Name = "dsgs", Description = "dsafs"},
           new ItemModel{Name = "dsgs", Description = "dsafs"},
           new ItemModel{Name = "dsgs", Description = "dsafs"},
           new ItemModel{Name = "dsgs", Description = "dsafs"},
           new ItemModel{Name = "dsgs", Description = "dsafs"}
        };

        var test = new ExportDataService();
        await test.SaveDataToCsvAsync(list);
        await test.SaveDataToJsonAsync(list);
    }
}