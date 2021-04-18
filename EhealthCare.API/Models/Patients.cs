using System;
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

        public int Phonenumber {get; set;}

        public string Address {get; set;}

        public DateTime LastActive {get; set;}
    }
}