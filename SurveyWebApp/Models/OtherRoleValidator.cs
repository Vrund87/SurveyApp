using System.ComponentModel.DataAnnotations;

namespace SurveyWebApp.Models
{
    public class OtherRoleValidator : ValidationAttribute
    {
        private readonly string otherFieldName;

        public OtherRoleValidator(string otherFieldName)
        {
            this.otherFieldName = otherFieldName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Get the value of the other field
            string otherFieldValue = validationContext.ObjectType.GetProperty(otherFieldName)?.GetValue(validationContext.ObjectInstance) as string;

            if (otherFieldValue == "Other")
            {
                Console.WriteLine("other");
                if(value!=null)
                {
                    string str = value.ToString();
                    if (str.Length <= 30 && str.Length >= 1)
                    {
                        return null;
                    }
                    else
                    {
                        return new ValidationResult("Role should be min of 1 character and at max 30 characters", new[] { validationContext.MemberName });
                    }
                }
                else
                {
                    return new ValidationResult("Role should be min of 1 character and at max 30 characters", new[] { validationContext.MemberName });
                }
            }
            Console.WriteLine("not other = "+otherFieldValue); 
            return null;
        }
    }
}
