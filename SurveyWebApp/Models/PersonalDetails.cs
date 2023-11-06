using System.ComponentModel.DataAnnotations;

namespace SurveyWebApp.Models
{
    public class PersonalDetails:ValidationAttribute
    {

        [Required(ErrorMessage = "Please enter your name")]
        public string name { get; set; }

        [Required(ErrorMessage ="Please select one of the four options")]
        public string yearsOfExperience { get; set; } = string.Empty;

        public bool canContact { get; set; } = false;
        public string email { get; set; } = String.Empty;
        public string phone { get; set; } = String.Empty;
        public string linkedIn { get; set; } = String.Empty;

        [Required(ErrorMessage ="Please select your current role")]
        public string currentRole { get; set; } = string.Empty;

        [OtherRoleValidator("currentRole")]
        public string otherRole { get; set; } = String.Empty;

        
    

    }
}
