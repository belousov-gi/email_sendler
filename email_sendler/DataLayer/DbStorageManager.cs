using email_sendler.Interfaces;
using email_sendler.Models;

namespace email_sendler.DataLayer;

public class DbStorageManager : IStorage
{
    private IHttpContextAccessor _httpContextAccessor;


    public DbStorageManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public void SaveMailInfo(MailLogModel mailoutLogModel)
    {
        var db = _httpContextAccessor.HttpContext.RequestServices.GetService<MySqlStorage>();
        db.Mailes.AddAsync(mailoutLogModel);
    }

    public string GetAllMailes()
    {
        var db = _httpContextAccessor.HttpContext.RequestServices.GetService<MySqlStorage>();
        var qq = db.Test.Select(x => x.id);
        return $"qwe {qq}";
    }
}