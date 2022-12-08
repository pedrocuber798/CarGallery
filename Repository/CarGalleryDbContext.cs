using CarGallery.Model;
using Microsoft.EntityFrameworkCore;

namespace CarGallery.Repository {
    public class CarGalleryDbContext: DbContext {

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Car> Cars { get; set; }

        public CarGalleryDbContext(DbContextOptions<CarGalleryDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 1, Name = "Porshe"});
            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 2, Name = "Ferrari" });
            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 3, Name = "Ford" });

            modelBuilder.Entity<Car>().HasData(new Car {
                Id = 1,
                Name = "Porsche 911 Turbo",
                ShortDescription = "Porsche 911 Turbo S",
                LongDescription = "Sempre que um carro apresenta um comportamento irrepreensível, é difícil não nos perguntarmos como será possível fazer algo melhor em uma futura geração. Desde a primeira edição do 911 Turbo, em 1975, porém, os engenheiros da Porsche vêm conseguindo essa insuspeita superação e desta vez não foi diferente.",
                BrandId = 1,
                ImageUrl = "/assets/porsche/porsche_911_Turbo.jpg",
                ThumbnailUrl = "/assets/porsche/porsche_911_Turbo_small.jpg",
            });

            modelBuilder.Entity<Car>().HasData(new Car {
                Id = 2,
                Name = "Ford Mustang",
                ShortDescription = "O melhor pony car",
                LongDescription = "O Mustang GT é absolutamente a melhor forma de começar o dia, já que seu motor é uma joia. O V8 ainda mantém o nome de Coyote, mas não é quieto como o anterior. O motor esbraveja como o melhor muscle car de todos os tempos.",
                BrandId = 3,
                ImageUrl = "/assets/ford/ford_mustang.jpg",
                ThumbnailUrl = "/assets/ford/ford_mustang_small.jpg",
            });
        }
    }
}
