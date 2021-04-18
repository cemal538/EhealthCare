using AutoMapper;
using EhealthCare.API.Dtos;
using EhealthCare.API.Models;

namespace EhealthCare.API.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Doctors, DoctorForListDto>();
            CreateMap<Patients, PatientForListDto>();
        }
        
    }
}