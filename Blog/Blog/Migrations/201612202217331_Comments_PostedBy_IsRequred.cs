namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comments_PostedBy_IsRequred : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comment", "PostedBy", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comment", "PostedBy", c => c.String());
        }
    }
}
