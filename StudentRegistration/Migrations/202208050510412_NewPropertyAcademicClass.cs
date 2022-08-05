namespace StudentRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPropertyAcademicClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcademicClasses", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AcademicClasses", "Code");
        }
    }
}
