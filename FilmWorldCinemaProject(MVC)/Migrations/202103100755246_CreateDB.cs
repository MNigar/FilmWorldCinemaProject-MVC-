namespace FilmWorldCinemaProject_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FilmCountries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilmId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .Index(t => t.FilmId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PublicationDate = c.DateTime(nullable: false),
                        Link = c.String(),
                        Duration = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FilmJanrs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilmId = c.Int(nullable: false),
                        JanrId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .ForeignKey("dbo.Janrs", t => t.JanrId, cascadeDelete: true)
                .Index(t => t.FilmId)
                .Index(t => t.JanrId);
            
            CreateTable(
                "dbo.Janrs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmJanrs", "JanrId", "dbo.Janrs");
            DropForeignKey("dbo.FilmJanrs", "FilmId", "dbo.Films");
            DropForeignKey("dbo.FilmCountries", "FilmId", "dbo.Films");
            DropForeignKey("dbo.FilmCountries", "CountryId", "dbo.Countries");
            DropIndex("dbo.FilmJanrs", new[] { "JanrId" });
            DropIndex("dbo.FilmJanrs", new[] { "FilmId" });
            DropIndex("dbo.FilmCountries", new[] { "CountryId" });
            DropIndex("dbo.FilmCountries", new[] { "FilmId" });
            DropTable("dbo.Janrs");
            DropTable("dbo.FilmJanrs");
            DropTable("dbo.Films");
            DropTable("dbo.FilmCountries");
            DropTable("dbo.Countries");
        }
    }
}
