﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace RealEstateManager.Database
{
    public class RealEstateContextFactory: IDesignTimeDbContextFactory<RealEstateContext>
    {
        public RealEstateContext CreateDbContext(string[] args)
        {
            var configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<RealEstateContext>();
            var connectionString = configuration.GetConnectionString("RealEstateDb");
            builder.UseSqlServer(connectionString);

            return new RealEstateContext(builder.Options);

        }
        
    }
}
