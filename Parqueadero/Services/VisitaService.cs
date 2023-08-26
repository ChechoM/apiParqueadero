using Parqueadero.Data;
using Parqueadero.Services.Interfaces;

namespace Parqueadero.Services
{
    public class VisitaService : IVisitaService
    {
        private  readonly PqDBContext _dbContext;
        public VisitaService(PqDBContext pqDBContext) 
        {
            _dbContext = pqDBContext;
        }
        public string ValidarVisita(long id)
        {
            var visita = _dbContext.Visita.Select(x=> x.Id).Contains(id);
            var Calificacion = _dbContext.Calificaciones.Select(x=> x.IdVisita).Contains(id);

            if(visita)
            {
                if(Calificacion)
                {
                    return "Ya existe una calificacion para esta visita";
                }
                else 
                {
                    return "Ok";
                }
            }
            else
            {
                return "El numero de visita no existe";
            }
        }
    }
}
