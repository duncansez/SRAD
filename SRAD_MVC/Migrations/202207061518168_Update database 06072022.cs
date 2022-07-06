namespace SRAD_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedatabase06072022 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grades", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Grades", "User_Id", "dbo.Users");
            DropIndex("dbo.Grades", new[] { "Course_Id" });
            DropIndex("dbo.Grades", new[] { "User_Id" });
            AddColumn("dbo.Grades", "Course", c => c.String());
            AddColumn("dbo.Grades", "User", c => c.String());
            DropColumn("dbo.Grades", "Course_Id");
            DropColumn("dbo.Grades", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grades", "User_Id", c => c.Int());
            AddColumn("dbo.Grades", "Course_Id", c => c.Int());
            DropColumn("dbo.Grades", "User");
            DropColumn("dbo.Grades", "Course");
            CreateIndex("dbo.Grades", "User_Id");
            CreateIndex("dbo.Grades", "Course_Id");
            AddForeignKey("dbo.Grades", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Grades", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
