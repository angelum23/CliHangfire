using CliHang.Domain;
using CliHang.Domain.Interface;
using CliHang.Repository;

namespace CliHang.Service;

public class ServJob : IServJob
{
    private readonly IRepJob _repJob;
    
    public ServJob(IRepJob repJob)
    {
        _repJob = repJob;
    }

    public async Task<ViewGroupedErrors> GroupedErrors()
    {
        // var failed = await _repJob.GetFailedAsync();
        //todo definir lógica de agrupamento
        return new ViewGroupedErrors
        {
            Errors = [
                new ErrorGroup
                {
                    Error = "Erro ao fazer tal coisa",
                    Count = 62
                },
                new ErrorGroup
                {
                    Error = "Erro ao cutucar o nariz",
                    Count = 12
                }
            ]
        };
    }
}