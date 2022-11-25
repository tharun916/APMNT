using System;
using System.ComponentModel.DataAnnotations;

namespace DRAPT.API.Entities
{
    public class Appointment
    {
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public string Op { get; set; }
    }
}
