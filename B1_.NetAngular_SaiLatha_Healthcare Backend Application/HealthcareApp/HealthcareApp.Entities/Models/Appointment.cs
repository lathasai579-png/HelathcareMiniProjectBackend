using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Numerics;
namespace HealthcareApp.Entities
{
    public enum AppointmentStatus
    {
        Booked,
        Completed,
        Cancelled
    }

    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string TimeSlot { get; set; }

        public AppointmentStatus Status { get; set; } = AppointmentStatus.Booked;

        // Navigation
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}