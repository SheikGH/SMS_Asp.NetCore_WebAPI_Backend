using SMS.Common.DTOs;
using SMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Interfaces
{
    public interface IStudentService
    {
        #region Student
        //Get all Students
        Task<IEnumerable<StudentResDto>> GetStudentsAsync();
        Task<IEnumerable<StudentResDto>> GetStudentsWithNationalityAsync();
        Task<StudentResDto> GetStudentByIdAsync(int id);
        //Add a new Student with Basic Details Only
        Task<StudentResDto> AddStudentAsync(StudentReqDto studentReqDto);
        //Updates a Student’s Basic Details only
        Task<StudentResDto> UpdateStudentAsync(StudentReqDto studentReqDto);
        //Task<StudentResDto> DeleteStudentAsync(int id);
        Task<StudentResDto> ApproveStudentAsync(int id);
        //Gets the Nationality of a particular student
        Task<StudentResDto> GetStudentNationalityByIdAsync(int id);
        //Updates a Student’s Nationality
        Task<StudentResDto> UpdateStudentNationalityAsync(int id,int nid);
        #endregion

        #region FamilyMember
        //Gets Family Members for a particular Student
        Task<FamilyMemberResDto> GetFamilyMemberBySIdAsync(int id);
        
        //Creates a new Family Member for a particular Student (without the nationality)
        Task<FamilyMemberResDto> AddFamilyMemberWithStudentAsync(FamilyMemberReqDto familyMember);
        #endregion
    }
}
