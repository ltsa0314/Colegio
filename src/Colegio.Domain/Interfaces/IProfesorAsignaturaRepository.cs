using Colegio.Domain.Entities;
using System.Collections.Generic;

namespace Colegio.Domain.Repositories.Interfaces
{
    public interface IProfesorAsignaturaRepository
    {
        void Insert(ProfesorAsignaturaEntity entity);
        void Update(ProfesorAsignaturaEntity entity);
        void Delete(int id);
        ProfesorAsignaturaEntity GetById(int id);
        List<ProfesorAsignaturaEntity> GetAll();
    }
}
