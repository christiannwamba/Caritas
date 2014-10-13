namespace Caritas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First61 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Spies", "Page", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Spies", "Page");
        }
    }
}
