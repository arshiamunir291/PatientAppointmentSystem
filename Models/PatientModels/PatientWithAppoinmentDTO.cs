using PatientAppointmentSystem.Models.AppointmentModels;

namespace PatientAppointmentSystem.Models.PatientModels
{
    public class PatientWithAppoinmentDTO
    {
        public int PatientId { get; set; }  
        public string FullName { get; set; }=null!;
        public List<AppointmentDTO> Appointments { get; set; } = new();
    }
}
