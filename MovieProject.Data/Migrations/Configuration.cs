namespace MovieProject.Data.Migrations
{
    using MovieProject.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieProject.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieProject.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            Movie Movie1 = new Movie { Title = "Armageddon", Summary = "Bruce Willis saves the world. Again.", ImageUrl = "http://www.studiosystemnews.com/wp-content/uploads/2013/06/armageddon-poster.jpg" };
            Movie Movie2 = new Movie { Title = "5th Element", Summary = "Bruce Willis saves the world with hair. Again.", ImageUrl = "http://2.bp.blogspot.com/-6P-3QgANlFY/UClxCfmUWPI/AAAAAAAALbY/PIX-FP7ujaM/s640/The+Fifth+Element+(1997)+4.jpg" };
            Movie Movie3 = new Movie { Title = "Die Hard", Summary = "Bruce Willis saves the world from bad German actors.", ImageUrl = "http://edge-images.rifftrax.com/files/iriffs-posters/die-hard-poster.jpg" };
            context.Movies.AddOrUpdate(
                m => m.Title,
                Movie1,
                Movie2,
                Movie3
                );
            context.SaveChanges();
            Actor Actor1 = new Actor { Name = "Bruce Willis" };
            context.Actors.AddOrUpdate(
                a => a.Name,
                Actor1
                );
            context.SaveChanges();
            context.MovieActors.AddOrUpdate(
                m => m.Id,
                new MovieActor{Id =1, MovieId = Movie1.Id, ActorId = Actor1.Id},
                new MovieActor{Id =1, MovieId = Movie2.Id, ActorId = Actor1.Id},
                new MovieActor{Id =1, MovieId = Movie3.Id, ActorId = Actor1.Id}
            );

        }
    }
}
