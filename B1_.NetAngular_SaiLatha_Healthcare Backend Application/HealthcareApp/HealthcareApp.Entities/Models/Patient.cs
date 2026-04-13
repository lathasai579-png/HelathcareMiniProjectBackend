using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HealthcareApp.Entities
{
        public class Patient
        {

        
        public int PatientId { get; set; }
        
        public string Name { get; set; }

        public int Age { get; set; }

         public string Gender { get; set; }

            public string PhoneNumber { get; set; }

            public string Email { get; set; }
            public string MedicalNotes { get; set; }
        }
    }

