using Microsoft.AspNetCore.Http.HttpResults;
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
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #region Students
        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToArrayAsync();
        }
        public async Task<IEnumerable<StudentResDto>> GetStudentsWithNationalityAsync()
        {
            return await _context.Students
                .Join(
                    _context.StudentNationalities,
                    student => student.ID,
                    studentNationality => studentNationality.StudentId,
                    (student, studentNationality) => new { student, studentNationality }
                )
                .Join(
                    _context.Nationalities,
                    combined => combined.studentNationality.NationalityId,
                    nationality => nationality.ID,
                    (combined, nationality) => new StudentResDto
                    {
                        ID = combined.student.ID,
                        FirstName = combined.student.FirstName,
                        LastName = combined.student.LastName,
                        DateOfBirth = combined.student.DateOfBirth,
                        //Status = student.Status,
                        NationalityId = nationality.ID,
                        NationalityName = nationality.Name,
                    }
                )
                .ToListAsync();

            //return await _context.Students
            //.Select(s => new StudentResDto
            //{
            //    ID = s.ID,
            //    FirstName = s.FirstName,
            //    LastName = s.LastName,
            //    DateOfBirth = s.DateOfBirth,
            //    NationalityId = s.StudentNationalities.FirstOrDefault().Nationality.ID,
            //    NationalityName = s.StudentNationalities.FirstOrDefault().Nationality.Name,
            //    Nationalities = s.StudentNationalities
            //        .Select(sn => new NationalityDto
            //        {
            //            NationalityId = sn.Nationality.ID,
            //            NationalityName = sn.Nationality.Name
            //        }).ToList()
            //})
            //.ToArrayAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }
        
        public async Task<Student> AddStudentAsync(StudentReqDto studentReqDto)
        {
            var student = new Student
            {
                FirstName = studentReqDto.FirstName,
                LastName = studentReqDto.LastName,
                DateOfBirth = studentReqDto.DateOfBirth,
                Status = "Active"
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            await _context.StudentNationalities.AddAsync(new StudentNationality() { NationalityId = studentReqDto.NationalityId, StudentId = student.ID });
            //await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudentAsync(StudentReqDto studentReqDto)
        {
            var student = await _context.Students.FindAsync(studentReqDto.ID);
            //if (student == null) throw new Exception("Student not found");
            if (student != null)
            {
                student.FirstName = studentReqDto.FirstName;
                student.LastName = studentReqDto.LastName;
                student.DateOfBirth = studentReqDto.DateOfBirth;
                //student.Status = studentReqDto.Status;
                _context.Students.Update(student);
            }
            else
            {
                _context.Students.Add(new Student
                {
                    FirstName = studentReqDto.FirstName,
                    LastName = studentReqDto.LastName,
                    DateOfBirth = studentReqDto.DateOfBirth,
                    Status = "Active"
                });
            }
            var studentNationality = await _context.StudentNationalities
                .FirstOrDefaultAsync(sn => sn.StudentId == student.ID);

            if (studentNationality != null)
            {
                studentNationality.NationalityId = studentReqDto.NationalityId;
                _context.StudentNationalities.Update(studentNationality);
            }
            else
            {
                _context.StudentNationalities.Add(new StudentNationality
                {
                    NationalityId = studentReqDto.NationalityId,
                    StudentId = student.ID
                });
            }
            return student;
        }

        public async Task<Student> ApproveStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) throw new Exception("Student not found");
            if (student != null)
            {
                student.Status = "Approved";
                _context.Students.Update(student);
                _context.Entry(student).State = EntityState.Modified;
                _context.Entry(student).Property(s => s.Status).IsModified = true;

            }
            return student;
        }
        public async Task<StudentResDto> GetStudentNationalityByIdAsync(int id)
        {
            return await _context.Students
                .Where(s=>s.ID == id)
                .Join(
                    _context.StudentNationalities,
                    student => student.ID,
                    studentNationality => studentNationality.StudentId,
                    (student, studentNationality) => new { student, studentNationality }
                )
                .Join(
                    _context.Nationalities,
                    combined => combined.studentNationality.NationalityId,
                    nationality => nationality.ID,
                    (combined, nationality) => new StudentResDto
                    {
                        ID = combined.student.ID,
                        FirstName = combined.student.FirstName,
                        LastName = combined.student.LastName,
                        DateOfBirth = combined.student.DateOfBirth,
                        //Status = student.Status,
                        NationalityId = nationality.ID,
                        NationalityName = nationality.Name,
                    }
                )
                .FirstOrDefaultAsync();
        }
        public async Task<Student> UpdateStudentNationalityAsync(int id, int nId)
        {
            var studentNationality = await _context.StudentNationalities
                .FirstOrDefaultAsync(sn => sn.StudentId == id);

            if (studentNationality != null)
            {
                studentNationality.NationalityId = nId;
                _context.StudentNationalities.Update(studentNationality);
            }
            else
            {
                _context.StudentNationalities.Add(new StudentNationality
                {
                    NationalityId = nId,
                    StudentId = id
                });
            }

            return await _context.Students.FindAsync(id);
        }
        #endregion
        #region FamilyMember
        //public async Task<FamilyMember> GetFamilyMemberBySIdAsync(int studentId) => await _context.FamilyMembers.Where(f => f.StudentId == studentId).FirstOrDefaultAsync();
        public async Task<FamilyMemberResDto> GetFamilyMemberBySIdAsync(int studentId)
        {
            return await _context.FamilyMembers
                .Where(s => s.StudentId == studentId)
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
        }

        public async Task<FamilyMember> AddFamilyMemberWithStudentAsync(FamilyMemberReqDto familyMemberReqDto)
        {

            var familyMember = new FamilyMember
            {
                //ID = familyMemberResDto.ID,
                StudentId = familyMemberReqDto.StudentId,
                FirstName = familyMemberReqDto.FirstName,
                LastName = familyMemberReqDto.LastName,
                DateOfBirth = familyMemberReqDto.DateOfBirth,
                RelationshipId = familyMemberReqDto.RelationshipId,
            };
            await _context.FamilyMembers.AddAsync(familyMember);
            await _context.SaveChangesAsync();

            await _context.FamilyMemberNationalities.AddAsync(
                new FamilyMemberNationality() { NationalityId = familyMemberReqDto.NationalityId, FamilyMemberId = familyMember.ID });

            return familyMember;
        }

        #endregion

    }
}
