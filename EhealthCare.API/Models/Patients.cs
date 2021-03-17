using System.ComponentModel.DataAnnotations;

namespace EhealthCare.API.Models
{
    public class Patients
    {
         
        [Key]
        public int PatientId {get; set;}

        public string PatientName {get; set;}

        public byte[] PasswordHash {get; set;}

        public byte[] PasswordSalt {get; set;}
    }
}