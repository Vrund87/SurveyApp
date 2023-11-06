using System.ComponentModel.DataAnnotations;

namespace SurveyWebApp.Models
{
    public class SurveyQuestions:ValidationAttribute
    {
        [Required(ErrorMessage = "Please Select Yes or No")]
        public string sq1 { get; set; }

        [Required(ErrorMessage = "Please Select Yes or No")]
        public string sq2 { get; set; }

        [Required(ErrorMessage = "Please Select Yes or No")]
        public string sq3 { get; set; } = String.Empty;

        public bool sq4a { get; set; } = false;

        public bool sq4b { get; set; } = false;

        public bool sq4c { get; set; } = false;

        public bool sq4d { get; set; } = false;

        [SurveyQuestions]
        public string sq4Other { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please Select one of the options")]
        public string sq5 { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please Select one of the options")]
        public string sq6 { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please Select one of the options")]
        public string sq7 { get; set; } = String.Empty;

        public string sq8 { get; set; } = String.Empty;

        public string sq9 { get; set; } = String.Empty;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                string str = value.ToString();
                if (str.Length <= 200)
                {
                    return null;
                }
                else
                {
                    return new ValidationResult("Max Limit is 200 words", new[] { validationContext.MemberName });
                }
            }
            return null;
        }
    }
}
