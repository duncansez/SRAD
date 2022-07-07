namespace SRAD_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddisNotifyingrademodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grades", "isNotify", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grades", "isNotify");
        }
    }
}
