using System.Text.Json;
using email_sendler.Interfaces;
using email_sendler.Models;

namespace email_sendler.DataLayer;

public class DbStorageManager : IStorage
{
    private MySqlStorage _storage;
    private IHttpContextAccessor _httpContextAccessor;
    
    /// <summary>
    /// DbStorageManager provides direct connection to database
    /// </summary>
    /// <param name="mySqlStorage">Service for connecting to MySQL database</param>
    /// <param name="httpContextAccessor">Service for getting http context</param>
    public DbStorageManager(MySqlStorage mySqlStorage, IHttpContextAccessor httpContextAccessor)
    {
        _storage = mySqlStorage;
        _httpContextAccessor = httpContextAccessor;
    }
    
    /// <summary>
    /// Asynchronously save result of dispatching email in database
    /// </summary>
    /// <param name="mailoutLogModel">Object containing the following data: Id, Subject, Body, Recipient, DateTimeDispatch,
    /// Result, FailedMessage
    /// </param>
    /// <seealso cref="Models.MailLogModel"/>
   
    public async void SaveMailInfoAsync(MailLogModel mailoutLogModel)
    {
        try
        {
            await _storage.Mails.AddAsync(mailoutLogModel);
            _storage.SaveChanges();
        }
        catch (Exception e)
        {
            //Пишем ошибку куда-нибудь в лог-файл / БД 
            Console.Write(e);
        }
    }
    
    /// <summary>
    /// Asynchronously get all records from database about emails which has been sent or not.
    /// </summary>
    /// <returns>JSON with all results or error message</returns>
    public async Task<JsonDocument> GetAllMailesAsync()
    {
        try
        {
            return await Task<JsonDocument>.Run(()=>
            {
                var allMailes =  _storage.Mails;
                var result = JsonSerializer.SerializeToDocument(allMailes);
                return result;
            });
        }
        catch (Exception e)
        {
            _httpContextAccessor.HttpContext.Response.StatusCode = 400;
            return JsonSerializer.SerializeToDocument($"{e.Message}");
        }
    }
}