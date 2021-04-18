using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EhealthCare.API.Data;
using EhealthCare.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EhealthCare.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IHealthCareRepository _repo;
        private readonly IMapper _mapper;
        public DoctorController(IHealthCareRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]

        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _repo.GetDoctors();

            var doctorToReturn = _mapper.Map<IEnumerable<DoctorForListDto>>(doctors);

            return Ok(doctorToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _repo.GetDoctor(id);

            var doctorToReturn = _mapper.Map<DoctorForListDto>(doctor);

            return Ok(doctorToReturn);
        }

    }
}