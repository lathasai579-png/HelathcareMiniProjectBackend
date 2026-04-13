using System;
using System.Collections.Generic;
using System.Text;
using HealthcareApp.Entities;
namespace HealthcareApp.DAL.Repository
{
        public interface IDoctorRepository
        {
            Task<IEnumerable<Doctor>> GetAllAsync();
            Task<Doctor> GetByIdAsync(int id);
            Task AddAsync(Doctor doctor);
            Task UpdateAsync(Doctor doctor);
            Task DeleteAsync(int id);
        }
    }