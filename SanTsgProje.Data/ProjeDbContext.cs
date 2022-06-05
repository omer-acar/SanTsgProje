using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SanTsgProje.Domain.Users;

namespace SanTsgProje.Data
{
    public class ProjeDbContext : DbContext
    {
        public ProjeDbContext(DbContextOptions<ProjeDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }


    }
}
