using PatientAppointmentSystem.Entities;
using PatientAppointmentSystem.Models.PhysicianModels;
using PatientAppointmentSystem.Repositories.Interfaces;
using PatientAppointmentSystem.Services.Interfaces;

namespace PatientAppointmentSystem.Services
{
    public class PhysicianService(
        IPhysicianRepository physicianRepository,
        IAppointmentRepository appointmentRepository,
        IDepartmentRepository departmentRepository
    ) : IPhysicianService
    {
        public async Task<List<PhysicianListDTO>> GetPhysicians()
        {
            var physicians = await physicianRepository.GetAllPhysicainsAsync();
            var departments = await departmentRepository.GetAllDepartmentsAsync();

            return physicians.Select(p => new PhysicianListDTO
            {
                PhysicianId = p.PhysicianId,
                FullName = $"{p.FirstName} {p.LastName}",
                DepartmentName = departments
                    .FirstOrDefault(d => d.DepartmentId == p.DepartmentId)?.DepartmentName ?? "Unknown"
            }).ToList();
        }

        public async Task<PhysicianDetailDTO?> GetPhysicianById(int id)
        {
            var physician = await physicianRepository.GetPhysicianByIdAsync(id);
            if (physician == null) return null;

            // departmentRepository.GetDepartmentNameById returns a string, not an object with DepartmentName property
            var departmentName = await departmentRepository.GetDepartmentNameById(physician.DepartmentId);

            return new PhysicianDetailDTO
            {
                PhysicianId = physician.PhysicianId,
                FullName = $"{physician.FirstName} {physician.LastName}",
                Specialization = physician.Specialization,
                ConsultationFee = physician.ConsultationFee,
                IsAvailable = physician.IsAvailable,
                DepartmentName = departmentName ?? "Unknown"
            };
        }

        public async Task<PhysicianListDTO> AddPhysician(PhysicianCreateDTO dto)
        {
            var physician = new Physician
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Specialization = dto.Specialization,
                ConsultationFee = dto.ConsultationFee,
                DepartmentId = dto.DepartmentId,
                IsAvailable = true
            };

            var created = await physicianRepository.AddPhysicianAsync(physician);

            // departmentRepository.GetDepartmentNameById returns a string, not an object with DepartmentName property
            var departmentName = await departmentRepository.GetDepartmentNameById(created.DepartmentId);

            return new PhysicianListDTO
            {
                PhysicianId = created.PhysicianId,
                FullName = $"{created.FirstName} {created.LastName}",
                DepartmentName = departmentName ?? "Unknown"
            };
        }

        public async Task<PhysicianDetailDTO?> UpdatePhysician(int id, PhysicianUpdateDTO dto)
        {
            var existing = await physicianRepository.GetPhysicianByIdAsync(id);
            if (existing == null) return null;

            existing.FirstName = dto.FirstName;
            existing.LastName = dto.LastName;
            existing.DepartmentId = dto.DepartmentId;
            existing.Specialization = dto.Specialization;
            existing.ConsultationFee = dto.ConsultationFee;
            existing.IsAvailable = true;

            await physicianRepository.UpdatePhysicianAsync(existing);

            // departmentRepository.GetDepartmentNameById returns a string, not an object with DepartmentName property
            var departmentName = await departmentRepository.GetDepartmentNameById(existing.DepartmentId);

            return new PhysicianDetailDTO
            {
                PhysicianId = existing.PhysicianId,
                FullName = $"{existing.FirstName} {existing.LastName}",
                Specialization = existing.Specialization,
                ConsultationFee = existing.ConsultationFee,
                IsAvailable = existing.IsAvailable,
                DepartmentName = departmentName ?? "Unknown"
            };
        }

        public async Task<bool> DeletePhysician(int id)
        {
            var existing = await physicianRepository.GetPhysicianByIdAsync(id);
            if (existing == null) return false;

            await physicianRepository.DeletePhysicianAsync(existing);
            return true;
        }

        public async Task<List<PhysicianListDTO>> GetPhysicianWithNoAppointments()
        {
            var physicians = await physicianRepository.GetPhysicianWithNoAppointmentAsync();
            var departments = await departmentRepository.GetAllDepartmentsAsync();

            return physicians.Select(p => new PhysicianListDTO
            {
                PhysicianId = p.PhysicianId,
                FullName = $"{p.FirstName} {p.LastName}",
                DepartmentName = departments
                    .FirstOrDefault(d => d.DepartmentId == p.DepartmentId)?.DepartmentName ?? "Unknown"
            }).ToList();
        }

        public async Task<List<PhysicianWithAppoinmentDTO>> GetPhysicianWithAppointments()
        {
            var physicians = await physicianRepository.GetPhysicianWithAppointmentAsync();
            var appointments = await appointmentRepository.GetAllAppointmentsAsync();

            return physicians.Select(p => new PhysicianWithAppoinmentDTO
            {
                PhysicianId = p.PhysicianId,
                FullName = $"{p.FirstName} {p.LastName}",

                Appointments = appointments
                    .Where(a => a.PhysicianId == p.PhysicianId)
                    .Select(a => new PatientAppointmentSystem.Models.AppointmentModels.AppointmentDTO
                    {
                        AppointmentId = a.AppointmentId,
                        PhysicianName = $"{p.FirstName} {p.LastName}",
                        AppointmentDate = a.AppointmentDate,
                        AppointmentTime = a.AppointmentTime,
                        Status = a.Status
                    }).ToList()
            }).ToList();
        }
    }
}