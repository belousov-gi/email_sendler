namespace email_sendler.Models;

public class SmtpServiceConfiguration
{
    public string FieldFromName { get; set; }
    public string FieldFromAddress { get; set; }
    public string SmtpProvider { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int Port { get; set; }
    public bool UseSsl { get; set; }
}