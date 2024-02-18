using System.ComponentModel.DataAnnotations;

namespace mvc_practice.Models
{
    public class EmployeeClass
    {
        public string LoginName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string FullName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
    }
}
