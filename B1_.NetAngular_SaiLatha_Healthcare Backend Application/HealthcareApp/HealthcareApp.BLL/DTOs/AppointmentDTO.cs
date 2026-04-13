using HealthcareApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace HealthcareApp.BLL.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string TimeSlot { get; set; }

        public string Status { get; set; }
    }
}