using email_sendler.Models;
using Microsoft.EntityFrameworkCore;

namespace email_sendler.DataLayer;

public class MySqlStorage : DbContext
{
    public DbSet<MailLogModel> Mailes { get; init; }
    public DbSet<Test> Test { get; init; }

    public MySqlStorage(DbContextOptions<MySqlStorage> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}