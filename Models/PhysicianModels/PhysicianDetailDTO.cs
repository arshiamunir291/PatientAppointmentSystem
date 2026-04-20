namespace PatientAppointmentSystem.Models.PhysicianModels
{
    public class PhysicianDetailDTO
    {
        public int PhysicianId { get; set; }    
        public string FullName { get; set; }= null!;    
        public string Specialization { get; set; }= null!;
        public decimal ConsultationFee { get; set; }
        public bool IsAvailable { get; set; }
        public string DepartmentName { get; set; }=null!;
    }
}
