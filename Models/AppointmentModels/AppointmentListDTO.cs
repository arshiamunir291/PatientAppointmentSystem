namespace PatientAppointmentSystem.Models.AppointmentModels
{
    public class AppointmentListDTO
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }= null!;
        public string PhysicianName { get; set; }= null!;
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public string Status{ get; set; }= null!;
    }
}
