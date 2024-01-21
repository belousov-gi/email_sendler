using System.Text.Json;
using email_sendler.Models;

namespace email_sendler.Interfaces;

/// <summary>
/// Interface is used for implementation of connection to data storage
/// </summary>
public interface IStorage
{
    /// <summary>
    /// Asynchronously get all records from database about emails which has been sent or not.
    /// </summary>
    /// <returns>JSON with all results or error message</returns>
    Task<JsonDocument> GetAllMailesAsync();
    
    /// <summary>
    /// Asynchronously save result of dispatching email in database
    /// </summary>
    /// <param name="mailoutLogModel">Object containing the following data: Id, Subject, Body, Recipient, DateTimeDispatch,
    /// Result, FailedMessage
    /// </param>
    /// <seealso cref="Models.MailLogModel"/>
    void SaveMailInfoAsync(MailLogModel mailoutLogModel);
}