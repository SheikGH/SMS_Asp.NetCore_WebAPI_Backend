using SMS.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Interfaces
{
    public interface IFamilyMemberService
    {
        //Updates a particular Family Member
        Task<FamilyMemberResDto> UpdateFamilyMemberAsync(FamilyMemberReqDto customer);
        
        //Deletes a family member for a particular Student
        Task<FamilyMemberResDto> DeleteFamilyMemberBySIdAsync(int id);
        //Gets a nationality associated with a family member
        Task<FamilyMemberResDto> GetFamilyMemberWithNationalityAsync(int id,int nid);
        //Updates a particular Family Member’s Nationality
        Task<FamilyMemberResDto> UpdateFamilyMemberNationalityAsync(int id,int nid);
    }
}
