using Microsoft.EntityFrameworkCore;
using SMS.Common.DTOs;
using SMS.Core.Entities;
using SMS.Core.Interfaces;
using SMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repositories
{
    public class FamilyMemberRepository: IFamilyMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public FamilyMemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<FamilyMember> UpdateFamilyMemberAsync(FamilyMemberReqDto familyMemberReqDto)
        {
            var familyMember = new FamilyMember
            {
                ID = familyMemberReqDto.ID,
                StudentId = familyMemberReqDto.StudentId,
                FirstName = familyMemberReqDto.FirstName,
                LastName = familyMemberReqDto.LastName,
                DateOfBirth = familyMemberReqDto.DateOfBirth,
                RelationshipId = familyMemberReqDto.RelationshipId,
            };
            _context.FamilyMembers.Update(familyMember);

            var familyMemberNationality = await _context.FamilyMemberNationalities
               .FirstOrDefaultAsync(sn => sn.FamilyMemberId == familyMemberReqDto.ID);

            if (familyMemberNationality != null)
            {
                familyMemberNationality.NationalityId = familyMemberReqDto.NationalityId;
                _context.FamilyMemberNationalities.Update(familyMemberNationality);
            }
            else
            {
                _context.FamilyMemberNationalities.Add(new FamilyMemberNationality
                {
                    NationalityId = familyMemberReqDto.NationalityId,
                    FamilyMemberId = familyMemberReqDto.ID
                });
            }

            return familyMember;
        }
        public async Task<FamilyMember> DeleteFamilyMemberBySIdAsync(int id)
        {
            var familyMember = await _context.FamilyMembers.Where(f => f.StudentId == id).FirstOrDefaultAsync();
            
            if (familyMember == null)
            {
                return null;
            }

            _context.FamilyMembers.Remove(familyMember);

            var familyMemberNationality = await _context.FamilyMemberNationalities.Where(f => f.FamilyMemberId == familyMember.ID).FirstOrDefaultAsync();

            if (familyMemberNationality == null)
            {
                return null;
            }

            _context.FamilyMemberNationalities.Remove(familyMemberNationality);

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }

            _context.Students.Remove(student);

            var studentNationality = await _context.StudentNationalities.Where(f => f.StudentId == student.ID).FirstOrDefaultAsync();

            if (studentNationality == null)
            {
                return null;
            }

            _context.StudentNationalities.Remove(studentNationality);
            return familyMember;
        }
        public async Task<FamilyMemberResDto> GetFamilyMemberWithNationalityAsync(int id, int nid)
        {
            //return await _context.FamilyMembers.FindAsync(id);
            return await _context.FamilyMembers
                .Where(s => s.ID == id)
                .Join(
                    _context.FamilyMemberNationalities,
                    familyMember => familyMember.ID,
                    familyMemberNationality => familyMemberNationality.FamilyMemberId,
                    (familyMember, familyMemberNationality) => new { familyMember, familyMemberNationality }
                )
                .Join(
                    _context.Nationalities,
                    combined => combined.familyMemberNationality.NationalityId,
                    nationality => nationality.ID,
                    (combined, nationality) => new FamilyMemberResDto
                    {
                        ID = combined.familyMember.ID,
                        StudentId = combined.familyMember.StudentId,
                        FirstName = combined.familyMember.FirstName,
                        LastName = combined.familyMember.LastName,
                        DateOfBirth = combined.familyMember.DateOfBirth,
                        RelationshipId = combined.familyMember.RelationshipId,
                        NationalityId = nationality.ID,
                    }
                )
                .FirstOrDefaultAsync();

            //return await _context.FamilyMembers
            //    .Where(fm=> fm.ID == id)
            ////.Include(s => s.FamilyMemberNationalities)
            ////.ThenInclude(fn => fn.Nationality)
            //.Select(fm => new FamilyMemberResDto
            //{
            //    ID = fm.ID,
            //    FirstName = fm.FirstName,
            //    LastName = fm.LastName,
            //    DateOfBirth = fm.DateOfBirth,
            //    RelationshipId = fm.RelationshipId,
            //    NationalityId = fm.FamilyMemberNationalities.Where(fmn => fmn.FamilyMemberId == id).Select(fmn => fmn.NationalityId).FirstOrDefault(),
            //})
            //.FirstOrDefaultAsync();
        }
        public async Task<FamilyMember> UpdateFamilyMemberNationalityAsync(int id, int nid)
        {
            var familyMemberNationality = await _context.FamilyMemberNationalities.Where(fmn => fmn.FamilyMemberId == id).FirstOrDefaultAsync();
            familyMemberNationality.NationalityId = nid;
            _context.FamilyMemberNationalities.Update(familyMemberNationality);
            return await _context.FamilyMembers.FindAsync(id);
        }
    }
}
