namespace NetLaboratory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "DayCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "DayCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "DayCreated");
            DropColumn("dbo.Articles", "DayCreated");
        }
    }
}
