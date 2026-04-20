using System;
using System.Collections.Generic;

namespace PatientAppointmentSystem.Entities;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int PatientId { get; set; }

    public int PhysicianId { get; set; }

    public DateOnly AppointmentDate { get; set; }

    public TimeOnly AppointmentTime { get; set; }

    public string Status { get; set; } = null!;

    public string VisitType { get; set; } = null!;

    public string? Notes { get; set; }

    public  Patient Patient { get; set; } = null!;

    public  Physician Physician { get; set; } = null!;
}
