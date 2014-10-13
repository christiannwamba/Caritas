namespace Caritas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pub1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publications", "Title", c => c.String());
            AddColumn("dbo.Publications", "Author", c => c.String());
            AddColumn("dbo.Publications", "AuthorRegNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publications", "AuthorRegNo");
            DropColumn("dbo.Publications", "Author");
            DropColumn("dbo.Publications", "Title");
        }
    }
}
