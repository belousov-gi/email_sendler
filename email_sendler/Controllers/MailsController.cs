using System.Text.Json;
using email_sendler.Interfaces;
using email_sendler.Models;
using email_sendler.Services;
using Microsoft.AspNetCore.Mvc;

namespace email_sendler.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MailsController : ControllerBase
{
    // private MailManager _mailManager;
    private SmtpService _smtpService;
    private IStorage _storage;

    /// <summary>
    /// Controller for sending mails to recipients and getting results of dispatching
    /// </summary>
    /// <param name="smtpService">Service providing sending via SMTP</param>
    /// <param name="dbStorageManager">Service providing connections with database</param>
    public MailsController(SmtpService smtpService, IStorage dbStorageManager)
    {
        _smtpService = smtpService;
        _storage = dbStorageManager;
    }
    /// <summary>
    /// Send mailes to all recipients have been specified in mailout
    /// </summary>
    /// <param name="mailoutInfo">JSON containing following parameters: Subject, Body, List of all recipients</param>
    /// <seealso cref="Models.MailoutModel"/>
    /// <returns>Returns http status code of dispatching result</returns>
    [HttpPost]
    public IActionResult SendMails([FromBody] MailoutModel mailoutInfo)
    {
        try
        {
            string subject = mailoutInfo.Subject;
            string body = mailoutInfo.Body;
        
            foreach (var recipient in mailoutInfo.Recipients)
            {
                _smtpService.SendEmail(subject, body, recipient);
            }
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
    
    /// <summary>
    /// Get all info about emails which has been sent or not.
    /// </summary>
    /// <returns>
    /// JSON with all info about emails or error message
    /// </returns>
    [HttpGet]
    public IActionResult GetMails()
    {
        try
        {
            var response = _storage.GetAllMailesAsync();
            if (HttpContext.Response.StatusCode != 200)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}