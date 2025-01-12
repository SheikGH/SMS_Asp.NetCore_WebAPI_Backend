using SMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Nationalities.Any())
            {
                context.Nationalities.AddRange(
                    new Nationality { Name = "American" },
                    new Nationality { Name = "Canadian" },
                    new Nationality { Name = "Indian" }
                );
            }

            if (!context.Relationships.Any())
            {
                context.Relationships.AddRange(
                    new Relationship { Name = "Parent" },
                    new Relationship { Name = "Sibling" },
                    new Relationship { Name = "Spouse" }
                );
            }

            if (!context.Students.Any())
            {
                var student = new Student
                {
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1995, 5, 15),
                    Status = "Active",
                    //NationalityId = 1,
                    FamilyMembers = new List<FamilyMember>
                {
                    new FamilyMember
                    {
                        FirstName = "Jane",
                        LastName = "Doe",
                        DateOfBirth = new DateTime(2000, 3, 10),
                        //NationalityId = 1,
                        RelationshipId = 2
                    },
                    new FamilyMember
                    {
                        FirstName = "Robert",
                        LastName = "Doe",
                        DateOfBirth = new DateTime(1965, 12, 25),
                        //NationalityId = 2,
                        RelationshipId = 1
                    }
                }
                };
                context.Students.Add(student);
            }

            context.SaveChanges();
        }
    }

}
