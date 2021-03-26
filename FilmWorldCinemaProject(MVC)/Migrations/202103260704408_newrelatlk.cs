namespace FilmWorldCinemaProject_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newrelatlk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CinemaHalls", "CinemaId", "dbo.Cinemas");
            DropForeignKey("dbo.CinemaHalls", "HallId", "dbo.Halls");
            DropIndex("dbo.CinemaHalls", new[] { "CinemaId" });
            DropIndex("dbo.CinemaHalls", new[] { "HallId" });
            RenameColumn(table: "dbo.CinemaHalls", name: "CinemaId", newName: "Cinema_Id");
            RenameColumn(table: "dbo.CinemaHalls", name: "HallId", newName: "Hall_Id");
            AddColumn("dbo.CinemaHalls", "n", c => c.String());
            AlterColumn("dbo.CinemaHalls", "Cinema_Id", c => c.Int());
            AlterColumn("dbo.CinemaHalls", "Hall_Id", c => c.Int());
            CreateIndex("dbo.CinemaHalls", "Cinema_Id");
            CreateIndex("dbo.CinemaHalls", "Hall_Id");
            AddForeignKey("dbo.CinemaHalls", "Cinema_Id", "dbo.Cinemas", "Id");
            AddForeignKey("dbo.CinemaHalls", "Hall_Id", "dbo.Halls", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CinemaHalls", "Hall_Id", "dbo.Halls");
            DropForeignKey("dbo.CinemaHalls", "Cinema_Id", "dbo.Cinemas");
            DropIndex("dbo.CinemaHalls", new[] { "Hall_Id" });
            DropIndex("dbo.CinemaHalls", new[] { "Cinema_Id" });
            AlterColumn("dbo.CinemaHalls", "Hall_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.CinemaHalls", "Cinema_Id", c => c.Int(nullable: false));
            DropColumn("dbo.CinemaHalls", "n");
            RenameColumn(table: "dbo.CinemaHalls", name: "Hall_Id", newName: "HallId");
            RenameColumn(table: "dbo.CinemaHalls", name: "Cinema_Id", newName: "CinemaId");
            CreateIndex("dbo.CinemaHalls", "HallId");
            CreateIndex("dbo.CinemaHalls", "CinemaId");
            AddForeignKey("dbo.CinemaHalls", "HallId", "dbo.Halls", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CinemaHalls", "CinemaId", "dbo.Cinemas", "Id", cascadeDelete: true);
        }
    }
}
