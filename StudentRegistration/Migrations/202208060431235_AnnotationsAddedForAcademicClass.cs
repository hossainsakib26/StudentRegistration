namespace StudentRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnnotationsAddedForAcademicClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AcademicClasses", "Code", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.AcademicClasses", "Name", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AcademicClasses", "Name", c => c.String());
            AlterColumn("dbo.AcademicClasses", "Code", c => c.String());
        }
    }
}
