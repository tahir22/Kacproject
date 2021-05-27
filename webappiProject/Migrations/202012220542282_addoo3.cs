namespace webappiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addoo3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalarModels",
                c => new
                    {
                        SalarModelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Salary = c.Double(nullable: false),
                        Month = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalarModelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SalarModels");
        }
    }
}
