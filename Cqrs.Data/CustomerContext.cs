using System;
using System.Collections.Generic;
using System.Text;

using Cqrs.Data.Configurations;
using Cqrs.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Cqrs.Data
{
    public class CustomerContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options): base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }
    }
}
