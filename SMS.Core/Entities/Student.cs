using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Status { get; set; }
        //public int? NationalityId { get; set; }
        //public Nationality Nationality { get; set; }
        //public ICollection<StudentNationality>? StudentNationalities { get; set; }
        //public ICollection<FamilyMember>? FamilyMembers { get; set; }
    }
}
