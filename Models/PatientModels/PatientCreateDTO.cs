using System.ComponentModel.DataAnnotations;
namespace PatientAppointmentSystem.Models.PatientModels
{
    public class PatientCreateDTO
    {
        [Required]
        public string FirstName { get; set; }= null!;
        [Required]
        public string LastName { get; set; }= null!;
        [Required]
        public string Email { get; set; }= null!;
        [Required]
        public string Gender { get; set; }= null!;
        [Required]
        public string PhoneNumber { get; set; }= null!;
        [Required]
        public string City{ get; set; }= null!;
        public string DateOfBirth { get; set; }= null!;
    }
}
