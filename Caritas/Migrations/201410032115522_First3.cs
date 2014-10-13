namespace Caritas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Contents", new[] { "UserID" });
            DropColumn("dbo.Contents", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Contents", "UserID");
            AddForeignKey("dbo.Contents", "UserID", "dbo.AspNetUsers", "Id");
        }
    }
}
