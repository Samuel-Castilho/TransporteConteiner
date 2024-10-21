using Models;
using Transporte.Persistencia.Context;
using Transporte.Persistencia.Services.Interfaces;

namespace Transporte.Persistencia.Services
{
    public class ConteinerService : BaseService<Conteiner> ,  IConteinerService
    {

        public ConteinerService(TransporteContext db) : base(db)
        {
            
        }
    }
}
