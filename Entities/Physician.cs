using System;
using System.Collections.Generic;

namespace PatientAppointmentSystem.Entities;

public partial class Physician
{
    public int PhysicianId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public string Specialization { get; set; } = null!;

    public decimal ConsultationFee { get; set; }

    public bool IsAvailable { get; set; }

    public  ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public  Department Department { get; set; } = null!;
}
