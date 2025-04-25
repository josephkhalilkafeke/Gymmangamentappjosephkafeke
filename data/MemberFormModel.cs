using System.ComponentModel.DataAnnotations;
namespace finalprojectjosephkafekecprg211.Data
{
    public class MemberFormModel
    {
        [Required(ErrorMessage = "Full name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Join Date is required")]
        public DateTime JoinDate { get; set; } = DateTime.Today;
        [Required(ErrorMessage = "Membership End Date is required")]
        [DateGreaterThan(nameof(JoinDate), ErrorMessage = "End date must be after join date")]
        public DateTime MembershipEnd { get; set; } = DateTime.Today.AddMonths(1);
    }
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;
        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var currentValue = (DateTime)value!;
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            var comparisonValue = (DateTime)property!.GetValue(validationContext.ObjectInstance)!;
            if (currentValue <= comparisonValue)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}