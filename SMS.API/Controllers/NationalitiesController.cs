using Microsoft.AspNetCore.Mvc;
using SMS.Application.Interfaces;
using SMS.Application.Services;
using SMS.Core.Entities;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalitiesController : BaseController
    {
        private readonly INationalityService _nationalityService;
        public NationalitiesController(INationalityService nationalityService)
        {
            _nationalityService = nationalityService;
        }

        /// <summary>
        /// Gets all nationalities in the system
        /// [GET] /api/Nationalities
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Nationality>> GetAllNationalities()
        {
            return await _nationalityService.GetNationalityAsync();
        }
    }

}
