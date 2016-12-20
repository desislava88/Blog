namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comments_Add_PostedBy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Comment", new[] { "UserId" });
            AddColumn("dbo.Comment", "PostedBy", c => c.String());
            DropColumn("dbo.Comment", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Comment", "PostedBy");
            CreateIndex("dbo.Comment", "UserId");
            AddForeignKey("dbo.Comment", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
