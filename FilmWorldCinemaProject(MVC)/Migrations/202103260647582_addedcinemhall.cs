namespace FilmWorldCinemaProject_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcinemhall : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CinemaHalls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CinemaId = c.Int(nullable: false),
                        HallId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cinemas", t => t.CinemaId, cascadeDelete: true)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .Index(t => t.CinemaId)
                .Index(t => t.HallId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CinemaHalls", "HallId", "dbo.Halls");
            DropForeignKey("dbo.CinemaHalls", "CinemaId", "dbo.Cinemas");
            DropIndex("dbo.CinemaHalls", new[] { "HallId" });
            DropIndex("dbo.CinemaHalls", new[] { "CinemaId" });
            DropTable("dbo.CinemaHalls");
        }
    }
}
