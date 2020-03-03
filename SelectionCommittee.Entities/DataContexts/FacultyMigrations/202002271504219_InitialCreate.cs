using System.Data.Entity.Migrations;

namespace SelectionCommittee.DAL.DataContexts.FacultyMigrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BudgetPlacesAmount = c.Int(nullable: false),
                        TotalPlacesAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyId);
            
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Email = c.String(),
                        Town = c.String(),
                        Region = c.String(),
                        EducationEstablishmentName = c.String(),
                    })
                .PrimaryKey(t => t.CandidateId);
            
            CreateTable(
                "dbo.CandidateFaculties",
                c => new
                    {
                        Candidate_CandidateId = c.Int(nullable: false),
                        Faculty_FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Candidate_CandidateId, t.Faculty_FacultyId })
                .ForeignKey("dbo.Candidates", t => t.Candidate_CandidateId, cascadeDelete: true)
                .ForeignKey("dbo.Faculties", t => t.Faculty_FacultyId, cascadeDelete: true)
                .Index(t => t.Candidate_CandidateId)
                .Index(t => t.Faculty_FacultyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidateFaculties", "Faculty_FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.CandidateFaculties", "Candidate_CandidateId", "dbo.Candidates");
            DropIndex("dbo.CandidateFaculties", new[] { "Faculty_FacultyId" });
            DropIndex("dbo.CandidateFaculties", new[] { "Candidate_CandidateId" });
            DropTable("dbo.CandidateFaculties");
            DropTable("dbo.Candidates");
            DropTable("dbo.Faculties");
        }
    }
}
