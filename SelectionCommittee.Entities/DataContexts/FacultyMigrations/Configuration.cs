using System.Collections.Generic;
using SelectionCommittee.Entities.Models;

namespace SelectionCommittee.Entities.DataContexts.FacultyMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SelectionCommittee.Entities.DataContexts.FacultyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"DataContexts\FacultyMigrations";
            ContextKey = "SelectionCommittee.Entities.DataContexts.FacultyContext";
        }

        protected override void Seed(SelectionCommittee.Entities.DataContexts.FacultyContext context)
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
