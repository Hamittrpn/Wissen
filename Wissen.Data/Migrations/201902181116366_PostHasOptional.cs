namespace Wissen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostHasOptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            AlterColumn("dbo.Posts", "CategoryId", c => c.Int());
            CreateIndex("dbo.Posts", "CategoryId");
            AddForeignKey("dbo.Posts", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            AlterColumn("dbo.Posts", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "CategoryId");
            AddForeignKey("dbo.Posts", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
