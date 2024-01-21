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


    public MailsController(SmtpService smtpService, IStorage dbStorageManager)
    {
        _smtpService = smtpService;
        _storage = dbStorageManager;
    }
    
    [HttpPost]
    public IActionResult SendMailes([FromBody] MailoutModel mailoutInfo)
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
    
    [HttpGet]
    public IActionResult GetMails()
    {
        try
        {
            var response = _storage.GetAllMailesAsync();
            return Ok(response.Result);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}