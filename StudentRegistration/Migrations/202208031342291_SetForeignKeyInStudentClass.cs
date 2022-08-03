namespace StudentRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetForeignKeyInStudentClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "AcademicClass_ID", "dbo.AcademicClasses");
            DropIndex("dbo.Students", new[] { "AcademicClass_ID" });
            RenameColumn(table: "dbo.Students", name: "AcademicClass_ID", newName: "AcademicClassId");
            DropPrimaryKey("dbo.AcademicClasses");
            AlterColumn("dbo.AcademicClasses", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Students", "AcademicClassId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AcademicClasses", "ID");
            CreateIndex("dbo.Students", "AcademicClassId");
            AddForeignKey("dbo.Students", "AcademicClassId", "dbo.AcademicClasses", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "AcademicClassId", "dbo.AcademicClasses");
            DropIndex("dbo.Students", new[] { "AcademicClassId" });
            DropPrimaryKey("dbo.AcademicClasses");
            AlterColumn("dbo.Students", "AcademicClassId", c => c.Long());
            AlterColumn("dbo.AcademicClasses", "ID", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.AcademicClasses", "ID");
            RenameColumn(table: "dbo.Students", name: "AcademicClassId", newName: "AcademicClass_ID");
            CreateIndex("dbo.Students", "AcademicClass_ID");
            AddForeignKey("dbo.Students", "AcademicClass_ID", "dbo.AcademicClasses", "ID");
        }
    }
}
