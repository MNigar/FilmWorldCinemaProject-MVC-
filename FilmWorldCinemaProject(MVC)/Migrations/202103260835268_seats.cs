namespace FilmWorldCinemaProject_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seats : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Seats", "HallId", "dbo.Halls");
            DropIndex("dbo.Seats", new[] { "HallId" });
            AddColumn("dbo.Seats", "CinemaHallId", c => c.Int(nullable: false));
            CreateIndex("dbo.Seats", "CinemaHallId");
            AddForeignKey("dbo.Seats", "CinemaHallId", "dbo.CinemaHalls", "Id", cascadeDelete: true);
            DropColumn("dbo.Seats", "Name");
            DropColumn("dbo.Seats", "HallId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seats", "HallId", c => c.Int(nullable: false));
            AddColumn("dbo.Seats", "Name", c => c.String());
            DropForeignKey("dbo.Seats", "CinemaHallId", "dbo.CinemaHalls");
            DropIndex("dbo.Seats", new[] { "CinemaHallId" });
            DropColumn("dbo.Seats", "CinemaHallId");
            CreateIndex("dbo.Seats", "HallId");
            AddForeignKey("dbo.Seats", "HallId", "dbo.Halls", "Id", cascadeDelete: true);
        }
    }
}
