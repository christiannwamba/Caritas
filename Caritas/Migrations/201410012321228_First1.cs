namespace Caritas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Title", c => c.String(nullable: false));
            AddColumn("dbo.News", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Title");
            DropColumn("dbo.Events", "Title");
        }
    }
}
