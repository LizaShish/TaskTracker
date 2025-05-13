using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace infrastructure.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseFirebird("User=SYSDBA;Password=masterkey;Database=localhost:C:\\Program Files\\Firebird\\Firebird_4_0\\FirebirdData\\TASKS.fdb;DataSource=localhost;Port=3050;Dialect=3;Charset=UTF8;");
        
        return new AppDbContext(optionsBuilder.Options);
    }
}