using System.ComponentModel.DataAnnotations;

namespace email_sendler.Models;

/// <summary>
/// This model describes data which will be used in mailout 
/// </summary>
public class MailoutModel
{
    /// <summary>
    /// Subject for all emails in mailout
    /// </summary>
    
    [Required]
    [StringLength(30)]
    [MinLength(1)]
    public string Subject { get; set; }
    /// <summary>
    /// Text for all emails in mailout
    /// </summary>
    
    [Required]
    [StringLength(30000)]
    [MinLength(1)]
    public string Body { get; set; }
    /// <summary>
    /// List of all recipients for mailout
    /// </summary>
    
    [Required]
    [EmailList]
    public List<string> Recipients { get; set; }
}