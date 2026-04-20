using PatientAppointmentSystem.Entities;
using PatientAppointmentSystem.Models.PhysicianModels;
using PatientAppointmentSystem.Repositories.Interfaces;
using PatientAppointmentSystem.Services.Interfaces;
namespace PatientAppointmentSystem.Services
{
    public class PhysicianService(IPhysicianRepository physicianRepository) : IPhysicianService
    {

        public async Task<List<PhysicianListDTO>> GetPhysicians()
        {
            {
                var physicians = await physicianRepository.GetAllPhysicainsAsync();
                return physicians.Select(p => new PhysicianListDTO
                {
                    PhysicianId = p.PhysicianId,
                    FullName = $"{p.FirstName} {p.LastName}",
                    DepartmentName = p.Department != null ? p.Department.DepartmentName : "Unknown"
                }).ToList();
            }
        }
        public async Task<PhysicianDetailDTO?> GetPhysicianById(int id)
        {
            var physician = await physicianRepository.GetPhysicianByIdAsync(id);
            return physician == null ? null : new PhysicianDetailDTO
            {
                PhysicianId = physician.PhysicianId,
                FullName = $"{physician.FirstName} {physician.LastName}",
                Specialization = physician.Specialization,
                ConsultationFee = physician.ConsultationFee,
                IsAvailable = physician.IsAvailable,
                DepartmentName = physician.Department.DepartmentName
            };
        }
        public async Task<PhysicianListDTO> AddPhysician(PhysicianCreateDTO dto)
        {
            var physician= new Physician
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Specialization = dto.Specialization,
                ConsultationFee = dto.ConsultationFee,
                DepartmentId = dto.DepartmentId,
                IsAvailable = true
            };
            var createdPhysician = await physicianRepository.AddPhysicianAsync(physician);
            return new PhysicianListDTO
            {
                PhysicianId = createdPhysician.PhysicianId,
                FullName = $"{createdPhysician.FirstName} {createdPhysician.LastName}",
                DepartmentName = createdPhysician.Department.DepartmentName
            };
        }
        public async Task<PhysicianDetailDTO?> UpdatePhysician(int id, PhysicianUpdateDTO physician)
        {
            var existingPhysician = await physicianRepository.GetPhysicianByIdAsync(id); 

            if (existingPhysician == null) return null;
            existingPhysician.FirstName = physician.FirstName;
            existingPhysician.LastName = physician.LastName;
            existingPhysician.DepartmentId = physician.DepartmentId;
            existingPhysician.Specialization = physician.Specialization;
            existingPhysician.ConsultationFee = physician.ConsultationFee;
            existingPhysician.IsAvailable = true;
            await physicianRepository.UpdatePhysicianAsync(existingPhysician);
            return new PhysicianDetailDTO
            {
                PhysicianId = existingPhysician.PhysicianId,
                FullName = $"{existingPhysician.FirstName} {existingPhysician.LastName}",
                Specialization = existingPhysician.Specialization,
                ConsultationFee = existingPhysician.ConsultationFee,
                IsAvailable = existingPhysician.IsAvailable,
                DepartmentName = existingPhysician.Department.DepartmentName
            };
        }
        public async Task<bool> DeletePhysician(int id)
        {
            var existingPhysician = await physicianRepository.GetPhysicianByIdAsync(id);
            if (existingPhysician == null) return false;
            await physicianRepository.DeletePhysicianAsync(existingPhysician);
            return true;
        }
        public async Task<List<PhysicianListDTO>> GetPhysicianWithNoAppointments()
        {
            var physicians = await physicianRepository.GetPhysicianWithNoAppointmentAsync();
             return physicians.Select(p => new PhysicianListDTO
            {
                PhysicianId = p.PhysicianId,
                FullName = $"{p.FirstName} {p.LastName}",
                DepartmentName = p.Department.DepartmentName
            }).ToList();
        }
    }
}
