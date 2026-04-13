
using System;
using System.ComponentModel.DataAnnotations;

namespace HealthcareApp.Web.ViewModels
{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }

        // 🔹 Patient
        [Required(ErrorMessage = "Patient is required")]
        public int PatientId { get; set; }

        // 🔹 Doctor
        [Required(ErrorMessage = "Doctor is required")]
        public int DoctorId { get; set; }

        // 🔹 Date
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        // 🔹 Time Slot
        [Required(ErrorMessage = "Time slot is required")]
        public string TimeSlot { get; set; }

        // 🔹 Status (for Edit)
        public string Status { get; set; }

        // 🔹 Optional (for display in Index UI)
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
    }
}