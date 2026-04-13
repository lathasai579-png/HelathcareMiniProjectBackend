using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthcareApp.Entities
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Doctor name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Specialization is required")]
        [StringLength(100)]
        public string Specialization { get; set; }
        public string AvailableTimeSlot { get; set; }
        
    }
}
