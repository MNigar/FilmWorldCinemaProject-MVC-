namespace FilmWorldCinemaProject_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddeAboutCinemaTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CinemaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cinemas", t => t.CinemaId, cascadeDelete: true)
                .Index(t => t.CinemaId);
            
            CreateTable(
                "dbo.Rows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HallId = c.Int(nullable: false),
                        RowId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .ForeignKey("dbo.Rows", t => t.RowId, cascadeDelete: true)
                .Index(t => t.HallId)
                .Index(t => t.RowId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "RowId", "dbo.Rows");
            DropForeignKey("dbo.Seats", "HallId", "dbo.Halls");
            DropForeignKey("dbo.Halls", "CinemaId", "dbo.Cinemas");
            DropIndex("dbo.Seats", new[] { "RowId" });
            DropIndex("dbo.Seats", new[] { "HallId" });
            DropIndex("dbo.Halls", new[] { "CinemaId" });
            DropTable("dbo.Seats");
            DropTable("dbo.Rows");
            DropTable("dbo.Halls");
            DropTable("dbo.Cinemas");
        }
    }
}
