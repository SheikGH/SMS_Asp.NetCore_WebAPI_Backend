using SMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.Interfaces
{
    public interface INationalityRepository
    {
        Task<IEnumerable<Nationality>> GetNationalitiesAsync();
        Task<Nationality> GetStudentNationalityByIdAsync(int id);
        Task<Nationality> GetFamilyMemberNationalityByIdAsync(int id);
        Task<StudentNationality> AddStudentNationalityAsync(StudentNationality studentNationality);
        Task<FamilyMemberNationality> AddFamilyMemberNationalityAsync(FamilyMemberNationality familyMemberNationality);
        Task<StudentNationality> DeleteStudentNationalityAsync(int id);
        Task<FamilyMemberNationality> DeleteFamilyMemberNationalityAsync(int id);
    }
}
