namespace webappiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentPARTIALCLASSes",
                c => new
                    {
                        StudentPARTIALCLASSId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                    })
                .PrimaryKey(t => t.StudentPARTIALCLASSId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentPARTIALCLASSes");
        }
    }
}
