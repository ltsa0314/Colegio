using Colegio.Domain.Data;
using Colegio.Domain.Entities;
using Colegio.Domain.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Colegio.TestUnit.Repositories
{
    public class ProfesorRepositoryTest

    {
        [Fact]
        public void Insert()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<ColegioDbContext>();
            var options = builder.UseInMemoryDatabase("ColegioDb").Options;
            using var context = new ColegioDbContext(options);
            context.Database.EnsureDeleted();

            var entity = new ProfesorEntity
            {
                Identificacion = "123456789",
                Nombre = "Pepito",
                Apellido = "Perez",
                Edad = 20,
                Direccion = "Calle falsa 123",
                Telefono = 12345

            };
            var repository = new ProfesorRepository(context);

            //Act
            repository.Insert(entity);

            //Assert
            Assert.True(entity.Id > 0);


        }

        [Fact]
        public void Update()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<ColegioDbContext>();
            var options = builder.UseInMemoryDatabase("ColegioDb").Options;
            using var context = new ColegioDbContext(options);
            context.Database.EnsureDeleted();

            var entity = new ProfesorEntity
            {
                Identificacion = "123456789",
                Nombre = "Pepito",
                Apellido = "Perez",
                Edad = 20,
                Direccion = "Calle falsa 123",
                Telefono = 12345

            };
            var repository = new ProfesorRepository(context);


            repository.Insert(entity);

            //Act
            var entityUpdate = repository.GetById(entity.Id);
            entityUpdate.Nombre = "pepo";

            repository.Update(entityUpdate);

            //assert
            var entityUpdated = repository.GetById(entity.Id);
            Assert.True(entityUpdated.Nombre == "pepo");
        }


        [Fact]
        public void Delete()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<ColegioDbContext>();
            var options = builder.UseInMemoryDatabase("ColegioDb").Options;
            using var context = new ColegioDbContext(options);
            context.Database.EnsureDeleted();

            var entity = new ProfesorEntity
            {
                Identificacion = "123456789",
                Nombre = "Pepito",
                Apellido = "Perez",
                Edad = 20,
                Direccion = "Calle falsa 123",
                Telefono = 12345

            };
            var repository = new ProfesorRepository(context);


            repository.Insert(entity);

            //Act
            repository.Delete(entity.Id);


            //assert
            var entityDeleted = repository.GetById(entity.Id);
            Assert.True(entityDeleted == null);
        }

        [Fact]
        public void GetById()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<ColegioDbContext>();
            var options = builder.UseInMemoryDatabase("ColegioDb").Options;
            using var context = new ColegioDbContext(options);
            context.Database.EnsureDeleted();

            var entity = new ProfesorEntity
            {
                Identificacion = "123456789",
                Nombre = "Pepito",
                Apellido = "Perez",
                Edad = 20,
                Direccion = "Calle falsa 123",
                Telefono = 12345

            };
            var repository = new ProfesorRepository(context);


            repository.Insert(entity);

            //Act
            var entityResult = repository.GetById(entity.Id);


            //assert
            Assert.True(entityResult.Id > 0);
        }

        [Fact]
        public void GetByAll()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<ColegioDbContext>();
            var options = builder.UseInMemoryDatabase("ColegioDb").Options;
            using var context = new ColegioDbContext(options);
            context.Database.EnsureDeleted();

            var entity = new ProfesorEntity
            {
                Identificacion = "123456789",
                Nombre = "Pepito",
                Apellido = "Perez",
                Edad = 20,
                Direccion = "Calle falsa 123",
                Telefono = 12345

            };
            var repository = new ProfesorRepository(context);


            repository.Insert(entity);

            //Act
            var entities = repository.GetAll();


            //assert
            Assert.True(entities.Count > 0);
        }
    }
}
