namespace FilmWorldCinemaProject_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednewrelationssd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cinemas", "Hall_Id", "dbo.Halls");
            DropIndex("dbo.Cinemas", new[] { "Hall_Id" });
            AddColumn("dbo.Cinemas", "Cinema_Id", c => c.Int());
            AddColumn("dbo.Halls", "Cinema_Id", c => c.Int());
            CreateIndex("dbo.Cinemas", "Cinema_Id");
            CreateIndex("dbo.Halls", "Cinema_Id");
            AddForeignKey("dbo.Cinemas", "Cinema_Id", "dbo.Cinemas", "Id");
            AddForeignKey("dbo.Halls", "Cinema_Id", "dbo.Cinemas", "Id");
            DropColumn("dbo.Cinemas", "Hall_Id");
            DropColumn("dbo.Halls", "CinemaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Halls", "CinemaId", c => c.Int(nullable: false));
            AddColumn("dbo.Cinemas", "Hall_Id", c => c.Int());
            DropForeignKey("dbo.Halls", "Cinema_Id", "dbo.Cinemas");
            DropForeignKey("dbo.Cinemas", "Cinema_Id", "dbo.Cinemas");
            DropIndex("dbo.Halls", new[] { "Cinema_Id" });
            DropIndex("dbo.Cinemas", new[] { "Cinema_Id" });
            DropColumn("dbo.Halls", "Cinema_Id");
            DropColumn("dbo.Cinemas", "Cinema_Id");
            CreateIndex("dbo.Cinemas", "Hall_Id");
            AddForeignKey("dbo.Cinemas", "Hall_Id", "dbo.Halls", "Id");
        }
    }
}
