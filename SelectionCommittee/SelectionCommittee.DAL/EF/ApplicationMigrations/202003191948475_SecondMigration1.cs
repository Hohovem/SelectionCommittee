namespace SelectionCommittee.DAL.EF.ApplicationMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "EnrolleeId", "dbo.Enrollees");
            DropIndex("dbo.Enrollments", new[] { "EnrolleeId" });
            AddColumn("dbo.Enrollments", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Enrollments", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Enrollments", "User_Id");
            AddForeignKey("dbo.Enrollments", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Enrollments", "Grade");
            DropColumn("dbo.Enrollments", "EnrolleeId");
            DropTable("dbo.Enrollees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Enrollees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Town = c.String(),
                        Region = c.String(),
                        EducationEstablishmentName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Enrollments", "EnrolleeId", c => c.Int(nullable: false));
            AddColumn("dbo.Enrollments", "Grade", c => c.Int());
            DropForeignKey("dbo.Enrollments", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Enrollments", new[] { "User_Id" });
            DropColumn("dbo.Enrollments", "User_Id");
            DropColumn("dbo.Enrollments", "ApplicationUserId");
            CreateIndex("dbo.Enrollments", "EnrolleeId");
            AddForeignKey("dbo.Enrollments", "EnrolleeId", "dbo.Enrollees", "Id", cascadeDelete: true);
        }
    }
}
