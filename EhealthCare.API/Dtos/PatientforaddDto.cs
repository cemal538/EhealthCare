using System.ComponentModel.DataAnnotations;

namespace EhealthCare.API.Dtos
{
    public class PatientforaddDto
    {
        [Required]
        public int PatientId {get; set;}
        
        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage= "You must write password between 5 and 10 characters")]
        public string Password {get; set;}
    }
}