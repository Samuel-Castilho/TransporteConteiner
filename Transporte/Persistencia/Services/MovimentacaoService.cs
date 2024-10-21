using Models;
using Transporte.Persistencia.Context;
using Transporte.Persistencia.Services.Interfaces;

namespace Transporte.Persistencia.Services
{
    public class MovimentacaoService : BaseService<Movimentacao> , IMovimentacaoService
    {

        public MovimentacaoService(TransporteContext db) : base(db)
        {
            
        }
    }
}
