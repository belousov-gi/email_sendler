namespace email_sendler.Models;

public class MailoutModel
{
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<string> Recipients { get; set; }
}