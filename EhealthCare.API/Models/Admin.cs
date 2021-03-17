using System.ComponentModel.DataAnnotations;

namespace EhealthCare.API.Models
{
   
    public class Admin
    {
        [Key]
        public int AdminId {get; set;}
        public string Adminname {get; set;}
     
        public byte[] PasswordHash {get; set;}
       
        public byte[] PasswordSalt{get; set;}
    }
}