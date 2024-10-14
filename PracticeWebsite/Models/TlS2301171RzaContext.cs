﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace PracticeWebsite.Models;

public partial class TlS2301171RzaContext : DbContext
{
    public TlS2301171RzaContext()
    {
    }

    public TlS2301171RzaContext(DbContextOptions<TlS2301171RzaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attraction> Attractions { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Eduvisit> Eduvisits { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Roombooking> Roombookings { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=MySqlConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Attraction>(entity =>
        {
            entity.HasKey(e => e.AttractionId).HasName("PRIMARY");

            entity.ToTable("attractions");

            entity.Property(e => e.AttractionId)
                .ValueGeneratedNever()
                .HasColumnName("attractionID");
            entity.Property(e => e.AttractionName)
                .HasMaxLength(30)
                .HasColumnName("attractionName");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.EmployeeId, "employeeID_UNIQUE").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "phoneNumber").IsUnique();

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Employee).HasColumnName("employee");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(45)
                .HasColumnName("employeeID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .HasColumnName("lastName");
            entity.Property(e => e.LoyaltyPoints).HasColumnName("loyaltyPoints");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Postcode)
                .HasMaxLength(10)
                .HasColumnName("postcode");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .HasColumnName("username");

            entity.HasMany(d => d.Tickets).WithMany(p => p.Customers)
                .UsingEntity<Dictionary<string, object>>(
                    "Ticktbooking",
                    r => r.HasOne<Ticket>().WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ticktbooking_ibfk_2"),
                    l => l.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("ticktbooking_ibfk_1"),
                    j =>
                    {
                        j.HasKey("CustomerId", "TicketId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("ticktbooking");
                        j.HasIndex(new[] { "TicketId" }, "ticketID");
                        j.IndexerProperty<int>("CustomerId").HasColumnName("customerID");
                        j.IndexerProperty<int>("TicketId").HasColumnName("ticketID");
                    });
        });

        modelBuilder.Entity<Eduvisit>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("eduvisits");

            entity.Property(e => e.DayOfVisit).HasColumnName("dayOfVisit");
            entity.Property(e => e.QuantityOfStaff).HasColumnName("quantityOfStaff");
            entity.Property(e => e.QuantityOfStudents).HasColumnName("quantityOfStudents");
            entity.Property(e => e.SchoolName)
                .HasMaxLength(50)
                .HasColumnName("schoolName");
            entity.Property(e => e.StageOfEdu)
                .HasMaxLength(20)
                .HasColumnName("stageOfEdu");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomNumber).HasName("PRIMARY");

            entity.ToTable("rooms");

            entity.Property(e => e.RoomNumber)
                .ValueGeneratedNever()
                .HasColumnName("roomNumber");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.DisabilityAccesible).HasColumnName("disabilityAccesible");
            entity.Property(e => e.RoomType)
                .HasMaxLength(20)
                .HasColumnName("roomType");
            entity.Property(e => e.Vacancy).HasColumnName("vacancy");
        });

        modelBuilder.Entity<Roombooking>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.RoomNumber, e.StartDate })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("roombookings");

            entity.HasIndex(e => e.RoomNumber, "roomNumber");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.RoomNumber).HasColumnName("roomNumber");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.EndDate).HasColumnName("endDate");

            entity.HasOne(d => d.Customer).WithMany(p => p.Roombookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roombookings_ibfk_1");

            entity.HasOne(d => d.RoomNumberNavigation).WithMany(p => p.Roombookings)
                .HasForeignKey(d => d.RoomNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roombookings_ibfk_2");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PRIMARY");

            entity.ToTable("tickets");

            entity.HasIndex(e => e.AttractionId, "attractionID");

            entity.Property(e => e.TicketId)
                .ValueGeneratedNever()
                .HasColumnName("ticketID");
            entity.Property(e => e.AttractionId).HasColumnName("attractionID");
            entity.Property(e => e.ValidDate).HasColumnName("validDate");

            entity.HasOne(d => d.Attraction).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.AttractionId)
                .HasConstraintName("tickets_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}