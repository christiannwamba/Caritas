namespace Caritas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactUs", "Phone", c => c.String(nullable: false));
            DropColumn("dbo.ContactUs", "ContactType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactUs", "ContactType", c => c.String(nullable: false));
            DropColumn("dbo.ContactUs", "Phone");
        }
    }
}
