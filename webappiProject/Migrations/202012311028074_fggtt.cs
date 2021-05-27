namespace webappiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fggtt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DatabaseAndHTMLModels",
                c => new
                    {
                        MyProperty = c.Int(nullable: false, identity: true),
                        Data = c.String(),
                        DataHtml = c.String(),
                    })
                .PrimaryKey(t => t.MyProperty);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DatabaseAndHTMLModels");
        }
    }
}
