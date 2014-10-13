namespace Caritas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "DateAdded");
        }
    }
}
