namespace webappiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yypp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            AddColumn("dbo.Employees", "CityId", c => c.Int());
            CreateIndex("dbo.Employees", "CityId");
            AddForeignKey("dbo.Employees", "CityId", "dbo.Cities", "CityId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "CityId", "dbo.Cities");
            DropIndex("dbo.Employees", new[] { "CityId" });
            DropColumn("dbo.Employees", "CityId");
            DropTable("dbo.Cities");
        }
    }
}
