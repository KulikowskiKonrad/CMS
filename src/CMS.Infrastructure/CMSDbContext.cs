using CMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Infrastructure
{
    public class CMSDbContext : DbContext
    {
        public DbSet<Cow> Cows { get; set; }

        public CMSDbContext(Microsoft.EntityFrameworkCore.DbContextOptions options) : base(options) { }
    }
}
