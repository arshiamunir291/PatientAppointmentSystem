

** Mapping Choices**

* Used **Fluent API** to define relationships because it gives more control than data annotations.
  
** Relationships implemented:**

  * One Patient can have many Appointments
  * One Doctor can have many Appointments
* I added navigation properties to easily access related data.
* I did not use lazy loading, instead I wrote explicit queries.

# LINQ vs SQL

## Get Patients with Appointments

**LINQ**
context.Patients.AsNoTracking()
                .Where(p => context.Appointments.Any(a => a.PatientId == p.PatientId))
                .ToListAsync();


**SQL**
select p.PatientID,
p.FirstName+ '' + p.LastName As PatientName,
ph.FirstName+ ' '+ph.LastName As PhysicianName,
a.AppointmentDate,a.AppointmentTime,a.Status
from Patients p
join Appointments a
on a.PatientID=p.PatientID
join Physicians ph
on ph.PhysicianID=a.PhysicianID

## Get Appointments by Physicians

**LINQ**
context.Physicians.AsNoTracking()
                .Where(d => context.Appointments.Any(a => a.PhysicianId == d.PhysicianId)).AsNoTracking()
                .ToListAsync();
        }

**SQL**
select ph.PhysicianID,
ph.FirstName+ ' '+ph.LastName as PhysicianName ,
p.FirstName+ ' ' + p.LastName As PatientName,
a.AppointmentDate,a.AppointmentTime,a.Status
from Physicians ph
join Appointments a
on a.PhysicianID=ph.PhysicianID
join Patients p
on p.PatientID=a.PatientID

## Get Patients with No Appointments

**LINQ**

context.Patients.AsNoTracking()
                .Where(p => !context.Appointments.Any(a => a.PatientId == p.PatientId))
                .ToListAsync();

**SQL**
select p.PatientID,
p.FirstName+ ' '+p.LastName as PatientName 
from Patients p
where not exists(
select 1 from Appointments a
where a.PatientID=p.PatientID
)


## Get Physicians with No Appointments
**LINQ**

context.Physicians.AsNoTracking()
                .Where(d => !context.Appointments.Any(a => a.PhysicianId == d.PhysicianId)).AsNoTracking()
                .ToListAsync();

**SQL**

select ph.PhysicianID,
ph.FirstName+ ' '+ph.LastName as PhysicianName ,
DepartmentName
from Physicians ph
join Departments d
on d.DepartmentID=ph.DepartmentID
where not exists(
select 1 from Appointments a
where a.PhysicianID=ph.PhysicianID
)


# Tracking Decisions

*  Used `AsNoTracking()` in read-only queries
* This helps improve performance because EF Core does not track changes
* Tracking is only needed when updating data


## What improve performance

* Used `Select` instead of `Include` to avoid loading unnecessary data
* Applied filtering using `Where` before executing queries

## Where EF Core hurt

* Complex LINQ queries can generate inefficient SQL
* Using `Include()` too much can slow down queries
* Tracking large data can affect performance
* Sometimes raw SQL is better for complex queries

# Where EF Core helps

EF Core makes development easier and faster, especially for simple CRUD operations.
But for complex queries or performance-critical cases, using SQL is a better option.
