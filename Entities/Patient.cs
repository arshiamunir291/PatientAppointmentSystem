using System;
using System.Collections.Generic;

namespace PatientAppointmentSystem.Entities;

public partial class Patient
{
    public int PatientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string City { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public  ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
