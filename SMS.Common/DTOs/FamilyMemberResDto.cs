using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Common.DTOs
{
    public class FamilyMemberResDto
    {
        public int ID { get; set; }
        public int? StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? RelationshipId { get; set; }
        public int? NationalityId { get; set; }
        public List<NationalityDto>? Nationalities { get; set; }
    }
}
