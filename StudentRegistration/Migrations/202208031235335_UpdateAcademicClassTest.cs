namespace StudentRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAcademicClassTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "ClassName_ID", "dbo.AcademicClasses");
            AddColumn("dbo.AcademicClasses", "Student_ID", c => c.Int());
            AddColumn("dbo.Students", "AcademicClass_ID", c => c.Long());
            CreateIndex("dbo.AcademicClasses", "Student_ID");
            CreateIndex("dbo.Students", "AcademicClass_ID");
            AddForeignKey("dbo.AcademicClasses", "Student_ID", "dbo.Students", "ID");
            AddForeignKey("dbo.Students", "AcademicClass_ID", "dbo.AcademicClasses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "AcademicClass_ID", "dbo.AcademicClasses");
            DropForeignKey("dbo.AcademicClasses", "Student_ID", "dbo.Students");
            DropIndex("dbo.Students", new[] { "AcademicClass_ID" });
            DropIndex("dbo.AcademicClasses", new[] { "Student_ID" });
            DropColumn("dbo.Students", "AcademicClass_ID");
            DropColumn("dbo.AcademicClasses", "Student_ID");
            AddForeignKey("dbo.Students", "ClassName_ID", "dbo.AcademicClasses", "ID");
        }
    }
}
