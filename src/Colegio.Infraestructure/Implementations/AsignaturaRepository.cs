using Colegio.Domain.Data;
using Colegio.Domain.Entities;
using Colegio.Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Colegio.Domain.Repositories.Implementations
{
    public class AsignaturaRepository : IAsignaturaRepository
    {
        private readonly ColegioDbContext _context;

        public AsignaturaRepository(ColegioDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var entity = _context.Asignaturas.Find(id);
            _context.Asignaturas.Remove(entity);
            _context.SaveChanges();
        }

        public List<AsignaturaEntity> GetAll()
        {
            var entities = _context.Asignaturas.ToList();
            return entities;
        }

        public AsignaturaEntity GetById(int id)
        {
            var entity = _context.Asignaturas.Find(id);
            return entity;
        }

        public void Insert(AsignaturaEntity entity)
        {
            _context.Asignaturas.Add(entity);
            _context.SaveChanges();
        }

        public void Update(AsignaturaEntity entity)
        {
            _context.Asignaturas.Update(entity);
            _context.SaveChanges();
        }
    }
}
