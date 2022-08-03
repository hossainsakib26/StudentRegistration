namespace StudentRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudentAndAcademicClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "ClassName_ID", "dbo.AcademicClasses");
            DropForeignKey("dbo.AcademicClasses", "Student_ID", "dbo.Students");
            DropIndex("dbo.AcademicClasses", new[] { "Student_ID" });
            DropIndex("dbo.Students", new[] { "ClassName_ID" });
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "ID", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Students", "ID");
            DropColumn("dbo.AcademicClasses", "Student_ID");
            DropColumn("dbo.Students", "ClassName_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ClassName_ID", c => c.Long());
            AddColumn("dbo.AcademicClasses", "Student_ID", c => c.Int());
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Students", "ID");
            CreateIndex("dbo.Students", "ClassName_ID");
            CreateIndex("dbo.AcademicClasses", "Student_ID");
            AddForeignKey("dbo.AcademicClasses", "Student_ID", "dbo.Students", "ID");
            AddForeignKey("dbo.Students", "ClassName_ID", "dbo.AcademicClasses", "ID");
        }
    }
}
