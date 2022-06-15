namespace SRAD_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgrademodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Double(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                        IsDeleted = c.Boolean(),
                        Course_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Grades", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Grades", new[] { "User_Id" });
            DropIndex("dbo.Grades", new[] { "Course_Id" });
            DropTable("dbo.Grades");
        }
    }
}
