using SMS.Common.DTOs;
using SMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<IEnumerable<StudentResDto>> GetStudentsWithNationalityAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> AddStudentAsync(StudentReqDto studentReqDto);
        Task<Student> UpdateStudentAsync(StudentReqDto studentReqDto);
        Task<Student> ApproveStudentAsync(int id);
        //Gets the Nationality of a particular student
        Task<StudentResDto> GetStudentNationalityByIdAsync(int id);
        //Updates a Student’s Nationality
        Task<Student> UpdateStudentNationalityAsync(int id, int nid);
        //Gets Family Members for a particular Student
        Task<FamilyMemberResDto> GetFamilyMemberBySIdAsync(int id);
        //Creates a new Family Member for a particular Student (without the nationality)
        Task<FamilyMember> AddFamilyMemberWithStudentAsync(FamilyMemberReqDto familyMemberReqDto);
    }
}
