using System;

namespace EhealthCare.API.Dtos
{
    public class PatientForListDto
    {
        public int PatientId {get; set;}

        public string PatientName {get; set;}

        public byte[] PasswordHash {get; set;}

        public byte[] PasswordSalt {get; set;}

        public int Phonenumber {get; set;}

        public string Address {get; set;}

        public DateTime LastActive {get; set;}
    }
}