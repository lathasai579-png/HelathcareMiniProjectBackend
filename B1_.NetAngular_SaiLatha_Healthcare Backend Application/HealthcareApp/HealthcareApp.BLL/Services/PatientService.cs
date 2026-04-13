using System;
using System.Collections.Generic;
using System.Text;
using HealthcareApp.BLL.DTOs;
using HealthcareApp.DAL.Repository;
using HealthcareApp.DAL.Repository.ImplementEFCore;
using HealthcareApp.Entities;
namespace HealthcareApp.BLL.Services
{
        public class PatientService
        {
            private readonly IPatientRepository _repo;

            public PatientService(IPatientRepository repo)
            {
                _repo = repo;
            }

            public async Task<List<PatientDto>> GetAllAsync()
            {
                try
                {
                    var data = await _repo.GetAllAsync();

                    return data.Select(p => new PatientDto
                    {
                        PatientId = p.PatientId,
                        Name = p.Name,
                        Age = p.Age,
                        Gender = p.Gender,
                        PhoneNumber = p.PhoneNumber,
                        Email = p.Email,
                        MedicalNotes = p.MedicalNotes
                    }).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching patients: " + ex.Message);
                }
            }

            public async Task<List<PatientDto>> SearchAsync(string keyword)
            {
                try
                {
                    var data = await _repo.SearchAsync(keyword);

                    return data.Select(p => new PatientDto
                    {
                        PatientId = p.PatientId,
                        Name = p.Name,
                        Age = p.Age,
                        Gender = p.Gender,
                        PhoneNumber = p.PhoneNumber,
                        Email = p.Email,
                        MedicalNotes = p.MedicalNotes
                    }).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error searching patients: " + ex.Message);
                }
            }

            public async Task<PatientDto> GetByIdAsync(int id)
            {
                try
                {
                    var p = await _repo.GetByIdAsync(id);

                    if (p == null)
                        return null;

                    return new PatientDto
                    {
                        PatientId = p.PatientId,
                        Name = p.Name,
                        Age = p.Age,
                        Gender = p.Gender,
                        PhoneNumber = p.PhoneNumber,
                        Email = p.Email,
                        MedicalNotes = p.MedicalNotes
                    };
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching patient: " + ex.Message);
                }
            }

            public async Task AddAsync(PatientDto dto)
            {
                try
                {
                    var patient = new Patient
                    {
                        Name = dto.Name,
                        Age = dto.Age,
                        Gender = dto.Gender,
                        PhoneNumber = dto.PhoneNumber,
                        Email = dto.Email,
                        MedicalNotes = dto.MedicalNotes
                    };

                    await _repo.AddAsync(patient);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding patient: " + ex.Message);
                }
            }

            public async Task UpdateAsync(PatientDto dto)
            {
                try
                {
                    var patient = new Patient
                    {
                        PatientId = dto.PatientId,
                        Name = dto.Name,
                        Age = dto.Age,
                        Gender = dto.Gender,
                        PhoneNumber = dto.PhoneNumber,
                        Email = dto.Email,
                        MedicalNotes = dto.MedicalNotes
                    };

                    await _repo.UpdateAsync(patient);
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
                    await _repo.DeleteAsync(id);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error deleting patient: " + ex.Message);
                }
            }
        }
    }