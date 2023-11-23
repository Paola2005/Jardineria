using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection;

namespace Persistence.Data;

public partial class JardineriaContext : DbContext
{
    public JardineriaContext()
    {
    }

    public JardineriaContext(DbContextOptions<JardineriaContext> options)
        : base(options)
    {
    }


    public DbSet<City> Cities { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<Country> Countries { get; set; }


    public DbSet<Employee> Employees { get; set; }

    public DbSet<MethodPayment> Methodpayments { get; set; }

    public DbSet<Office> Offices { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> Orderdetails { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<Person> Persons { get; set; }

    public DbSet<PersonType> Persontypes { get; set; }

    public DbSet<PostalCode> Postalcodes { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<ProductLine> Productlines { get; set; }

    public DbSet<State> States { get; set; }

    public DbSet<Status> Statuses { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}
