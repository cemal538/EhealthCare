using System.Collections.Generic;
using System.Threading.Tasks;
using EhealthCare.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EhealthCare.API.Data
{
    public class EhealthCareRepository : IHealthCareRepository
    {
        private readonly DataContext _context;
        public EhealthCareRepository(DataContext context)
        {
            _context = context;

        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public  async Task<Doctors> GetDoctor(int id)
        {
            var doctor = await _context.Doctor.FirstOrDefaultAsync(d => d.DoctorId == id);

            return doctor; 
        }

        public  async Task<IEnumerable<Doctors>> GetDoctors()
        {
           var doctors = await _context.Doctor.ToListAsync();

           return doctors;
        }

        public  async Task<Patients> GetPatient(int id)
        {
            var patient = await _context.Patient.FirstOrDefaultAsync(p => p.PatientId == id);

            return patient;
        }

        public async Task<IEnumerable<Patients>> GetPatients()
        {
            var patients = await _context.Patient.ToListAsync();
            return patients;

        }
    }
}