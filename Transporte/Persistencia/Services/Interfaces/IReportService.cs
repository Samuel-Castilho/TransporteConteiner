using static Transporte.Persistencia.Services.ReportService;

namespace Transporte.Persistencia.Services.Interfaces
{
    public interface IReportService
    {

        public Task<List<MovimentacaoPorCliente>> GetMovimentacoesPorCliente();
        public Task<List<MovimentacaoPorTipoMovimentacao>> GetMovimentacoesPorTipoMovimentacao();
        public  Task<List<SumarioImportacaoExportacao>> GetSumarioImportacaoExportacao();
    }
}
