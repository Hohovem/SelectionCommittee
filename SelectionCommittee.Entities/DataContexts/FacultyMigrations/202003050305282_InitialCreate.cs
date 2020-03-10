namespace SelectionCommittee.DAL.DataContexts.FacultyMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FreePlacesAmount = c.Int(nullable: false),
                        TotalPlacesAmount = c.Int(nullable: false),
                        Name = c.String(),
                        ImagePath = c.String(),
                        About = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientProfiles",
                c => new
                    {
                        ClientProfileId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Email = c.String(),
                        Town = c.String(),
                        Region = c.String(),
                        EducationEstablishmentName = c.String(),
                    })
                .PrimaryKey(t => t.ClientProfileId);
            
            CreateTable(
                "dbo.ClientProfileFaculties",
                c => new
                    {
                        ClientProfile_ClientProfileId = c.Int(nullable: false),
                        Faculty_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClientProfile_ClientProfileId, t.Faculty_Id })
                .ForeignKey("dbo.ClientProfiles", t => t.ClientProfile_ClientProfileId, cascadeDelete: true)
                .ForeignKey("dbo.Faculties", t => t.Faculty_Id, cascadeDelete: true)
                .Index(t => t.ClientProfile_ClientProfileId)
                .Index(t => t.Faculty_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientProfileFaculties", "Faculty_Id", "dbo.Faculties");
            DropForeignKey("dbo.ClientProfileFaculties", "ClientProfile_ClientProfileId", "dbo.ClientProfiles");
            DropIndex("dbo.ClientProfileFaculties", new[] { "Faculty_Id" });
            DropIndex("dbo.ClientProfileFaculties", new[] { "ClientProfile_ClientProfileId" });
            DropTable("dbo.ClientProfileFaculties");
            DropTable("dbo.ClientProfiles");
            DropTable("dbo.Faculties");
        }
    }
}
