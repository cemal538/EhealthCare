using System.Collections.Generic;
using System.Threading.Tasks;
using EhealthCare.API.Models;

namespace EhealthCare.API.Data
{
    public interface IHealthCareRepository
    {
         void Delete<T>(T entity) where T: class;

         Task<IEnumerable<Patients>> GetPatients();

         Task<Patients> GetPatient(int id);

         Task<IEnumerable<Doctors>> GetDoctors();

         Task<Doctors> GetDoctor(int id);
    }
}