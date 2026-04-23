using PatientAppointmentSystem.Models.AppointmentModels;

namespace PatientAppointmentSystem.Models.PhysicianModels;

public class PhysicianWithAppoinmentDTO
{
    public int PhysicianId { get; set; }  
    public string FullName { get; set; }=null!;
    public List<AppointmentPhysicianDTO> Appointments { get; set; } = new();
}
