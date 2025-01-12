using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.Entities
{
    public class FamilyMemberNationality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? NationalityId { get; set; }
        public int? FamilyMemberId { get; set; }
        //public Nationality? Nationality { get; set; }
        //public FamilyMember? FamilyMember { get; set; }

    }
}
