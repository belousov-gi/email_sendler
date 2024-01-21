namespace email_sendler.Models;

/// <summary>
/// This model describes required setting for SMTP server which will be used in mailout
/// </summary>
public class SmtpServiceConfiguration
{
    /// <summary>
    /// Name of sender which will be set in email
    /// </summary>
    public string FieldFromName { get; set; }
    /// <summary>
    /// Email address of sender which will be set in email
    /// </summary>
    public string FieldFromAddress { get; set; }
    /// <summary>
    /// SMTP provider which will be used for mailout
    /// </summary>
    public string SmtpProvider { get; set; }
    /// <summary>
    /// User name of account SMTP provider 
    /// </summary>
    public string UserName { get; set; }
    /// <summary>
    /// Password of account SMTP provider or special password set for external apps, usually it's configurated in SMTP account.
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// Port for connection to SMTP provider
    /// </summary>
    public int Port { get; set; }
    /// <summary>
    /// Setting for specifying whether will be used SSL connection or not
    /// </summary>
    public bool UseSsl { get; set; }
}