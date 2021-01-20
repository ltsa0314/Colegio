﻿// <auto-generated />
using Colegio.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Colegio.Infraestructure.Data.Migrations
{
    [DbContext(typeof(ColegioDbContext))]
    [Migration("20210120005343_v1.0")]
    partial class v10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Colegio")
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Colegio.Domain.Entities.AlumnoAsignaturaEntity", b =>
                {
                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<int>("AsignaturaId")
                        .HasColumnType("int");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<decimal>("CalificacionFinal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AlumnoId", "AsignaturaId", "Ano");

                    b.HasIndex("AsignaturaId");

                    b.ToTable("AlumnoAsignatura");
                });

            modelBuilder.Entity("Colegio.Domain.Entities.AlumnoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(21)")
                        .HasMaxLength(21);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Alumno");
                });

            modelBuilder.Entity("Colegio.Domain.Entities.AsignaturaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Asignatura");
                });

            modelBuilder.Entity("Colegio.Domain.Entities.ProfesorAsignaturaEntity", b =>
                {
                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.Property<int>("AsignaturaId")
                        .HasColumnType("int");

                    b.HasKey("ProfesorId");

                    b.HasIndex("AsignaturaId")
                        .IsUnique();

                    b.ToTable("ProfesorAsignatura");
                });

            modelBuilder.Entity("Colegio.Domain.Entities.ProfesorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(21)")
                        .HasMaxLength(21);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("Colegio.Domain.Entities.AlumnoAsignaturaEntity", b =>
                {
                    b.HasOne("Colegio.Domain.Entities.AlumnoEntity", "Alumno")
                        .WithMany("AlumnoAsignaturas")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Colegio.Domain.Entities.AsignaturaEntity", "Asignatura")
                        .WithMany("AlumnoAsignaturas")
                        .HasForeignKey("AsignaturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Colegio.Domain.Entities.ProfesorAsignaturaEntity", b =>
                {
                    b.HasOne("Colegio.Domain.Entities.AsignaturaEntity", "Asignatura")
                        .WithOne("ProfesorAsignatura")
                        .HasForeignKey("Colegio.Domain.Entities.ProfesorAsignaturaEntity", "AsignaturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Colegio.Domain.Entities.ProfesorEntity", "Profesor")
                        .WithOne("Asignatura")
                        .HasForeignKey("Colegio.Domain.Entities.ProfesorAsignaturaEntity", "ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
