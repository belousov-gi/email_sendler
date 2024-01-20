using System.Net;
using System.Text.Json;
using email_sendler.Interfaces;
using email_sendler.Models;
using email_sendler.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace email_sendler.LogicLayer;

public class MailManager
{
    private IStorage _storage;
    private SmtpService _smtpService;

    public MailManager(IStorage dbStorageManager, SmtpService smtpService)
    {
        _storage = dbStorageManager;
        _smtpService = smtpService;
    }
    // public string MakeMailout(MailoutModel mailoutInfo)
    // {
    //     try
    //     {
    //         var qq =_smtpService.SendEmailAsync(mailoutInfo.Subject, mailoutInfo.Body, mailoutInfo.Recipients);
    //
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //         throw;
    //     }
    // }
    
    public async Task SendMailAsync(string subject, string body, string recipient)
    {
        await Task.Run(() => "{Result : everything's OK}");
    }
    

    public string GetAllMailes()
    {
        return _storage.GetAllMailes();
    }
}