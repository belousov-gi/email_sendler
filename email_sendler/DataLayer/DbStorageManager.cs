using System.Text.Json;
using email_sendler.Interfaces;
using email_sendler.Models;

namespace email_sendler.DataLayer;

public class DbStorageManager : IStorage
{
    private MySqlStorage _storage;

    public DbStorageManager(MySqlStorage mySqlStorage)
    {
        _storage = mySqlStorage;
    }
    public void SaveMailInfo(MailLogModel mailoutLogModel)
    {
        _storage.Mailes.Add(mailoutLogModel);
        _storage.SaveChanges();
    }
    
    public async void SaveMailInfoAsync(MailLogModel mailoutLogModel)
    {
            await _storage.Mailes.AddAsync(mailoutLogModel);
            _storage.SaveChanges();
    }

    public JsonDocument GetAllMailes()
    {
        var allMailes =_storage.Mailes;
        var result = JsonSerializer.SerializeToDocument(allMailes);
        return result;
    }
    
    public async Task<JsonDocument> GetAllMailesAsync()
    {
        return await Task<JsonDocument>.Run(()=>
        {
            var allMailes =  _storage.Mailes;
            var result = JsonSerializer.SerializeToDocument(allMailes);
            return result;
        });
    }
}