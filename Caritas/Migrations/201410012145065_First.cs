namespace Caritas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        ContactUsID = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        ContactType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ContactUsID);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        Content1 = c.String(nullable: false),
                        ContentType = c.String(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ContentID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        FirstName = c.String(),
                        Title = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        DateJoined = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Event1 = c.String(nullable: false),
                        Caption = c.String(nullable: false, maxLength: 100),
                        DateAdded = c.DateTime(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        News1 = c.String(nullable: false),
                        Caption = c.String(nullable: false, maxLength: 100),
                        DateAdded = c.DateTime(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.NewsID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        PublicationID = c.Int(nullable: false, identity: true),
                        Dir = c.String(),
                        UserID = c.String(maxLength: 128),
                        DateUploaded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PublicationID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        FacultyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Faculties", t => t.FacultyID, cascadeDelete: true)
                .Index(t => t.FacultyID);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyID = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(nullable: false, maxLength: 50),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "FacultyID", "dbo.Faculties");
            DropForeignKey("dbo.Publications", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.News", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contents", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Departments", new[] { "FacultyID" });
            DropIndex("dbo.Publications", new[] { "UserID" });
            DropIndex("dbo.News", new[] { "UserID" });
            DropIndex("dbo.Events", new[] { "UserID" });
            DropIndex("dbo.Contents", new[] { "UserID" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropTable("dbo.Faculties");
            DropTable("dbo.Departments");
            DropTable("dbo.Publications");
            DropTable("dbo.News");
            DropTable("dbo.Events");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Contents");
            DropTable("dbo.ContactUs");
        }
    }
}
