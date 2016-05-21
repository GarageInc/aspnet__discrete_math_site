namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.String(maxLength: 128),
                        Karma = c.Int(nullable: false),
                        Text = c.String(),
                        ParentId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        AddDateTime = c.DateTime(nullable: false),
                        ReqId = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                        MathTask_Id = c.Int(),
                        ApplicationUser_Id2 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id1)
                .ForeignKey("dbo.MathTasks", t => t.MathTask_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id2)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.MathTaskSolutions", t => t.ReqId)
                .Index(t => t.AuthorId)
                .Index(t => t.ReqId)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id1)
                .Index(t => t.MathTask_Id)
                .Index(t => t.ApplicationUser_Id2);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        Karma = c.Int(nullable: false),
                        LastVisition = c.DateTime(nullable: false),
                        StudentGroupId = c.Int(),
                        RegistrationDate = c.DateTime(nullable: false),
                        UserInfo = c.String(),
                        IsBlocked = c.Boolean(nullable: false),
                        BlockDate = c.DateTime(nullable: false),
                        BlockReason = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        MathTask_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MathTasks", t => t.MathTask_Id)
                .ForeignKey("dbo.StudentGroups", t => t.StudentGroupId)
                .Index(t => t.StudentGroupId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.MathTask_Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Size = c.Int(nullable: false),
                        Type = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactAdress = c.String(nullable: false, maxLength: 200),
                        AuthorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.RecallMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        AuthorId = c.String(maxLength: 128),
                        Karma = c.Int(nullable: false),
                        ParentId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        AddDateTime = c.DateTime(nullable: false),
                        AboutSite = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                        ApplicationUser_Id2 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id1)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id2)
                .Index(t => t.AuthorId)
                .Index(t => t.UserId)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id1)
                .Index(t => t.ApplicationUser_Id2);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MathTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        LatexCode = c.String(maxLength: 500),
                        DocumentId = c.Int(),
                        AuthorId = c.String(maxLength: 128),
                        MathTaskTypeId = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        SelectedExecutorId = c.String(),
                        StudentsGroupId = c.Int(),
                        Deadline = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        RightRequestSolutionId = c.Int(),
                        RightMathTaskSolution_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .ForeignKey("dbo.MathTaskTypes", t => t.MathTaskTypeId, cascadeDelete: true)
                .ForeignKey("dbo.MathTaskSolutions", t => t.RightMathTaskSolution_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.DocumentId)
                .Index(t => t.AuthorId)
                .Index(t => t.MathTaskTypeId)
                .Index(t => t.RightMathTaskSolution_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.MathTaskTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MathTaskSolutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MathTaskId = c.Int(),
                        DocumentId = c.Int(),
                        AuthorId = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                        IsChecked = c.Boolean(nullable: false),
                        IsRight = c.Boolean(nullable: false),
                        IsOnlineControlWork = c.Boolean(nullable: false),
                        MathTask_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .ForeignKey("dbo.MathTasks", t => t.MathTaskId)
                .ForeignKey("dbo.MathTasks", t => t.MathTask_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.MathTaskId)
                .Index(t => t.DocumentId)
                .Index(t => t.AuthorId)
                .Index(t => t.MathTask_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StudentGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Comments", "ReqId", "dbo.MathTaskSolutions");
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RecallMessages", "ApplicationUser_Id2", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ApplicationUser_Id2", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "StudentGroupId", "dbo.StudentGroups");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RecallMessages", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.MathTaskSolutions", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MathTasks", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MathTasks", "RightMathTaskSolution_Id", "dbo.MathTaskSolutions");
            DropForeignKey("dbo.MathTaskSolutions", "MathTask_Id", "dbo.MathTasks");
            DropForeignKey("dbo.MathTaskSolutions", "MathTaskId", "dbo.MathTasks");
            DropForeignKey("dbo.MathTaskSolutions", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.MathTasks", "MathTaskTypeId", "dbo.MathTaskTypes");
            DropForeignKey("dbo.AspNetUsers", "MathTask_Id", "dbo.MathTasks");
            DropForeignKey("dbo.MathTasks", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Comments", "MathTask_Id", "dbo.MathTasks");
            DropForeignKey("dbo.MathTasks", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RecallMessages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RecallMessages", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RecallMessages", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacts", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Documents", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.MathTaskSolutions", new[] { "MathTask_Id" });
            DropIndex("dbo.MathTaskSolutions", new[] { "AuthorId" });
            DropIndex("dbo.MathTaskSolutions", new[] { "DocumentId" });
            DropIndex("dbo.MathTaskSolutions", new[] { "MathTaskId" });
            DropIndex("dbo.MathTasks", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.MathTasks", new[] { "RightMathTaskSolution_Id" });
            DropIndex("dbo.MathTasks", new[] { "MathTaskTypeId" });
            DropIndex("dbo.MathTasks", new[] { "AuthorId" });
            DropIndex("dbo.MathTasks", new[] { "DocumentId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.RecallMessages", new[] { "ApplicationUser_Id2" });
            DropIndex("dbo.RecallMessages", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.RecallMessages", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.RecallMessages", new[] { "UserId" });
            DropIndex("dbo.RecallMessages", new[] { "AuthorId" });
            DropIndex("dbo.Contacts", new[] { "AuthorId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Documents", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "MathTask_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "StudentGroupId" });
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id2" });
            DropIndex("dbo.Comments", new[] { "MathTask_Id" });
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Comments", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Comments", new[] { "ReqId" });
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.StudentGroups");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.MathTaskSolutions");
            DropTable("dbo.MathTaskTypes");
            DropTable("dbo.MathTasks");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.RecallMessages");
            DropTable("dbo.Contacts");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Documents");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comments");
        }
    }
}
