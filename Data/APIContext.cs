using Microsoft.EntityFrameworkCore;
using EmployeeProfileAPI.Models;

namespace EmployeeProfileAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<EmployeeProfile> Profiles { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }
    }
}
