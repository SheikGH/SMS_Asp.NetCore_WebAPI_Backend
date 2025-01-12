using AutoMapper;
using SMS.Common.DTOs;
using SMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Mappings
{
    /// <summary>
    /// Install Package AutoMapper => using AutoMapper;
    /// </summary>
    public class StudentProfile: Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentReqDto, StudentResDto>().ReverseMap();
            CreateMap<StudentReqDto, Student>().ReverseMap();
            CreateMap<StudentResDto, Student>().ReverseMap();
            CreateMap<FamilyMemberReqDto, FamilyMemberResDto>().ReverseMap();
            CreateMap<FamilyMemberReqDto, FamilyMember>().ReverseMap();
            CreateMap<FamilyMemberResDto, FamilyMember>().ReverseMap();
        }
    }
}
