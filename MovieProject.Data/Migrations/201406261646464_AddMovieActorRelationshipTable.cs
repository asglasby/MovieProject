namespace MovieProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieActorRelationshipTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: false)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: false)
                .Index(t => t.MovieId)
                .Index(t => t.ActorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieActors", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieActors", "ActorId", "dbo.Actors");
            DropIndex("dbo.MovieActors", new[] { "ActorId" });
            DropIndex("dbo.MovieActors", new[] { "MovieId" });
            DropTable("dbo.MovieActors");
            DropTable("dbo.Actors");
        }
    }
}
