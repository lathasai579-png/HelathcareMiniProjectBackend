using System;
using System.Collections.Generic;
using System.Text;
using HealthcareApp.BLL.DTOs;
using HealthcareApp.DAL.Repository;
using HealthcareApp.Entities;
namespace HealthcareApp.BLL.Services
{
        public class DoctorService
        {
            private readonly IDoctorRepository _repo;

            public DoctorService(IDoctorRepository repo)
            {
                _repo = repo;
            }

            public async Task<List<DoctorDto>> GetAllAsync()
            {
                try
                {
                    var data = await _repo.GetAllAsync();

                    return data.Select(d => new DoctorDto
                    {
                        DoctorId = d.DoctorId,
                        Name = d.Name,
                        Specialization = d.Specialization,
                        AvailableTimeSlot = d.AvailableTimeSlot
                    }).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Service error: " + ex.Message);
                }
            }

            public async Task<DoctorDto> GetByIdAsync(int id)
            {
                try
                {
                    var d = await _repo.GetByIdAsync(id);

                    if (d == null) return null;

                    return new DoctorDto
                    {
                        DoctorId = d.DoctorId,
                        Name = d.Name,
                        Specialization = d.Specialization,
                        AvailableTimeSlot = d.AvailableTimeSlot
                    };
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public async Task AddAsync(DoctorDto dto)
            {
                try
                {
                    await _repo.AddAsync(new Doctor
                    {
                        Name = dto.Name,
                        Specialization = dto.Specialization,
                        AvailableTimeSlot = dto.AvailableTimeSlot
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public async Task UpdateAsync(DoctorDto dto)
            {
                try
                {
                    await _repo.UpdateAsync(new Doctor
                    {
                        DoctorId = dto.DoctorId,
                        Name = dto.Name,
                        Specialization = dto.Specialization,
                        AvailableTimeSlot = dto.AvailableTimeSlot
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public async Task DeleteAsync(int id)
            {
                try
                {
                    await _repo.DeleteAsync(id);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }