using HealthcareApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareApp.DAL.Repository
{
        public interface IPatientRepository
        {
            Task<IEnumerable<Patient>> GetAllAsync();
            Task<IEnumerable<Patient>> SearchAsync(string keyword);
            Task<Patient> GetByIdAsync(int id);
            Task AddAsync(Patient patient);
            Task UpdateAsync(Patient patient);
            Task DeleteAsync(int id);
            Task<bool> PhoneExistsAsync(string phoneNumber);
        }
    }

