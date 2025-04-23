namespace CliHang.Domain.Interface;

public interface IServJob
{
    Task<ViewGroupedErrors> GroupedErrors();
}