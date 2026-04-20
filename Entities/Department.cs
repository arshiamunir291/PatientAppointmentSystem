using System;
using System.Collections.Generic;

namespace PatientAppointmentSystem.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public  ICollection<Physician> Physicians { get; set; } = new List<Physician>();
}
