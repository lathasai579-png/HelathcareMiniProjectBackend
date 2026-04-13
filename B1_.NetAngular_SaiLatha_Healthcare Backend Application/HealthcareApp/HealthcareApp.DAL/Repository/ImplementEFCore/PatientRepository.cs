using Microsoft.EntityFrameworkCore;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using HealthcareApp.Entities;
namespace HealthcareApp.DAL.Repository.ImplementEFCore
{ 
        public class PatientRepository : IPatientRepository
        {
            private readonly AppDbContext _context;

            public PatientRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Patient>> GetAllAsync()
            {
                try
                {
                    return await _context.Patients
                        .Select(p => new Patient
                        {
                            PatientId = p.PatientId,
                            Name = p.Name,
                            Age = p.Age,
                            Gender = p.Gender,
                            PhoneNumber = p.PhoneNumber,
                            Email = p.Email,
                            MedicalNotes = p.MedicalNotes
                        }).ToListAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching patients list: " + ex.Message);
                }
            }

            public async Task<IEnumerable<Patient>> SearchAsync(string keyword)
            {
                try
                {
                    return await _context.Patients
                        .Where(p =>
                            p.Name.Contains(keyword) ||
                            p.PhoneNumber.Contains(keyword) ||
                            p.Email.Contains(keyword))
                        .ToListAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error searching patients: " + ex.Message);
                }
            }

            public async Task<Patient> GetByIdAsync(int id)
            {
                try
                {
                    return await _context.Patients.FindAsync(id);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching patient by id: " + ex.Message);
                }
            }

            public async Task AddAsync(Patient patient)
            {
                try
                {
                    await _context.Patients.AddAsync(patient);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding patient: " + ex.Message);
                }
            }

            public async Task UpdateAsync(Patient patient)
            {
                try
                {
                    _context.Patients.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error updating patient: " + ex.Message);
                }
            }

            public async Task DeleteAsync(int id)
            {
                try
                {
                    var data = await _context.Patients.FindAsync(id);
                    if (data != null)
                    {
                        _context.Patients.Remove(data);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Delete failed : " + ex.Message);
                }
            }

            public async Task<bool> PhoneExistsAsync(string phoneNumber)
            {
                try
                {
                    return await _context.Patients
                        .AnyAsync(p => p.PhoneNumber == phoneNumber);
                }
                catch (Exception ex)
                {
                    throw new Exception("Phone check failed: " + ex.Message);
                }
            }

       
    }
    }