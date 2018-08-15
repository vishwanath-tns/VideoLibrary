namespace VideoLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyDataAnnotationsOnGenreAndMovieTables : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Genres",
            //    c => new
            //        {
            //            Id = c.Byte(nullable: false),
            //            Name = c.String(nullable: false, maxLength: 255),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateIndex("dbo.Movies", "GenreId");
            //AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            //DropIndex("dbo.Movies", new[] { "GenreId" });
            //DropTable("dbo.Genres");
        }
    }
}
