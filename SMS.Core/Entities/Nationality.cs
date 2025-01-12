using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.Entities
{
    public class Nationality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        //public ICollection<Student>? Students { get; set; }
        //public ICollection<FamilyMember>? FamilyMembers { get; set; }
        //public ICollection<StudentNationality>? StudentNationalities { get; set; }
        //public ICollection<FamilyMemberNationality>? FamilyMemberNationalities { get; set; }
    }
}
