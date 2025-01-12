using Microsoft.EntityFrameworkCore;
using SMS.Core.Entities;
using SMS.Core.Interfaces;
using SMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repositories
{
    public class NationalityRepository: INationalityRepository
    {
        private readonly ApplicationDbContext _context;

        public NationalityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Nationality>> GetNationalitiesAsync()
        {
            return await _context.Nationalities.ToListAsync();
        }
        public async Task<Nationality> GetStudentNationalityByIdAsync(int id)
        {
            var result = await _context.Nationalities
            .Join(
                _context.StudentNationalities,
                nationality => nationality.ID,    // Outer key selector
                studentNationality => studentNationality.StudentId,     // Inner key selector
                (nationality, studentNationality) => new        // Result selector
                {
                    nationality.ID,
                    nationality.Name,
                    studentNationality.StudentId
                }
            )
            .Where(x => x.StudentId == id) // Apply conditions if needed
            .Select(s => new Nationality { ID = s.ID, Name = s.Name })
            .FirstOrDefaultAsync();
            return result;
        }
        public async Task<Nationality> GetFamilyMemberNationalityByIdAsync(int id)
        {
            //return await _context.FamilyMemberNationalities.FindAsync(id);
            var result = await _context.Nationalities
            .Join(
                _context.FamilyMemberNationalities,
                nationality => nationality.ID,    // Outer key selector
                familyMemberNationality => familyMemberNationality.FamilyMemberId,     // Inner key selector
                (nationality, familyMemberNationality) => new        // Result selector
                {
                    nationality.ID,
                    nationality.Name,
                    familyMemberNationality.FamilyMemberId
                }
            )
            .Where(x => x.FamilyMemberId == id) // Apply conditions if needed
            .Select(s => new Nationality { ID = s.ID, Name = s.Name })
            .FirstOrDefaultAsync();
            return result;
        }
        public async Task<StudentNationality> AddStudentNationalityAsync(StudentNationality studentNationality)
        {
            await _context.StudentNationalities.AddAsync(studentNationality);
            return studentNationality;
        }
        public async Task<FamilyMemberNationality> AddFamilyMemberNationalityAsync(FamilyMemberNationality familyMemberNationality)
        {
            await _context.FamilyMemberNationalities.AddAsync(familyMemberNationality);
            return familyMemberNationality;
        }

        public async Task<StudentNationality> DeleteStudentNationalityAsync(int id)
        {
            var studentNationality = await _context.StudentNationalities.FindAsync(id);
            if (studentNationality == null)
            {
                return null;
            }

            _context.StudentNationalities.Remove(studentNationality);
            return studentNationality;
        }
        public async Task<FamilyMemberNationality> DeleteFamilyMemberNationalityAsync(int id)
        {
            var familyMemberNationality = await _context.FamilyMemberNationalities.FindAsync(id);
            if (familyMemberNationality == null)
            {
                return null;
            }

            _context.FamilyMemberNationalities.Remove(familyMemberNationality);
            return familyMemberNationality;
        }
    }
}
