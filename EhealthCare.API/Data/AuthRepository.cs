using System;
using System.Threading.Tasks;
using EhealthCare.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EhealthCare.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<Admin> AddAdmin(Admin admin, string password)
        {
            byte[] passwordHash , passwordSalt;
            CreatePasswordHash4(password, out passwordHash, out passwordSalt);

            admin.PasswordHash = passwordHash;
            admin.PasswordSalt = passwordSalt;

            await _context.Admin.AddAsync(admin);
            await _context.SaveChangesAsync();

            return admin;
        }

        private void CreatePasswordHash4(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                 
            }
            
        }
        public async Task<Doctors> AddDoctor(Doctors doctor, string password)
        {
            byte[] passwordHash , passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            doctor.PasswordHash = passwordHash;
            doctor.PasswordSalt = passwordSalt;

            await _context.Doctor.AddAsync(doctor);
            await _context.SaveChangesAsync();

            return doctor;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                 
            }
            
        }

        public async Task<Patients> AddPatient(Patients patient, string password)
        {
             byte[] passwordHash , passwordSalt;
            CreatePasswordHash2(password, out passwordHash, out passwordSalt);

            patient.PasswordHash = passwordHash;
            patient.PasswordSalt = passwordSalt;

            await _context.Patient.AddAsync(patient);
            await _context.SaveChangesAsync();

            return patient;
        }
         private void CreatePasswordHash2(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                 
            }
            
        }

        public async Task<bool> DoctorExists(int doctorId)
        {
            if(await _context.Doctor.AnyAsync(x => x.DoctorId == doctorId))
                return true;

            return false;    
        }

        public async  Task<Admin> LoginAdmin(string adminname, string password)
        {
            var admin = await _context.Admin.FirstOrDefaultAsync(x => x.Adminname == adminname);

            if (admin == null)
                 return null;

            if (!VerifyPasswordHash(password, admin.PasswordHash, admin.PasswordSalt)) 
                return null;    
            
            return admin;    
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
             using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++ )
                {
                    if(computedHash[i] != passwordHash[i]) return false;
                }
                 
            }
            return true;
        }

        public async Task<Doctors> LoginDoctor(int doctorId, string password)
        {
             var doctor = await _context.Doctor.FirstOrDefaultAsync(x => x.DoctorId == doctorId);

            if (doctor == null)
                 return null;

            if (!VerifyPasswordHash2(password, doctor.PasswordHash, doctor.PasswordSalt)) 
                return null;    
            
            return doctor;    
        }
         private bool VerifyPasswordHash2(string password, byte[] passwordHash, byte[] passwordSalt)
        {
             using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++ )
                {
                    if(computedHash[i] != passwordHash[i]) return false;
                }
                 
            }
            return true;
        }

        public async Task<Patients> LoginPatients(int patientId, string password)
        {
              var patient = await _context.Patient.FirstOrDefaultAsync(x => x.PatientId == patientId);

            if (patient == null)
                 return null;

            if (!VerifyPasswordHash3(password, patient.PasswordHash, patient.PasswordSalt)) 
                return null;    
            
            return patient;    
        }
        private bool VerifyPasswordHash3(string password, byte[] passwordHash, byte[] passwordSalt)
        {
             using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++ )
                {
                    if(computedHash[i] != passwordHash[i]) return false;
                }
                 
            }
            return true;
        }

        public async Task<bool> PatientExists(int patientId)
        {
            if(await _context.Patient.AnyAsync(x => x.PatientId == patientId))
                return true;

            return false;    
        }
    }
}