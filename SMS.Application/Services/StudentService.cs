using AutoMapper;
using SMS.Common.DTOs;
using SMS.Application.Interfaces;
using SMS.Core.Entities;
using SMS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #region Student
        public async Task<IEnumerable<StudentResDto>> GetStudentsAsync()
        {
            var students = await _unitOfWork.Students.GetStudentsAsync();
            var studentsResDto = _mapper.Map<IEnumerable<StudentResDto>>(students);
            return studentsResDto;
        }
        public async Task<IEnumerable<StudentResDto>> GetStudentsWithNationalityAsync()
        {
            var studentsResDto = await _unitOfWork.Students.GetStudentsWithNationalityAsync();
            return studentsResDto;
        }

        public async Task<StudentResDto> GetStudentByIdAsync(int id)
        {
            var student = await _unitOfWork.Students.GetStudentByIdAsync(id);
            var studentResDto = _mapper.Map<StudentResDto>(student);
            return studentResDto;
        }
        public async Task<StudentResDto> AddStudentAsync(StudentReqDto studentReqDto)
        {
            await _unitOfWork.Students.AddStudentAsync(studentReqDto);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<StudentResDto>(studentReqDto);
        }

        public async Task<StudentResDto> UpdateStudentAsync(StudentReqDto studentReqDto)
        {
            var student = _mapper.Map<Student>(studentReqDto);
            await _unitOfWork.Students.UpdateStudentAsync(studentReqDto);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<StudentResDto>(studentReqDto);
        }

        public async Task<StudentResDto> ApproveStudentAsync(int id)
        {
            var student = await _unitOfWork.Students.ApproveStudentAsync(id);
            var studentResDto = _mapper.Map<StudentResDto>(student);
            return studentResDto;
        }
        public async Task<StudentResDto> GetStudentNationalityByIdAsync(int id)
        {
            var student = await _unitOfWork.Students.GetStudentNationalityByIdAsync(id);
            var nationality = await _unitOfWork.Nationalities.GetStudentNationalityByIdAsync(id);
            //var studentResDto = _mapper.Map<StudentResDto>(student);
            var studentResDto = new StudentResDto()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                NationalityId = nationality.ID,
                NationalityName = nationality.Name
            };
            return studentResDto;
        }
        /// <summary>
        /// Updates a Student’s Nationality
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nid"></param>
        /// <returns></returns>
        public async Task<StudentResDto> UpdateStudentNationalityAsync(int id, int nid)
        {
            var student = await _unitOfWork.Students.UpdateStudentNationalityAsync(id, nid);
            var studentResDto = _mapper.Map<StudentResDto>(student);
            return studentResDto;
        }
        #endregion

        #region FamilyMember
        /// <summary>
        /// Gets Family Members for a particular Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FamilyMemberResDto> GetFamilyMemberBySIdAsync(int id)
        {
            var familyMember = await _unitOfWork.Students.GetFamilyMemberBySIdAsync(id);
            var familyMemberResDto = _mapper.Map<FamilyMemberResDto>(familyMember);
            return familyMemberResDto;
        }
        public async Task<FamilyMemberResDto> AddFamilyMemberWithStudentAsync(FamilyMemberReqDto familyMemberReqDto)
        {
            var familyMember = _mapper.Map<FamilyMember>(familyMemberReqDto);
            await _unitOfWork.Students.AddFamilyMemberWithStudentAsync(familyMemberReqDto);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<FamilyMemberResDto>(familyMember);
        }

        #endregion
    }
}
