namespace CliHang.Domain;

public class ViewGroupedErrors
{
    public List<ErrorGroup> Errors { get; set; } = [];
    public int TotalErrors { get; set; }
}

public class ErrorGroup
{
    public string Error { get; set; } = string.Empty;
    public int Count { get; set; }
}