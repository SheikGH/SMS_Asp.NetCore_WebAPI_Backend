using SMS.Common.DTOs;
using SMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.Interfaces
{
    public interface IFamilyMemberRepository
    {
        Task<FamilyMember> UpdateFamilyMemberAsync(FamilyMemberReqDto familyMemberReqDto);
        //Deletes a family member for a particular Student
        Task<FamilyMember> DeleteFamilyMemberBySIdAsync(int id);
        //Gets a nationality associated with a family member
        Task<FamilyMemberResDto> GetFamilyMemberWithNationalityAsync(int id, int nid);
        //Updates a particular Family Member’s Nationality
        Task<FamilyMember> UpdateFamilyMemberNationalityAsync(int id, int nid);
    }
}
