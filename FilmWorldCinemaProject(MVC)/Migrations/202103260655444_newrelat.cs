namespace FilmWorldCinemaProject_MVC_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newrelat : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Halls", "Cinema_Id", "dbo.Cinemas");
            DropIndex("dbo.Halls", new[] { "Cinema_Id" });
            DropColumn("dbo.Halls", "Cinema_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Halls", "Cinema_Id", c => c.Int());
            CreateIndex("dbo.Halls", "Cinema_Id");
            AddForeignKey("dbo.Halls", "Cinema_Id", "dbo.Cinemas", "Id");
        }
    }
}
