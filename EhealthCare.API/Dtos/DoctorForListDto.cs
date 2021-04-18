using System;

namespace EhealthCare.API.Dtos
{
    public class DoctorForListDto
    {
        public int DoctorId {get; set;}

        public string DoctorName {get; set;}

        public byte[] PasswordHash {get; set;}

        public byte[] PasswordSalt {get; set;}

        public int Phonenumber {get; set;}

        public string TypeofDoctor {get; set;}

        public string Address {get; set;}

        public DateTime LastActive {get; set;}
    }
}