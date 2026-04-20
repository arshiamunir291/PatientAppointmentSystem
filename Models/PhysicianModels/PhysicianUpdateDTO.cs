namespace PatientAppointmentSystem.Models.PhysicianModels
{
    public class PhysicianUpdateDTO
    {  
        public string FirstName { get; set; }= null!;
        public string LastName { get; set; }= null!;
        public string Specialization { get; set; }= null!;
        public decimal ConsultationFee { get; set; }
        public int DepartmentId { get; set; }
    }
}
