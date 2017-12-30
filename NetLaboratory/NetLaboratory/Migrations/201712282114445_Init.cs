namespace NetLaboratory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false),
                        DayCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 200),
                        DayCreated = c.DateTime(nullable: false),
                        IdArticle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.IdArticle, cascadeDelete: true)
                .Index(t => t.IdArticle);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "IdArticle", "dbo.Articles");
            DropIndex("dbo.Comments", new[] { "IdArticle" });
            DropTable("dbo.Comments");
            DropTable("dbo.Articles");
        }
    }
}
