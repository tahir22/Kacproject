namespace webappiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ffgg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Picmodels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Path = c.String(),
                        FullPath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Picmodels");
        }
    }
}
