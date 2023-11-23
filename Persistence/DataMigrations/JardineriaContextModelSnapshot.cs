﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.DataMigrations
{
    [DbContext(typeof(JardineriaContext))]
    partial class JardineriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("StateId")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("CodEmployee")
                        .HasColumnType("int");

                    b.Property<decimal?>("CreditLimit")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Fax")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LineAddress")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LineAddress2")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PostalCodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CodEmployee");

                    b.HasIndex("PersonId");

                    b.HasIndex("PostalCodeId");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("countries", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Extention")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ManagerCode")
                        .HasColumnType("int");

                    b.Property<string>("OfficeCode")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfficeCode");

                    b.HasIndex("PersonId");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MethodPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MethodPayment1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("methodpayments", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Office", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PostalCodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostalCodeId");

                    b.ToTable("offices", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientCode")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateOnly?>("DeliveryDate")
                        .HasColumnType("Date");

                    b.Property<DateOnly>("ExpectedDate")
                        .HasColumnType("Date");

                    b.Property<DateOnly>("OrderDate")
                        .HasColumnType("Date");

                    b.Property<int>("StatusCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientCode");

                    b.HasIndex("StatusCode");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<short>("LineNumber")
                        .HasColumnType("smallint(6)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("ProductCode")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int(11)");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductCode");

                    b.ToTable("orderdetails", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("MethodId")
                        .HasColumnType("int(11)");

                    b.Property<DateOnly>("PaymentDate")
                        .HasColumnType("date");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TransactionId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("MethodId");

                    b.ToTable("payments", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName1")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName2")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PersonTypeId")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("PersonTypeId");

                    b.ToTable("persons", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.PersonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("persontypes", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.PostalCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int(11)");

                    b.Property<string>("PostalCode1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("postalcodes", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasMaxLength(500000)
                        .HasColumnType("longtext");

                    b.Property<string>("Dimensions")
                        .HasMaxLength(500000)
                        .HasColumnType("longtext");

                    b.Property<int>("IdSupplier")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500000)
                        .HasColumnType("longtext");

                    b.Property<int>("ProductLine")
                        .HasColumnType("int(11)");

                    b.Property<decimal>("SellingPrice")
                        .HasMaxLength(500000)
                        .HasColumnType("decimal(65,30)");

                    b.Property<short>("StockQuantity")
                        .HasColumnType("smallint(6)");

                    b.Property<decimal>("SupplierPrice")
                        .HasMaxLength(500000)
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("IdSupplier");

                    b.HasIndex("ProductLine");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProductLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("DescriptionHtml")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DescriptionText")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Image")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProductLine1")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("productlines", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("states", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NameStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("status", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("suppliers", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.HasOne("Domain.Entities.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Domain.Entities.Client", b =>
                {
                    b.HasOne("Domain.Entities.Employee", "CodEmployeeNavigation")
                        .WithMany("Clients")
                        .HasForeignKey("CodEmployee");

                    b.HasOne("Domain.Entities.Person", "Person")
                        .WithMany("Clients")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.PostalCode", "PostalCode")
                        .WithMany("Clients")
                        .HasForeignKey("PostalCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CodEmployeeNavigation");

                    b.Navigation("Person");

                    b.Navigation("PostalCode");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.HasOne("Domain.Entities.Office", "Office")
                        .WithMany("Employees")
                        .HasForeignKey("OfficeCode");

                    b.HasOne("Domain.Entities.Person", "Person")
                        .WithMany("Employees")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.Entities.Office", b =>
                {
                    b.HasOne("Domain.Entities.PostalCode", "PostalCode")
                        .WithMany("Offices")
                        .HasForeignKey("PostalCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostalCode");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.HasOne("Domain.Entities.Client", "ClientCodeNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("ClientCode")
                        .IsRequired();

                    b.HasOne("Domain.Entities.Status", "StatusCodeNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("StatusCode")
                        .IsRequired();

                    b.Navigation("ClientCodeNavigation");

                    b.Navigation("StatusCodeNavigation");
                });

            modelBuilder.Entity("Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("Domain.Entities.Order", "Order")
                        .WithMany("Orderdetails")
                        .HasForeignKey("OrderId")
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("Orderdetails")
                        .HasForeignKey("ProductCode");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.Payment", b =>
                {
                    b.HasOne("Domain.Entities.Client", "IdNavigation")
                        .WithMany("Payments")
                        .HasForeignKey("ClienteId")
                        .IsRequired();

                    b.HasOne("Domain.Entities.MethodPayment", "Method")
                        .WithMany("Payments")
                        .HasForeignKey("MethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdNavigation");

                    b.Navigation("Method");
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.HasOne("Domain.Entities.PersonType", "PersonType")
                        .WithMany("People")
                        .HasForeignKey("PersonTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonType");
                });

            modelBuilder.Entity("Domain.Entities.PostalCode", b =>
                {
                    b.HasOne("Domain.Entities.City", "City")
                        .WithMany("Postalcodes")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("IdSupplier")
                        .IsRequired();

                    b.HasOne("Domain.Entities.ProductLine", "ProductLineNavigation")
                        .WithMany("Products")
                        .HasForeignKey("ProductLine")
                        .IsRequired();

                    b.Navigation("ProductLineNavigation");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Domain.Entities.State", b =>
                {
                    b.HasOne("Domain.Entities.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Navigation("Postalcodes");
                });

            modelBuilder.Entity("Domain.Entities.Client", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Domain.Entities.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("Domain.Entities.MethodPayment", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Domain.Entities.Office", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Navigation("Orderdetails");
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Domain.Entities.PersonType", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("Domain.Entities.PostalCode", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Offices");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Navigation("Orderdetails");
                });

            modelBuilder.Entity("Domain.Entities.ProductLine", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Entities.State", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Domain.Entities.Status", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Domain.Entities.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
