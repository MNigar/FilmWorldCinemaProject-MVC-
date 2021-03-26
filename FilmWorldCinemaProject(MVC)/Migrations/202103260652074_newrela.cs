namespace FilmWorldCinemaProject_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newrela : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cinemas", "Cinema_Id", "dbo.Cinemas");
            DropIndex("dbo.Cinemas", new[] { "Cinema_Id" });
            DropColumn("dbo.Cinemas", "Cinema_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cinemas", "Cinema_Id", c => c.Int());
            CreateIndex("dbo.Cinemas", "Cinema_Id");
            AddForeignKey("dbo.Cinemas", "Cinema_Id", "dbo.Cinemas", "Id");
        }
    }
}
