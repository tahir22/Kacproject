namespace webappiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "countt", c => c.String());
            AddColumn("dbo.Employees", "countted", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "countted");
            DropColumn("dbo.Employees", "countt");
        }
    }
}
