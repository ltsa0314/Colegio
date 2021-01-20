using Colegio.Domain.Entities;
using System.Collections.Generic;

namespace Colegio.Domain.Repositories.Interfaces
{
    public interface IProfesorRepository
    {
        void Insert(ProfesorEntity entity);
        void Update(ProfesorEntity entity);
        void Delete(int id);
        ProfesorEntity GetById(int id);
        List<ProfesorEntity> GetAll();

    }
}
