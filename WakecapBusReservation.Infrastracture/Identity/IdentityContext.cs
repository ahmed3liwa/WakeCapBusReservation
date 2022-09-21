using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WakecapBusReservation.Domain.Models.Idenitiy;

namespace WakecapBusReservation.Infrastracture.Identity
{
    public class IdentityContext : IdentityDbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }
        protected IdentityContext()
        {
        }
    }
}
