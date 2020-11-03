namespace BOL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUserServiceRelationAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "CompanyId", c => c.Int(nullable: false));
            AddColumn("dbo.Services", "categoryId", c => c.Int(nullable: false));
            AddColumn("dbo.UserServices", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.UserServices", "ServiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Services", "CompanyId");
            CreateIndex("dbo.Services", "categoryId");
            CreateIndex("dbo.UserServices", "UserId");
            CreateIndex("dbo.UserServices", "ServiceId");
            AddForeignKey("dbo.Services", "categoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Services", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserServices", "ServiceId", "dbo.Services", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserServices", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserServices", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Services", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Services", "categoryId", "dbo.Categories");
            DropIndex("dbo.UserServices", new[] { "ServiceId" });
            DropIndex("dbo.UserServices", new[] { "UserId" });
            DropIndex("dbo.Services", new[] { "categoryId" });
            DropIndex("dbo.Services", new[] { "CompanyId" });
            DropColumn("dbo.UserServices", "ServiceId");
            DropColumn("dbo.UserServices", "UserId");
            DropColumn("dbo.Services", "categoryId");
            DropColumn("dbo.Services", "CompanyId");
        }
    }
}
