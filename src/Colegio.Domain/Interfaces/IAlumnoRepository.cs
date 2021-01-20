using Colegio.Domain.Entities;
using System.Collections.Generic;

namespace Colegio.Domain.Repositories.Interfaces
{
    public interface IAlumnoRepository
    {
        void Insert(AlumnoEntity entity);
        void Update(AlumnoEntity entity);
        void Delete(int id);
        AlumnoEntity GetById(int id);
        List<AlumnoEntity> GetAll();
        List<ReporteCalificacionesEntity> GetReport();
    }
}
