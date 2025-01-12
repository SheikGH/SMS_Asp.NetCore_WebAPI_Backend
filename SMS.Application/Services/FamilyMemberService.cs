using AutoMapper;
using SMS.Common.DTOs;
using SMS.Application.Interfaces;
using SMS.Core.Entities;
using SMS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Services
{
    public class FamilyMemberService : IFamilyMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FamilyMemberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<FamilyMemberResDto> UpdateFamilyMemberAsync(FamilyMemberReqDto familyMemberReqDto)
        {
            await _unitOfWork.FamilyMembers.UpdateFamilyMemberAsync(familyMemberReqDto);
            await _unitOfWork.FamilyMembers.UpdateFamilyMemberNationalityAsync(familyMemberReqDto.ID, familyMemberReqDto.NationalityId.Value);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<FamilyMemberResDto>(familyMemberReqDto);
        }

        /// <summary>
        /// Deletes a family member for a particular Student
        /// [DELETE]/api/FamilyMembers/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FamilyMemberResDto> DeleteFamilyMemberBySIdAsync(int id)
        {
            var familyMember = await _unitOfWork.FamilyMembers.DeleteFamilyMemberBySIdAsync(id);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<FamilyMemberResDto>(familyMember);
        }
        public async Task<FamilyMemberResDto> GetFamilyMemberWithNationalityAsync(int id, int nid)
        {
            var familyMemberResDto = await _unitOfWork.FamilyMembers.GetFamilyMemberWithNationalityAsync(id, nid);
            return familyMemberResDto;
        }
        public async Task<FamilyMemberResDto> UpdateFamilyMemberNationalityAsync(int id, int nid)
        {
            var familyMember = await _unitOfWork.FamilyMembers.UpdateFamilyMemberNationalityAsync(id, nid);
            var familyMemberResDto = _mapper.Map<FamilyMemberResDto>(familyMember);
            return familyMemberResDto;
        }
    }
}
