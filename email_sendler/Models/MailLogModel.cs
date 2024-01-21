using System.ComponentModel.DataAnnotations;

namespace email_sendler.Models;

/// <summary>
/// This model describes all data which will be saved in storage
/// </summary>
public class MailLogModel
{
    /// <summary>
    /// Identificator of email in database using as primary key. It's specifyied automatically while adding in DB.
    /// Don't specify id manually.
    /// </summary>
    
    public int Id { get; set; }
    /// <summary>
    /// Subject of email has been specified before start of dispatching
    /// </summary>

    public string Subject { get; set; }
    /// <summary>
    /// Text of email has been specified before start of dispatching
    /// </summary>

    public string Body { get; set; }
    /// <summary>
    /// Recipient of email has been specified before start of dispatching
    /// </summary>

    [EmailAddress]
    public string Recipient { get; set; }
    /// <summary>
    /// Date and time when email has been sent
    /// </summary>
 
    public DateTime DateTimeDispatch { get; set; }
    /// <summary>
    /// Result of dispatching email: OK or failed
    /// </summary>

    public string Result { get; set; }
    /// <summary>
    /// Contains error message, if email dispatching has failed
    /// </summary>
    public string? FailedMessage { get; set; }
}