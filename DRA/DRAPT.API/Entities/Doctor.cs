using System.ComponentModel.DataAnnotations;

namespace DRAPT.API.Entities
{
    public class Doctor
    {
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public string Doctorname { get; set; }
    }
}
