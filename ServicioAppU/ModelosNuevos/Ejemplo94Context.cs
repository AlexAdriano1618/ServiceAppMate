using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServicioAppU.ModelosNuevos
{
    public partial class Ejemplo94Context : DbContext
    {
        public Ejemplo94Context(DbContextOptions<Ejemplo94Context> options)
           : base(options)
        {

        }
        public virtual DbSet<Codigo> Codigo { get; set; }
        public virtual DbSet<Preguntas> Preguntas { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
////                optionsBuilder.UseSqlServer(@"Server=Ejemplo94.mssql.somee.com;Database=Ejemplo94;User Id=Alex_Adriano_SQLLogin_1;password=thp94lf723;MultipleActiveResultSets=true");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Codigo>(entity =>
            {
                entity.HasKey(e => e.IdCodigo);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Preguntas>(entity =>
            {
                entity.HasKey(e => e.IdPreguntas);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCodigoNavigation)
                    .WithMany(p => p.Preguntas)
                    .HasForeignKey(d => d.IdCodigo)
                    .HasConstraintName("FK_Preguntas_Codigo");
            });
        }
    }
}
