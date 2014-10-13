namespace Caritas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pub2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publications", "DepartmentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Publications", "DepartmentID");
            AddForeignKey("dbo.Publications", "DepartmentID", "dbo.Departments", "DepartmentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Publications", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Publications", new[] { "DepartmentID" });
            DropColumn("dbo.Publications", "DepartmentID");
        }
    }
}
