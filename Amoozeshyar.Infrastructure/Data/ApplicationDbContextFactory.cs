﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshyar.Infrastructure.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //optionsBuilder.UseSqlServer("Server=.;Database=AmoozeshyarDb;Trusted_Connection=True;TrustServerCertificate=True;");
            
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
