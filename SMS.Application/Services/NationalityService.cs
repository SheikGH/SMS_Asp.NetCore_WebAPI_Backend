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
    public class NationalityService:INationalityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NationalityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Nationality>> GetNationalityAsync()
        {
            var nationalities = await _unitOfWork.Nationalities.GetNationalitiesAsync();
            return nationalities;
        }
    }
}
