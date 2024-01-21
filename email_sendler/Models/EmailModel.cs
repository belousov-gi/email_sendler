using System.ComponentModel.DataAnnotations;

namespace email_sendler.Models;

/// <summary>
/// Model for validation email in recipients list
/// </summary>
/// <see cref="Models.EmailListAttribute"/>
public class EmailModel : ValidationAttribute
{
    /// <summary>
    /// Recipient email
    /// </summary>
    [EmailAddress]
    
    public string Recipient { get; set; }

}