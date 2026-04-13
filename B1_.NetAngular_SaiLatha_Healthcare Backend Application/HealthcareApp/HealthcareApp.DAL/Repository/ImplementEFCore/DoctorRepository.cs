using System;
using System.Collections.Generic;
using System.Text;
using HealthcareApp.Entities;
using Microsoft.EntityFrameworkCore;
namespace HealthcareApp.DAL.Repository.ImplementEFCore
{ 
        public class DoctorRepository : IDoctorRepository
        {
            private readonly AppDbContext _context;

            public DoctorRepository(AppDbContext context)
            {
                _context = context;
            }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            try
            {
                return await _context.Doctors
                    .Select(d => new Doctor
                    {
                        DoctorId = d.DoctorId,
                        Name = d.Name,
                        Specialization = d.Specialization,
                        AvailableTimeSlot = d.AvailableTimeSlot
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching doctors: " + ex.Message);
            }
        }

        public async Task<Doctor> GetByIdAsync(int id)
            {
                try
                {
                    return await _context.Doctors.FindAsync(id);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error getting doctor: " + ex.Message);
                }
            }

            public async Task AddAsync(Doctor doctor)
            {
                try
                {
                await _context.Doctors.AddAsync(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Doctor add failed: " + ex.Message);
                }
            }

            public async Task UpdateAsync(Doctor doctor)
            {
                try
                {
                    _context.Doctors.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Doctor update failed: " + ex.Message);
                }
            }

            public async Task DeleteAsync(int id)
            {
                try
                {
                    var data = await _context.Doctors.FindAsync(id);

                    if (data != null)
                    {
                        _context.Doctors.Remove(data);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Doctor delete failed: " + ex.Message);
                }
            }
        }
    }
