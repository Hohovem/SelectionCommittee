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
            ContextKey = "SelectionCommittee.Entities.DataContexts.FacultyContext";
        }

        protected override void Seed(FacultyContext context)
        {
            var faculties = new List<Faculty>
            {
                new Faculty
                {
                    Name = "EPAM44"
                },

                new Faculty
                {
                    Name = "EPAM2"
                },

                new Faculty
                {
                    Name = "EPAM3"
                }
            };

            faculties.ForEach(fac => context.Faculties.AddOrUpdate(fac));
            context.SaveChanges();
        }
    }
}
