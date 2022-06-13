using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SanTsgProje.Domain.Users;
using SanTsgProje.Domain.Authentications;
using SanTsgProje.Domain.Reservations;

namespace SanTsgProje.Data
{
    public class ProjeDbContext : DbContext
    {
        public ProjeDbContext(DbContextOptions<ProjeDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<TokenInfo> TokenInfos { get; set; }
        public DbSet<Reservations> Reservations { get; set; }


    }
}
