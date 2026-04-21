using PatientAppointmentSystem.Repositories.Interfaces;
using PatientAppointmentSystem.Services.Interfaces;
using PatientAppointmentSystem.Entities;
using PatientAppointmentSystem.Models.AppointmentModels;

namespace PatientAppointmentSystem.Services
{
    public class AppointmentService(
        IAppointmentRepository appointmentRepository,
        IPatientRepository patientRepository,
        IPhysicianRepository physicianRepository
    ) : IAppointmentService
    {
        public async Task<List<AppointmentListDTO>> GetAppointments()
        {
            var appointments = await appointmentRepository.GetAllAppointmentsAsync();
            var result = new List<AppointmentListDTO>();

            foreach (var a in appointments)
            {
                var patient = await patientRepository.GetPatientByIdAsync(a.PatientId);
                var physician = await physicianRepository.GetPhysicianByIdAsync(a.PhysicianId);

                result.Add(new AppointmentListDTO
                {
                    AppointmentId = a.AppointmentId,
                    PatientName = patient != null ? $"{patient.FirstName} {patient.LastName}" : "Unknown",
                    PhysicianName = physician != null ? $"{physician.FirstName} {physician.LastName}" : "Unknown",
                    AppointmentDate = a.AppointmentDate,
                    AppointmentTime = a.AppointmentTime,
                    Status = a.Status
                });
            }

            return result;
        }

        public async Task<AppointmentDetailDTO?> GetAppointmentById(int id)
        {
            var appointment = await appointmentRepository.GetAppointmentByIdAsync(id);
            if (appointment == null) return null;

            var patient = await patientRepository.GetPatientByIdAsync(appointment.PatientId);
            var physician = await physicianRepository.GetPhysicianByIdAsync(appointment.PhysicianId);

            return new AppointmentDetailDTO
            {
                AppointmentId = appointment.AppointmentId,
                PatientName = patient != null ? $"{patient.FirstName} {patient.LastName}" : "Unknown",
                PhysicianName = physician != null ? $"{physician.FirstName} {physician.LastName}" : "Unknown",
                AppointmentDate = appointment.AppointmentDate,
                AppointmentTime = appointment.AppointmentTime,
                Status = appointment.Status,
                VisitType = appointment.VisitType,
                Notes = appointment.Notes ?? string.Empty
            };
        }

        public async Task<AppointmentListDTO> AddAppointment(AppointmentCreateDTO dto)
        {
            var newAppointment = new Appointment
            {
                PatientId = dto.PatientId,
                PhysicianId = dto.PhysicianId,
                AppointmentDate = dto.AppointmentDate,
                AppointmentTime = dto.AppointmentTime,
                Status = "Scheduled",
                VisitType = dto.VisitType
            };

            var created = await appointmentRepository.AddAppointmentAsync(newAppointment);

            var patient = await patientRepository.GetPatientByIdAsync(created.PatientId);
            var physician = await physicianRepository.GetPhysicianByIdAsync(created.PhysicianId);

            return new AppointmentListDTO
            {
                AppointmentId = created.AppointmentId,
                PatientName = patient != null ? $"{patient.FirstName} {patient.LastName}" : "Unknown",
                PhysicianName = physician != null ? $"{physician.FirstName} {physician.LastName}" : "Unknown",
                AppointmentDate = created.AppointmentDate,
                AppointmentTime = created.AppointmentTime,
                Status = created.Status
            };
        }

        public async Task<AppointmentDetailDTO?> UpdateAppointment(int id, AppointmentUpdateDTO dto)
        {
            var appointment = await appointmentRepository.GetAppointmentByIdAsync(id);
            if (appointment == null) return null;

            if (dto.Status != null)
                appointment.Status = dto.Status;

            await appointmentRepository.UpdateAppointmentAsync(appointment);

            var patient = await patientRepository.GetPatientByIdAsync(appointment.PatientId);
            var physician = await physicianRepository.GetPhysicianByIdAsync(appointment.PhysicianId);

            return new AppointmentDetailDTO
            {
                AppointmentId = appointment.AppointmentId,
                PatientName = patient != null ? $"{patient.FirstName} {patient.LastName}" : "Unknown",
                PhysicianName = physician != null ? $"{physician.FirstName} {physician.LastName}" : "Unknown",
                AppointmentDate = appointment.AppointmentDate,
                AppointmentTime = appointment.AppointmentTime,
                Status = appointment.Status,
                VisitType = appointment.VisitType,
                Notes = appointment.Notes ?? string.Empty
            };
        }

        public async Task<List<AppointmentListDTO>> GetAppointmentsByPatientId(int patientId)
        {
            var appointments = await appointmentRepository.GetAppointmentsByPatientIdAsync(patientId);
            var result = new List<AppointmentListDTO>();

            foreach (var a in appointments)
            {
                var patient = await patientRepository.GetPatientByIdAsync(a.PatientId);
                var physician = await physicianRepository.GetPhysicianByIdAsync(a.PhysicianId);

                result.Add(new AppointmentListDTO
                {
                    AppointmentId = a.AppointmentId,
                    PatientName = patient != null ? $"{patient.FirstName} {patient.LastName}" : "Unknown",
                    PhysicianName = physician != null ? $"{physician.FirstName} {physician.LastName}" : "Unknown",
                    AppointmentDate = a.AppointmentDate,
                    AppointmentTime = a.AppointmentTime,
                    Status = a.Status
                });
            }

            return result;
        }

        public async Task<List<AppointmentListDTO>> GetAppointmentsByPhysicianId(int physicianId)
        {
            var appointments = await appointmentRepository.GetAppointmentsByPhysicianIdAsync(physicianId);
            var result = new List<AppointmentListDTO>();

            foreach (var a in appointments)
            {
                var patient = await patientRepository.GetPatientByIdAsync(a.PatientId);
                var physician = await physicianRepository.GetPhysicianByIdAsync(a.PhysicianId);

                result.Add(new AppointmentListDTO
                {
                    AppointmentId = a.AppointmentId,
                    PatientName = patient != null ? $"{patient.FirstName} {patient.LastName}" : "Unknown",
                    PhysicianName = physician != null ? $"{physician.FirstName} {physician.LastName}" : "Unknown",
                    AppointmentDate = a.AppointmentDate,
                    AppointmentTime = a.AppointmentTime,
                    Status = a.Status
                });
            }

            return result;
        }
    }
}