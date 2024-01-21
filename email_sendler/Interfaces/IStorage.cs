using System.Text.Json;
using email_sendler.DataLayer;
using email_sendler.Models;

namespace email_sendler.Interfaces;

public interface IStorage
{
    void SaveMailInfo(MailLogModel mailoutLogModel);
    JsonDocument GetAllMailes();
    Task<JsonDocument> GetAllMailesAsync();
    void SaveMailInfoAsync(MailLogModel mailoutLogModel);
}