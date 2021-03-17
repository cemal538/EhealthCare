using System.ComponentModel.DataAnnotations;

namespace EhealthCare.API.Models
{
    public class Doctors
    {
        [Key]
        public int DoctorId {get; set;}

        public string DoctorName {get; set;}

        public byte[] PasswordHash {get; set;}

        public byte[] PasswordSalt {get; set;}
    }
}