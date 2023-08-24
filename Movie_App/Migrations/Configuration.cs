namespace Movie_App.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Movie_App.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Movie_App.Models.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Movie_App.Models.MovieContext context)
        {
            if (!context.registers.Any())
            {
                context.registers.AddOrUpdate(
                new Registers() { UserName = "Oladeji", Email = "oladejiomolabake14@gmail.com", Password = "Admin1234", Role = "Admin" },

            new Registers() { UserName = "Olaniran", Email = "Olaniran4@gmail.com", Password = "Admin12345", Role = "Admin" }
                );
            }
        }
    }
}
