namespace FilmWorldCinemaProject_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednotnull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Films", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Films", "Link", c => c.String(nullable: false));
            AlterColumn("dbo.Films", "Duration", c => c.String(nullable: false));
            AlterColumn("dbo.Janrs", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Janrs", "Name", c => c.String());
            AlterColumn("dbo.Films", "Duration", c => c.String());
            AlterColumn("dbo.Films", "Link", c => c.String());
            AlterColumn("dbo.Films", "Name", c => c.String());
            AlterColumn("dbo.Countries", "Name", c => c.String());
        }
    }
}
