using Microsoft.EntityFrameworkCore;
using Models;
using System.Diagnostics;
using Transporte.Persistencia.Context;
using Transporte.Persistencia.Services.Interfaces;

namespace Transporte.Persistencia.Services
{
    public class ReportService : IReportService
    {

        protected TransporteContext _db;

        public ReportService(TransporteContext db)
        {
            _db = db;
        }


        public async Task<List<MovimentacaoPorCliente>> GetMovimentacoesPorCliente()
        {
            List<MovimentacaoPorCliente> list =await  (from mov in _db.Movimentacaos
                                                 join cont in _db.Conteiners on mov.NumeroConteiner equals cont.Numero
                                                 group mov by cont.Cliente into g
                                                 select new MovimentacaoPorCliente()
                                                 {
                                                     Cliente = g.Key,
                                                     Quantidade = g.Count()
                                                 }).ToListAsync();


            return list; 
        }

        public async Task<List<MovimentacaoPorTipoMovimentacao>> GetMovimentacoesPorTipoMovimentacao()
        {
            List<MovimentacaoPorTipoMovimentacao> list = await (from mov in _db.Movimentacaos
                                                       group mov by mov.Tipo into g
                                                       select new MovimentacaoPorTipoMovimentacao()
                                                       {
                                                           TipoMovimentacao = g.Key,
                                                           Quantidade = g.Count()
                                                       }).ToListAsync();


            return list;
        }

        public async Task<List<SumarioImportacaoExportacao>> GetSumarioImportacaoExportacao()
        {
            List<SumarioImportacaoExportacao> list = await (from mov in _db.Movimentacaos
                                                       join cont in _db.Conteiners on mov.NumeroConteiner equals cont.Numero
                                                       group mov by cont.Categoria into g
                                                       select new SumarioImportacaoExportacao()
                                                       {
                                                           Categoria = g.Key,
                                                           Quantidade = g.Count()
                                                       }).ToListAsync();


            return list;
        }





        public class MovimentacaoPorCliente
        {
            public string Cliente { get; set; }
            public int Quantidade { get; set; }
        }

        public class MovimentacaoPorTipoMovimentacao
        {
            public Movimentacao.ETipoMovimentacao TipoMovimentacao { get; set; }
            public int Quantidade { get; set; }
        }

        public class SumarioImportacaoExportacao
        {
            public Conteiner.ECategoria Categoria { get; set; }
            public int Quantidade { get; set; }
        }

    }
}
