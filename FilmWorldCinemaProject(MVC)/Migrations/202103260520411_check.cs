namespace FilmWorldCinemaProject_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Halls", "CinemaId", "dbo.Cinemas");
            DropIndex("dbo.Halls", new[] { "CinemaId" });
            DropColumn("dbo.Halls", "CinemaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Halls", "CinemaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Halls", "CinemaId");
            AddForeignKey("dbo.Halls", "CinemaId", "dbo.Cinemas", "Id", cascadeDelete: true);
        }
    }
}
