namespace FilmWorldCinemaProject_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednewrelationss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cinemas", "Hall_Id", c => c.Int());
            AddColumn("dbo.Halls", "CinemaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cinemas", "Hall_Id");
            AddForeignKey("dbo.Cinemas", "Hall_Id", "dbo.Halls", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cinemas", "Hall_Id", "dbo.Halls");
            DropIndex("dbo.Cinemas", new[] { "Hall_Id" });
            DropColumn("dbo.Halls", "CinemaId");
            DropColumn("dbo.Cinemas", "Hall_Id");
        }
    }
}
