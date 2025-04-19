namespace CliHang.Infra;

public class FileHelper
{
    public async Task<string> GetFileText(string fileName)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "/connection", fileName);
        return await File.ReadAllTextAsync(path);
    }
}