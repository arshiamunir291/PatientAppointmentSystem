namespace PatientAppointmentSystem.Models.PhysicianModels
{
    public class PhysicianListDTO
    {
        public int PhysicianId { get; set; }    
        public string FullName { get; set; }= null!;
        public string DepartmentName { get; set; }=null!;
    }
}
