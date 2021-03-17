using System.Threading.Tasks;
using EhealthCare.API.Models;

namespace EhealthCare.API.Data
{
    public interface IAuthRepository
    {
        Task<Admin> AddAdmin(Admin admin, string password );
        Task<Doctors> AddDoctor(Doctors doctor, string password );

        Task<Patients> AddPatient(Patients patient, string password);
         Task<Admin> LoginAdmin(string adminname, string password);
         Task<Doctors> LoginDoctor(int doctorId, string password);

         Task<Patients> LoginPatients(int patientId, string password);

         Task<bool> DoctorExists(int doctorId);
         Task<bool> PatientExists(int patientId);
    }
}