using System.Collections.Generic;
using System.Data.Entity.Migrations;
using SelectionCommittee.DAL.Models;

namespace SelectionCommittee.DAL.DataContexts.FacultyMigrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FacultyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"DataContexts\FacultyMigrations";
            ContextKey = "SelectionCommittee.DAL.DataContexts.FacultyContext";
        }

        protected override void Seed(FacultyContext context)
        {
            var faculties = new List<Faculty>
            {
                new Faculty
                {
                    Name = "Физический факультет",
                    TotalPlacesAmount = 33,
                    FreePlacesAmount = 12,
                    About = "Наш факультет был открыт в 2011 году...",
                    Candidates = new List<ClientProfile>(),
                    ImagePath = @"~\SelectionCommittee\SelectionCommittee.Web\Content\Images\faculty.jpg"
                },

                new Faculty
                {
                    Name = "Химический факультет",
                    TotalPlacesAmount = 10,
                    FreePlacesAmount = 3,
                    About = "Наш факультет был открыт в 2004 году...",
                    Candidates = new List<ClientProfile>(),
                    ImagePath = @"~\SelectionCommittee\SelectionCommittee.Web\Content\Images\faculty.jpg"
                },

                new Faculty
                {
                    Name = "Информационный факультет",
                    TotalPlacesAmount = 60,
                    FreePlacesAmount = 40,
                    About = "Наш факультет был открыт в 2001 году...",
                    Candidates = new List<ClientProfile>(),
                    ImagePath = @"~\SelectionCommittee\SelectionCommittee.Web\Content\Images\faculty.jpg"
                }
            };

            faculties.ForEach(fac => context.Faculties.AddOrUpdate(fac));
            context.SaveChanges();
        }
    }
}
