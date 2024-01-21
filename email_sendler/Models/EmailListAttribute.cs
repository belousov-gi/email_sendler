using System.ComponentModel.DataAnnotations;

namespace email_sendler.Models;

/// <summary>
/// Attribute for custom validation of email recipients list 
/// </summary>
public class EmailListAttribute : ValidationAttribute
{
    /// <summary>
    /// Custom validation of list email recipients
    /// </summary>
    /// <param name="value">List of email recipients</param>
    /// <returns>Returns a boolean value of validation the input recipient list</returns>
    public override bool IsValid(object value)
    {
        var recipientList = (List<string>)value;

        foreach (var recipientEmail in recipientList)
        {
            var validObj = new EmailModel
            {
                Recipient = recipientEmail
            };

            var context = new ValidationContext(validObj, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(validObj, context, validationResults, true);

            if (!isValid)
            {
                return false;
            }
        }
        return true;
    }

}