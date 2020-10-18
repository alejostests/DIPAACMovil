using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class DipaacContext : DbContext
    {
        public DipaacContext()
        {
        }

        public DipaacContext(DbContextOptions<DipaacContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cuestionario> Cuestionarios { get; set; }
        public virtual DbSet<Respuesta> Respuestas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "Data Source=MSI\\SQLEXPRESS;Integrated Security=True;MultipleActiveResultSets=True;Initial Catalog=dipaac;";

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuestionario>(entity =>
            {
                entity.ToTable("Cuestionario", "Dipaac");

                entity.Property(e => e.Tipo).IsRequired();

                entity.Property(e => e.Date).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Calificacion).IsRequired();

                entity.HasOne(e => e.Usuario).WithMany(e => e.Cuestionarios).HasForeignKey(e => e.UsuarioId);
            });

            modelBuilder.Entity<Respuesta>(entity =>
            {
                entity.ToTable("Respuesta", "Dipaac");

                entity.Property(e => e.EsCorrecta).IsRequired();

                entity.Property(e => e.Pregunta).IsRequired().HasMaxLength(100);
                
                entity.Property(e => e.RespuestaIngresada).IsRequired().HasMaxLength(32);

                entity.HasOne(e => e.Cuestionario).WithMany(e => e.Respuestas).HasForeignKey(e => e.CuestionarioId);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario", "Dipaac");

                entity.Property(e => e.NombreUsuario).IsRequired().HasMaxLength(16);

                entity.Property(e => e.NombreCompleto).IsRequired().HasMaxLength(32);

                entity.Property(e => e.Edad).IsRequired();

                entity.Property(e => e.Contraseña).IsRequired().HasMaxLength(128);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            // ignored
        }
    }
}