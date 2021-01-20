using Colegio.Domain.Entities;
using System.Collections.Generic;

namespace Colegio.Domain.Repositories.Interfaces
{
    public interface IAlumnoAsignaturaRepository
    {
        void Insert(AlumnoAsignaturaEntity entity);
        void Update(AlumnoAsignaturaEntity entity);
        void Delete(int id);
        AlumnoAsignaturaEntity GetById(int alumnoId,int asignaturaId,int ano);
        List<AlumnoAsignaturaEntity> GetAll(int alumnoid);
        bool ExistsByAlumnoId(int alumnoId);
    }
}
