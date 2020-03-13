using System.Collections.Generic;
using SelectionCommittee.DAL.Entities;

namespace SelectionCommittee.DAL.EF.ApplicationMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SelectionCommittee.DAL.EF.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"EF\ApplicationMigrations";
        }

        protected override void Seed(SelectionCommittee.DAL.EF.ApplicationContext context)
        {
            var faculties = new List<Faculty>
            {
                new Faculty
                {
                    Name = "Физический факультет",
                    TotalPlacesAmount = 33,
                    BudgetPlacesAmount = 12
                },

                new Faculty
                {
                    Name = "Химический факультет",
                    TotalPlacesAmount = 10,
                    BudgetPlacesAmount = 3
                },

                new Faculty
                {
                    Name = "Информационный факультет",
                    TotalPlacesAmount = 60,
                    BudgetPlacesAmount = 40
                }
            };

            faculties.ForEach(fac => context.Faculties.AddOrUpdate(fac));
            context.SaveChanges();
        }
    }
}
