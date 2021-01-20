using Colegio.Domain.Data;
using Colegio.Domain.Entities;
using Colegio.Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Colegio.Domain.Repositories.Implementations
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly ColegioDbContext _context;

        public ProfesorRepository(ColegioDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var entity = _context.Profesores.Find(id);
            _context.Profesores.Remove(entity);
            _context.SaveChanges();
        }

        public List<ProfesorEntity> GetAll()
        {
            var entities = _context.Profesores.ToList();
            return entities;
        }

        public ProfesorEntity GetById(int id)
        {
            var entity = _context.Profesores.Find(id);
            return entity;
        }

        public void Insert(ProfesorEntity entity)
        {
            _context.Profesores.Add(entity);
            _context.SaveChanges();
        }

        public void Update(ProfesorEntity entity)
        {
            _context.Profesores.Update(entity);
            _context.SaveChanges();
        }
    }
}
