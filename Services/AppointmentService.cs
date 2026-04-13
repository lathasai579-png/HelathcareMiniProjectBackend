using HealthcareApp.DAL.Repository;
using HealthcareApp.Entities;
using System;
using System.Collections.Generic;

namespace HealthcareApp.BLL.Services
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _repo;

        public AppointmentService(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _repo.GetAll();
        }

        public Appointment GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Create(Appointment obj)
        {
            if (obj.Date < DateTime.Now.Date)
                throw new Exception("Date cannot be in past");

            if (_repo.DoctorSlotExists(obj.DoctorId, obj.Date, obj.TimeSlot))
                throw new Exception("Doctor already booked");

            if (_repo.PatientSlotExists(obj.PatientId, obj.Date, obj.TimeSlot))
                throw new Exception("Patient already has appointment");

            _repo.Add(obj);
        }

        public void Update(Appointment obj)
        {
            _repo.Update(obj);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}