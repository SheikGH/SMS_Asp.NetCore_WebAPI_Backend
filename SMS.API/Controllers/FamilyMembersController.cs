using Microsoft.AspNetCore.Mvc;
using SMS.Common.DTOs;
using SMS.Application.Interfaces;
using SMS.Application.Services;
using SMS.Core.Entities;
using System.Security.Cryptography;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMembersController : ControllerBase
    {
        private readonly IFamilyMemberService _familyMemberService;
        public FamilyMembersController(IFamilyMemberService familyMemberService)
        {
            _familyMemberService = familyMemberService;
        }
        /// <summary>
        /// Updates a particular Family Member
        /// [PUT]/api/FamilyMembers/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="familyMember"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async  Task<ActionResult> UpdateFamilyMember(int id, FamilyMemberReqDto familyMember)
        {
            if (id != familyMember.ID) return BadRequest();
            var updatedFamilyMember = await _familyMemberService.UpdateFamilyMemberAsync(familyMember);
            if (updatedFamilyMember == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a family member for a particular Student
        /// [DELETE]/api/FamilyMembers/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteFamilyMemberBySID/{id}")]
        public async Task<ActionResult<FamilyMemberResDto>> DeleteFamilyMemberBySID(int id)
        {
            var deletedFamilyMember = await _familyMemberService.DeleteFamilyMemberBySIdAsync(id);
            if (deletedFamilyMember == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Gets a nationality associated with a family member
        /// GET] /api/FamilyMembers/{id}/Nationality/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nid"></param>
        /// <returns></returns>
        [HttpGet("{id}/Nationality/{nId}")]
        public async Task<ActionResult<FamilyMemberResDto>> GetFamilyMemberNationality(int id,int nid)
        {
            var familyMemberResDto = await _familyMemberService.GetFamilyMemberWithNationalityAsync(id, nid);
            return Ok(familyMemberResDto);
        }

        /// <summary>
        /// Updates a particular Family Member’s Nationality
        /// [PUT] /api/FamilyMembers/{id}/Nationality/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nId"></param>
        /// <returns></returns>
        [HttpPut("{id}/Nationality/{nId}")]
        public async Task<ActionResult<StudentResDto>> UpdateFamilyMemberNationality(int id, int nId)
        {
            var familyMemberResDto = await _familyMemberService.UpdateFamilyMemberNationalityAsync(id, nId);
            if (familyMemberResDto == null)
            {
                return NotFound();
            }
            return Ok(familyMemberResDto);
        }
    }

}
