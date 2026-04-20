namespace PatientAppointmentSystem.Models.AppointmentModels
{
    public class AppointmentCreateDTO
    {
        public int PatientId { get; set; }
        public int PhysicianId { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public string VisitType { get; set; }= null!;
    }
}
