namespace StudentRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcademicClassModelNameCodeStringLengthUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AcademicClasses", "Code", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.AcademicClasses", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AcademicClasses", "Name", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.AcademicClasses", "Code", c => c.String(nullable: false, maxLength: 4));
        }
    }
}
