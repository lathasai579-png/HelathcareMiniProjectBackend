using HealthcareApp.DAL.Repository;
using HealthcareApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthcareApp.DAL.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
                .ToList();
        }

        public Appointment GetById(int id)
        {
            return _context.Appointments.Find(id);
        }

        public void Add(Appointment obj)
        {
            _context.Appointments.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Appointment obj)
        {
            _context.Appointments.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = _context.Appointments.Find(id);
            if (data != null)
            {
                _context.Appointments.Remove(data);
                _context.SaveChanges();
            }
        }

        public bool DoctorSlotExists(int doctorId, DateTime date, string timeSlot)
        {
            return _context.Appointments.Any(a =>
                a.DoctorId == doctorId &&
                a.Date.Date == date.Date &&
                a.TimeSlot == timeSlot);
        }

        public bool PatientSlotExists(int patientId, DateTime date, string timeSlot)
        {
            return _context.Appointments.Any(a =>
                a.PatientId == patientId &&
                a.Date.Date == date.Date &&
                a.TimeSlot == timeSlot);
        }
    }
}