using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EhealthCare.API.Data;
using EhealthCare.API.Dtos;
using EhealthCare.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EhealthCare.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;

        }
        [HttpPost("addadmin")]
        public async Task<IActionResult> AddAdmin(AdminforaddDto adminforaddDto)
        {


            var admintoCreate = new Admin
            {
                Adminname = adminforaddDto.Adminname

            };
            var createdAdmin = await _repo.AddAdmin(admintoCreate, adminforaddDto.Password);

            return StatusCode(201);
        }


        [HttpPost("adddoctor")]

        public async Task<IActionResult> AddDoctor(DoctorforaddDto doctorforaddDto)
        {

            if (await _repo.DoctorExists(doctorforaddDto.DoctorId))
                return BadRequest("Doctor already exists");

            var doctortoCreate = new Doctors
            {
                DoctorId = doctorforaddDto.DoctorId

            };
            var createdDoctor = await _repo.AddDoctor(doctortoCreate, doctorforaddDto.Password);

            return StatusCode(201);
        }

        [HttpPost("addpatient")]

        public async Task<IActionResult> AddPatient(PatientforaddDto patientforaddDto)
        {

            if (await _repo.PatientExists(patientforaddDto.PatientId))
                return BadRequest("Patient already exists");

            var patienttoCreate = new Patients
            {
                PatientId = patientforaddDto.PatientId

            };
            var createdPatient = await _repo.AddPatient(patienttoCreate, patientforaddDto.Password);

            return StatusCode(201);
        }

        [HttpPost("loginadmin")]

        public async Task<IActionResult> Loginadmin(AdminforloginDto adminforloginDto)
        {
            var adminFromRepo = await _repo.LoginAdmin(adminforloginDto.Adminname.ToLower(), adminforloginDto.Password);

            if (adminFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier , adminFromRepo.AdminId.ToString()),
                new Claim(ClaimTypes.Name, adminFromRepo.Adminname)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key , SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }

        [HttpPost("loginpatient")]
        public async Task<IActionResult> Loginpatient(PatientforloginDto patientforloginDto)
        {
            var patientFromRepo = await _repo.LoginPatients(patientforloginDto.PatientId, patientforloginDto.Password);

            if (patientFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier , patientFromRepo.PatientId.ToString()),

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key , SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }

        

        [HttpPost("logindoctor")]
        
        public async Task<IActionResult> Logindoctor(DoctorforloginDto doctorforloginDto)
        {
            var doctorFromRepo = await _repo.LoginDoctor(doctorforloginDto.DoctorId, doctorforloginDto.Password);

            if (doctorFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier , doctorFromRepo.DoctorId.ToString()),

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key , SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }



    }
}