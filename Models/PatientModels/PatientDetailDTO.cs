namespace PatientAppointmentSystem.Models.PatientModels
{
    public class PatientDetailDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }= null!;
        public string Email { get; set; }= null!;
        public string City{ get; set; }= null!;
        public string PhoneNumber { get; set; }= null!;
    }
}
