namespace Caritas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventDate");
        }
    }
}
