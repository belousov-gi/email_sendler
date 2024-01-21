using email_sendler.Models;
using Microsoft.EntityFrameworkCore;

namespace email_sendler.DataLayer;

public class MySqlStorage : DbContext
{
    /// <summary>
    /// Table in database named "Mails". It maintenances data about email dispatching
    /// </summary>
    public DbSet<MailLogModel> Mails { get; init; }
    public MySqlStorage(DbContextOptions<MySqlStorage> options)
        : base(options)
    {
        //В ТЗ указано, что миграции должны быть, поэтому следующую строчку закомментил. 
        //Иначе миграция будет выдавать ошибку, что таблица уже создана и по сути в них не будет никакого смысла.
        
        // Database.EnsureCreated();
    }
}