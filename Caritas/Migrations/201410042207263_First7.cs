namespace Caritas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactUs", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactUs", "Name");
        }
    }
}
