namespace FilmWorldCinemaProject_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newrelatlkf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CinemaHalls", "Hall_Id", "dbo.Halls");
            DropForeignKey("dbo.CinemaHalls", "Cinema_Id", "dbo.Cinemas");
            DropIndex("dbo.CinemaHalls", new[] { "Cinema_Id" });
            DropIndex("dbo.CinemaHalls", new[] { "Hall_Id" });
            RenameColumn(table: "dbo.CinemaHalls", name: "Hall_Id", newName: "HallId");
            RenameColumn(table: "dbo.CinemaHalls", name: "Cinema_Id", newName: "CinemaId");
            AlterColumn("dbo.CinemaHalls", "CinemaId", c => c.Int(nullable: false));
            AlterColumn("dbo.CinemaHalls", "HallId", c => c.Int(nullable: false));
            CreateIndex("dbo.CinemaHalls", "CinemaId");
            CreateIndex("dbo.CinemaHalls", "HallId");
            AddForeignKey("dbo.CinemaHalls", "HallId", "dbo.Halls", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CinemaHalls", "CinemaId", "dbo.Cinemas", "Id", cascadeDelete: true);
            DropColumn("dbo.CinemaHalls", "n");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CinemaHalls", "n", c => c.String());
            DropForeignKey("dbo.CinemaHalls", "CinemaId", "dbo.Cinemas");
            DropForeignKey("dbo.CinemaHalls", "HallId", "dbo.Halls");
            DropIndex("dbo.CinemaHalls", new[] { "HallId" });
            DropIndex("dbo.CinemaHalls", new[] { "CinemaId" });
            AlterColumn("dbo.CinemaHalls", "HallId", c => c.Int());
            AlterColumn("dbo.CinemaHalls", "CinemaId", c => c.Int());
            RenameColumn(table: "dbo.CinemaHalls", name: "CinemaId", newName: "Cinema_Id");
            RenameColumn(table: "dbo.CinemaHalls", name: "HallId", newName: "Hall_Id");
            CreateIndex("dbo.CinemaHalls", "Hall_Id");
            CreateIndex("dbo.CinemaHalls", "Cinema_Id");
            AddForeignKey("dbo.CinemaHalls", "Cinema_Id", "dbo.Cinemas", "Id");
            AddForeignKey("dbo.CinemaHalls", "Hall_Id", "dbo.Halls", "Id");
        }
    }
}
