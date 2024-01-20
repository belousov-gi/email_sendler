using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace email_sendler.Models;
public class MailLogModel
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string Recipient { get; set; }
    public DateTime DateTimeDispatch { get; set; }
    public string Result { get; set; }
    public string FailedMessage { get; set; }
}