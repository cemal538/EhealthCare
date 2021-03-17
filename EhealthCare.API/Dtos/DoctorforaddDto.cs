using System.ComponentModel.DataAnnotations;

namespace EhealthCare.API.Dtos
{
    public class DoctorforaddDto
    {
        [Required]
        public int DoctorId {get; set;}
        
        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage= "You must write password between 5 and 10 characters")]
        public string Password {get; set;}
    }
}