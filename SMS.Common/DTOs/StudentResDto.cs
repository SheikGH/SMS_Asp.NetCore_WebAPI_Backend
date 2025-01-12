using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Common.DTOs
{
    public class StudentResDto
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? NationalityId { get; set; }
        public string? NationalityName { get; set; }
        public List<NationalityDto>? Nationalities { get; set; }

    }
}
