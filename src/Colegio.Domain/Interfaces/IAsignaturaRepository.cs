using Colegio.Domain.Entities;
using System.Collections.Generic;

namespace Colegio.Domain.Repositories.Interfaces
{
    public interface IAsignaturaRepository
    {
        void Insert(AsignaturaEntity entity);
        void Update(AsignaturaEntity entity);
        void Delete(int id);
        AsignaturaEntity GetById(int id);
        List<AsignaturaEntity> GetAll();
    }
}
