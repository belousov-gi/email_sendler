using email_sendler.Models;

namespace email_sendler.Interfaces;

public interface IStorage
{
    void SaveMailInfo(MailLogModel mailoutLogModel);
    string GetAllMailes();
}