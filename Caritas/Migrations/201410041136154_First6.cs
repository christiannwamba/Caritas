namespace Caritas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Spies",
                c => new
                    {
                        SpyID = c.Int(nullable: false, identity: true),
                        IPAddress = c.String(),
                        DateSpied = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SpyID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Spies");
        }
    }
}
