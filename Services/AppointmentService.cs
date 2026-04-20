using PatientAppointmentSystem.Repositories.Interfaces;
using PatientAppointmentSystem.Services.Interfaces;
using PatientAppointmentSystem.Entities;
using PatientAppointmentSystem.Models.AppointmentModels;
namespace PatientAppointmentSystem.Services
{
    public class AppointmentService(IAppointmentRepository appointmentRepository) : IAppointmentService
    {
        public async Task<List<AppointmentListDTO>> GetAppointments()
        {
            var appointments = await appointmentRepository.GetAllAppointmentsAsync();
            return appointments.Select(a => new AppointmentListDTO
            {
                AppointmentId = a.AppointmentId,
                PatientName = a.Patient.FirstName + " " + a.Patient.LastName,
                PhysicianName = a.Physician.FirstName + " " + a.Physician.LastName,
                AppointmentDate = a.AppointmentDate,
                AppointmentTime = a.AppointmentTime,
                Status = a.Status
            }).ToList();
        }
        public async Task<AppointmentDetailDTO?> GetAppointmentById(int id)
        {
            var appointment = await appointmentRepository.GetAppointmentByIdAsync(id);
            if (appointment == null) return null;
            return new AppointmentDetailDTO
            {
                AppointmentId = appointment.AppointmentId,
                PatientName = appointment.Patient.FirstName + " " + appointment.Patient.LastName,
                PhysicianName = appointment.Physician.FirstName + " " + appointment.Physician.LastName,
                AppointmentDate = appointment.AppointmentDate,
                AppointmentTime = appointment.AppointmentTime,
                Status = appointment.Status,
                VisitType = appointment.VisitType,
                Notes = appointment.Notes ?? string.Empty
            };
        }
        public async Task<AppointmentListDTO> AddAppointment(AppointmentCreateDTO appointment)
        {
            var newAppointment = new Appointment
            {
                PatientId = appointment.PatientId,
                PhysicianId = appointment.PhysicianId,
                AppointmentDate = appointment.AppointmentDate,
                AppointmentTime = appointment.AppointmentTime,
                Status = "Scheduled",
                VisitType = appointment.VisitType
            };
            var createdAppointment = await appointmentRepository.AddAppointmentAsync(newAppointment);
            // reload with related data
            var fullAppointment = await appointmentRepository.GetAppointmentByIdAsync(createdAppointment.AppointmentId);
            if (fullAppointment == null)
            {
                throw new InvalidOperationException("Failed to retrieve the created appointment.");
            }
            return new AppointmentListDTO
            {
                AppointmentId = fullAppointment.AppointmentId,
                PatientName = fullAppointment.Patient.FirstName + " " + fullAppointment.Patient.LastName,
                PhysicianName = fullAppointment.Physician.FirstName + " " + fullAppointment.Physician.LastName,
                AppointmentDate = fullAppointment.AppointmentDate,
                AppointmentTime = fullAppointment.AppointmentTime,
                Status = fullAppointment.Status
            };
        }
        public async Task<AppointmentDetailDTO?> UpdateAppointment(int id, AppointmentUpdateDTO appointment)
        {
            var appointmentToUpdate = await appointmentRepository.GetAppointmentByIdAsync(id);
            if (appointmentToUpdate == null) return null;
            if (appointment.Status is not null)
            {
                appointmentToUpdate.Status = appointment.Status;
            }
            await appointmentRepository.UpdateAppointmentAsync(appointmentToUpdate);
            return new AppointmentDetailDTO
            {
                AppointmentId = appointmentToUpdate.AppointmentId,
                PatientName = appointmentToUpdate.Patient.FirstName + " " + appointmentToUpdate.Patient.LastName,
                PhysicianName = appointmentToUpdate.Physician.FirstName + " " + appointmentToUpdate.Physician.LastName,
                AppointmentDate = appointmentToUpdate.AppointmentDate,
                AppointmentTime = appointmentToUpdate.AppointmentTime,
                Status = appointmentToUpdate.Status,
                VisitType = appointmentToUpdate.VisitType,
                Notes = appointmentToUpdate.Notes ?? string.Empty
            };
        }

        public async Task<List<AppointmentListDTO>> GetAppointmentsByPatientId(int patientId)
        {
            var patientAppointments= await appointmentRepository.GetAppointmentsByPatientIdAsync(patientId);
            return patientAppointments.Select(a => new AppointmentListDTO
            {
                AppointmentId = a.AppointmentId,
                PatientName = a.Patient.FirstName + " " + a.Patient.LastName,
                PhysicianName = a.Physician.FirstName + " " + a.Physician.LastName,
                AppointmentDate = a.AppointmentDate,
                AppointmentTime = a.AppointmentTime,
                Status = a.Status
            }).ToList();
        }
        public async Task<List<AppointmentListDTO>> GetAppointmentsByPhysicianId(int physicianId)
        {
            var physicianAppointments= await appointmentRepository.GetAppointmentsByPhysicianIdAsync(physicianId);
            return physicianAppointments.Select(a => new AppointmentListDTO
            {
                AppointmentId = a.AppointmentId,
                PatientName = a.Patient.FirstName + " " + a.Patient.LastName,
                PhysicianName = a.Physician.FirstName + " " + a.Physician.LastName,
                AppointmentDate = a.AppointmentDate,
                AppointmentTime = a.AppointmentTime,
                Status = a.Status
            }).ToList();
        }
    }
}
