namespace VideoLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_IsSubscribedToNewsLetter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubsrcibedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubsrcibedToNewsletter");
        }
    }
}
