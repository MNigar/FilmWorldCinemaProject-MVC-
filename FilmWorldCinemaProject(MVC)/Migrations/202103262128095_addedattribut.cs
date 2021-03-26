namespace FilmWorldCinemaProject_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedattribut : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cinemas", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Halls", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Rows", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rows", "Name", c => c.String());
            AlterColumn("dbo.Halls", "Name", c => c.String());
            AlterColumn("dbo.Cinemas", "Name", c => c.String());
        }
    }
}
