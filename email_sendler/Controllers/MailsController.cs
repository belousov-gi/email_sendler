using System.Net.Mime;
using System.Text.Json;
using email_sendler.DataLayer;
using email_sendler.Interfaces;
using email_sendler.LogicLayer;
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
        // _mailManager = mailManager;
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
                _smtpService.SendEmailAsync(subject, body, recipient);
            }
            
            // var response = _mailManager.MakeMailout(mailoutInfo);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e);
        }
    }
    
    [HttpGet]
    public IActionResult GetMails()
    {
        try
        {
            var response = _storage.GetAllMailes();
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e);
        }
    }
    
    
}