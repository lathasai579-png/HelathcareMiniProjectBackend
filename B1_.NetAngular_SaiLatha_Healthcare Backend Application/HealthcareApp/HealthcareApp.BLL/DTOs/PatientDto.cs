using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthcareApp.BLL.DTOs
{
    public class PatientDto
    {
            public int PatientId { get; set; }

            [Required(ErrorMessage = "Name is required")]
            public string Name { get; set; }

            [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
            public int Age { get; set; }

            [Required]
            public string Gender { get; set; }

            [Required]
            [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone must be 10 digits")]
            public string PhoneNumber { get; set; }

            [EmailAddress]
            public string Email { get; set; }

            public string MedicalNotes { get; set; }
        }
    }
