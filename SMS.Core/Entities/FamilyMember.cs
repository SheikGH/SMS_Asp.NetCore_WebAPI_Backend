using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.Entities
{
    public class FamilyMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[ForeignKey("Student")]//PK,Foreign Key
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        //reference navigation property
        public int? StudentId { get; set; }
        //public Student? Student { get; set; }
        //public int? NationalityId { get; set; }
        //public Nationality? Nationality { get; set; }
        public int? RelationshipId { get; set; }
        //public Relationship? Relationship { get; set; }
        //public ICollection<FamilyMemberNationality>? FamilyMemberNationalities { get; set; }

    }

}
