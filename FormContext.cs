using form.tblClass;
using Microsoft.EntityFrameworkCore;

namespace form
    {
    public class FormContext : DbContext
        {
        public FormContext(DbContextOptions options) : base(options)
            { }
        public DbSet<Registration> registration {get; set;}
        public DbSet<Complain> complains { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
        public DbSet<Permissions> permissions { get; set; }
        public DbSet<RoleAssignment> roleAssignments { get; set; }
        }
    }
