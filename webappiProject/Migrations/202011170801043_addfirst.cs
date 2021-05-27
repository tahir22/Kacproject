namespace webappiProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        AttendanceName = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        AttendanceCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.AttendanceCategories", t => t.AttendanceCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.AttendanceCategoryId);
            
            CreateTable(
                "dbo.AttendanceCategories",
                c => new
                    {
                        AttendanceCategoryId = c.Int(nullable: false, identity: true),
                        AttendanceCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.AttendanceCategoryId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        EmpCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.EmpCategories", t => t.EmpCategoryId, cascadeDelete: true)
                .Index(t => t.EmpCategoryId);
            
            CreateTable(
                "dbo.EmpCategories",
                c => new
                    {
                        EmpCategoryId = c.Int(nullable: false, identity: true),
                        EmpCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.EmpCategoryId);
            
            CreateTable(
                "dbo.EmployeeInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        SalaryId = c.Int(nullable: false, identity: true),
                        SalaryName = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        SalaryCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalaryId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.SalaryCategories", t => t.SalaryCategoryId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.SalaryCategoryId);
            
            CreateTable(
                "dbo.SalaryCategories",
                c => new
                    {
                        SalaryCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SalaryCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salaries", "SalaryCategoryId", "dbo.SalaryCategories");
            DropForeignKey("dbo.Salaries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeInformations", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "EmpCategoryId", "dbo.EmpCategories");
            DropForeignKey("dbo.Attendances", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Attendances", "AttendanceCategoryId", "dbo.AttendanceCategories");
            DropIndex("dbo.Salaries", new[] { "SalaryCategoryId" });
            DropIndex("dbo.Salaries", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeInformations", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "EmpCategoryId" });
            DropIndex("dbo.Attendances", new[] { "AttendanceCategoryId" });
            DropIndex("dbo.Attendances", new[] { "EmployeeId" });
            DropTable("dbo.SalaryCategories");
            DropTable("dbo.Salaries");
            DropTable("dbo.EmployeeInformations");
            DropTable("dbo.EmpCategories");
            DropTable("dbo.Employees");
            DropTable("dbo.AttendanceCategories");
            DropTable("dbo.Attendances");
        }
    }
}
