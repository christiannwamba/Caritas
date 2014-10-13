namespace Caritas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class downloads : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Downloads",
                c => new
                    {
                        DownloadsID = c.Int(nullable: false, identity: true),
                        File = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DownloadsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Downloads");
        }
    }
}
