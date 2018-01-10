namespace NetLaboratory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.sr13_228010_A",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sr13_228010_C",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        IdArticle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.sr13_228010_A", t => t.IdArticle, cascadeDelete: true)
                .Index(t => t.IdArticle);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.sr13_228010_C", "IdArticle", "dbo.sr13_228010_A");
            DropIndex("dbo.sr13_228010_C", new[] { "IdArticle" });
            DropTable("dbo.sr13_228010_C");
            DropTable("dbo.sr13_228010_A");
        }
    }
}
