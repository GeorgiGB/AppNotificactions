using Microsoft.EntityFrameworkCore;

namespace AppNotificactions.Data
{
    public class DatosDataContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Datos> Datos{ get; set; }

        protected readonly IConfiguration Configuration;

        public DatosDataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("datosdb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>()
                .ToTable("Topic");

            modelBuilder.Entity<Topic>()
                .HasData(
                new Topic { Id = 1, Name = "test"},
                new Topic { Id = 2, Name = "prueba"}
                );

            modelBuilder.Entity<Datos>()
                .ToTable("Datos");

            modelBuilder.Entity<Datos>()
                .HasData(
                new Datos {Id = 1, Titulo = "Titulo de prueba", Msg = "Texto de prueba", TopicId = 1},
                new Datos { Id = 2, Titulo = "Titulo de prueba", Msg = "Texto de prueba", TopicId = 2}
                );

        }
    }
}
