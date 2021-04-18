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
    public class PatientController : ControllerBase
    {
        private readonly IHealthCareRepository _repo;
        private readonly IMapper _mapper;
        public PatientController(IHealthCareRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]

        public async Task<IActionResult> GetPatients()
        {
            var patients = await _repo.GetPatients();

            var patientToReturn = _mapper.Map<IEnumerable<PatientForListDto>>(patients);

            return Ok(patientToReturn);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _repo.GetPatient(id);

             var patientToReturn = _mapper.Map<PatientForListDto>(patient);

            return Ok(patientToReturn);
        }

    }
}