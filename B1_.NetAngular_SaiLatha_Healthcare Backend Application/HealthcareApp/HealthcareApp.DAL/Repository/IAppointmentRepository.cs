using System;
using System.Collections.Generic;
using System.Text;
using HealthcareApp.Entities;
namespace HealthcareApp.DAL.Repository
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAll();
        Appointment GetById(int id);
        void Add(Appointment obj);
        void Update(Appointment obj);
        void Delete(int id);

        bool DoctorSlotExists(int doctorId, DateTime date, string timeSlot);
        bool PatientSlotExists(int patientId, DateTime date, string timeSlot);
    }
}