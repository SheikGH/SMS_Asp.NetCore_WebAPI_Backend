using Microsoft.AspNetCore.Mvc;
using SMS.Common.DTOs;
using SMS.Application.Interfaces;
using SMS.Core.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;

namespace SMS.API.Controllers
{
    public class StudentsController : BaseController
    {
        //private readonly IMediator _mediator;
        //public StudentsController(IMediator mediator, ICustomerService studentService)
        //{
        //    _mediator = mediator;
        //    _studentService = studentService;
        //}

        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        #region Student
        /// <summary>
        /// Get all Students
        /// [GET] /api/Students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResDto>>> GetAllStudents()
        {
            //var students = await _mediator.Send(new GetAllStudentsQuery());
            var studentsResDto = await _studentService.GetStudentsWithNationalityAsync();
            if (studentsResDto == null) return NotFound();
            return Ok(studentsResDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResDto>> GetStudentById(int id)
        {
            //var student = await _mediator.Send(new GetStudentByIdQuery(id));
            var studentResDto = await _studentService.GetStudentByIdAsync(id);
            if (studentResDto == null) { return NotFound(); }
            return Ok(studentResDto);
        }

        /// <summary>
        /// Add a new Student with Basic Details Only
        /// [POST] /api/Students
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<StudentResDto>> CreateStudent(StudentReqDto studentReqDto)
        {
            await _studentService.AddStudentAsync(studentReqDto);
            return CreatedAtAction(nameof(GetStudentById), new { id = studentReqDto.ID }, studentReqDto);
        }

        /// <summary>
        /// Updates a Student’s Basic Details only
        /// [PUT] /api/Students/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentReqDto studentReq)
        {
            if (id != studentReq.ID)
            {
                return BadRequest();
            }
            var updatedStudent = await _studentService.UpdateStudentAsync(studentReq);
            if (updatedStudent == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("ApproveStudent/{id}")]
        public async Task<IActionResult> ApproveStudent(int id)
        {
            var approvedStudent = await _studentService.ApproveStudentAsync(id);
            if (approvedStudent == null)
            {
                return NotFound();
            }
            return Ok(approvedStudent);
        }

        /// <summary>
        /// Gets the Nationality of a particular student
        ///[GET] /api/Students/{id}/Nationality
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Nationality")]
        public async Task<ActionResult<StudentResDto>> GetStudentNationalityByIdAsync(int id)
        {
            //var student = await _mediator.Send(new GetStudentByIdQuery(id));
            var studentResDto = await _studentService.GetStudentNationalityByIdAsync(id);
            if (studentResDto == null)
            {
                return NotFound();
            }
            return Ok(studentResDto);
        }

        /// <summary>
        /// Updates a Student’s Nationality
        /// [PUT] /api/Students/{id}/Nationality/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}/Nationality/{nid}")]
        public async Task<ActionResult<StudentResDto>> UpdateStudentNationalityAsync(int id, int nid)
        {
            var studentResDto = await _studentService.UpdateStudentNationalityAsync(id, nid);
            if (studentResDto == null)
            {
                return NotFound();
            }
            return Ok(studentResDto);
        }
        #endregion

        #region FamilyMembers

        /// <summary>
        /// Gets Family Members for a particular Student
        /// [GET] /api/Students/{id}/FamilyMembers/
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/FamilyMembers")]
        public async Task<ActionResult<FamilyMemberResDto>> GetFamilyMemberBySIdAsync(int id)
        {
            return await _studentService.GetFamilyMemberBySIdAsync(id);
        }

        /// <summary>
        /// Creates a new Family Member for a particular Student (without the nationality)
        /// [POST] /api/Students/{id}/FamilyMembers/
        /// </summary>
        /// <param name="id"></param>
        /// <param name="familyMember"></param>
        /// <returns></returns>
        [HttpPost("{id}/FamilyMembers")]
        public async Task<ActionResult<FamilyMember>> AddFamilyMemberWithStudentAsync(int id, FamilyMemberReqDto familyMember)
        {
            familyMember.StudentId = id;
            var newStudent = await _studentService.AddFamilyMemberWithStudentAsync(familyMember);
            return CreatedAtAction(nameof(GetStudentById), new { id = newStudent.ID }, newStudent);
        }
        #endregion
    }
}
