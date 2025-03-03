using System;
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

    public virtual DbSet<Keystage> Keystages { get; set; }

    public virtual DbSet<Progress> Progresses { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Roombooking> Roombookings { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Ticketbooking> Ticketbookings { get; set; }

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
            entity.Property(e => e.Name).HasMaxLength(200);
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

        modelBuilder.Entity<Keystage>(entity =>
        {
            entity.HasKey(e => e.KeystageId).HasName("PRIMARY");

            entity.ToTable("keystage");

            entity.Property(e => e.KeystageId)
                .ValueGeneratedNever()
                .HasColumnName("keystageID");
            entity.Property(e => e.KeystageName)
                .HasMaxLength(45)
                .HasColumnName("keystageName");
        });

        modelBuilder.Entity<Progress>(entity =>
        {
            entity.HasKey(e => new { e.QuizId, e.CustomerId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("progress");

            entity.HasIndex(e => e.CustomerId, "proressfk1_idx");

            entity.Property(e => e.QuizId).HasColumnName("quizID");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Ks1Maths).HasColumnName("ks1_maths");

            entity.HasOne(d => d.Customer).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proressfk1");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("progressfk2");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionsId).HasName("PRIMARY");

            entity.ToTable("questions");

            entity.HasIndex(e => e.QuizId, "questionfk1_idx");

            entity.Property(e => e.QuestionsId)
                .ValueGeneratedNever()
                .HasColumnName("questionsID");
            entity.Property(e => e.Answer1)
                .HasMaxLength(45)
                .HasColumnName("answer1");
            entity.Property(e => e.Answer2)
                .HasMaxLength(45)
                .HasColumnName("answer2");
            entity.Property(e => e.Answer3)
                .HasMaxLength(45)
                .HasColumnName("answer3");
            entity.Property(e => e.Answer4)
                .HasMaxLength(45)
                .HasColumnName("answer4");
            entity.Property(e => e.Finalanswer)
                .HasMaxLength(45)
                .HasColumnName("finalanswer");
            entity.Property(e => e.Question1)
                .HasMaxLength(100)
                .HasColumnName("question");
            entity.Property(e => e.QuizId).HasColumnName("quizID");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("questionfk1");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PRIMARY");

            entity.ToTable("quiz");

            entity.HasIndex(e => e.SubjectId, "quizfk1_idx");

            entity.Property(e => e.QuizId)
                .ValueGeneratedNever()
                .HasColumnName("quizID");
            entity.Property(e => e.KeystageId).HasColumnName("keystageID");
            entity.Property(e => e.SubjectId).HasColumnName("subjectID");

            entity.HasOne(d => d.Subject).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quizfk1");
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

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PRIMARY");

            entity.ToTable("subject");

            entity.Property(e => e.SubjectId)
                .ValueGeneratedNever()
                .HasColumnName("subjectID");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(45)
                .HasColumnName("subjectName");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PRIMARY");

            entity.ToTable("ticket");

            entity.HasIndex(e => e.AttractionId, "ticket_fk1_idx");

            entity.HasIndex(e => e.TicketbookingId, "ticket_fk2_idx");

            entity.Property(e => e.TicketId).HasColumnName("ticketID");
            entity.Property(e => e.AttractionId).HasColumnName("attractionID");
            entity.Property(e => e.TicketbookingId).HasColumnName("ticketbookingID");

            entity.HasOne(d => d.Attraction).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.AttractionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticket_fk1");

            entity.HasOne(d => d.Ticketbooking).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TicketbookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticket_fk2");
        });

        modelBuilder.Entity<Ticketbooking>(entity =>
        {
            entity.HasKey(e => e.TicketbookingId).HasName("PRIMARY");

            entity.ToTable("ticketbooking");

            entity.HasIndex(e => e.CustomerId, "ticketbooking_fk1_idx");

            entity.Property(e => e.TicketbookingId).HasColumnName("ticketbookingID");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DateBooked).HasColumnName("dateBooked");

            entity.HasOne(d => d.Customer).WithMany(p => p.Ticketbookings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticketbooking_fk1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
