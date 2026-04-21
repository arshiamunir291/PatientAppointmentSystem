

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

_context.Patients.Select(p => new {
    p.PatientId,
    p.FullName,
    p.Appointments
});

**SQL**

SELECT p.PatientId, p.FirstName+ " " + p.LastName AS FullName, a.*
FROM Patients p
LEFT JOIN Appointments a 
ON p.PatientId = a.PatientId;

## Get Appointments by Doctor

**LINQ**
_context.Appointments
.Where(a => a.DoctorId == doctorId);

SELECT *
FROM Patients p
WHERE  EXISTS (
    SELECT 1 FROM Appointments a
    WHERE a.PatientId = p.PatientId
);

## Get Patients with No Appointments

**LINQ**

_context.Patients
.Where(p => !p.Appointments.Any());

**SQL**
SELECT *
FROM Patients p
WHERE NOT EXISTS (
    SELECT 1 FROM Appointments a
    WHERE a.PatientId = p.PatientId
);


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
