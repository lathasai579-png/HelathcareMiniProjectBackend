using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthcareApp.BLL.DTOs
{
    public class DoctorDto
    {
        [Key]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Doctor name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Specialization is required")]
        [StringLength(100)]
        public string Specialization { get; set; }
        [Required(ErrorMessage = "Available time slot is required")]
        [Display(Name = "Available Time Slot")]
        public string AvailableTimeSlot { get; set; }


}
}