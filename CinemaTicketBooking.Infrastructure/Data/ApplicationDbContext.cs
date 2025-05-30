using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Infrastructure.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cinema> Cinemas { get; set; }

    public virtual DbSet<Hall> Halls { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Screening> Screenings { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=cinema_ticket_booking;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cinema>(entity =>
        {
            entity.HasKey(e => e.CinemaId).HasName("PK__Cinemas__566287789812A28F");

            entity.Property(e => e.CinemaId).HasColumnName("cinema_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.HasKey(e => e.HallId).HasName("PK__Halls__A63DE8CF66035EB7");

            entity.Property(e => e.HallId).HasColumnName("hall_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.CinemaId).HasColumnName("cinema_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Cinema).WithMany(p => p.Halls)
                .HasForeignKey(d => d.CinemaId)
                .HasConstraintName("FK__Halls__cinema_id__4316F928");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movies__83CDF7494F6405C4");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Cast).HasColumnName("cast");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Director)
                .HasMaxLength(100)
                .HasColumnName("director");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .HasColumnName("genre");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.PosterUrl)
                .HasMaxLength(255)
                .HasColumnName("poster_url");
            entity.Property(e => e.Rating)
                .HasDefaultValue(0.0m)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("rating");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__E059842FABAA957D");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsRead)
                .HasDefaultValue(false)
                .HasColumnName("is_read");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.NotificationType)
                .HasMaxLength(30)
                .HasColumnName("notification_type");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Notificat__user___72C60C4A");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__ED1FC9EA13CCCD3C");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .HasColumnName("payment_method");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("transaction_id");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__reserv__66603565");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__31384C295D6D873E");

            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.ReservationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("reservation_date");
            entity.Property(e => e.ScreeningId).HasColumnName("screening_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("?? ??????")
                .HasColumnName("status");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_price");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Screening).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.ScreeningId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__scree__5AEE82B9");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__user___59FA5E80");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__60883D90B85C6A6F");

            entity.Property(e => e.ReviewId).HasColumnName("review_id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.IsApproved)
                .HasDefaultValue(false)
                .HasColumnName("is_approved");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("review_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Movie).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Reviews__movie_i__6D0D32F4");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__user_id__6C190EBB");
        });

        modelBuilder.Entity<Screening>(entity =>
        {
            entity.HasKey(e => e.ScreeningId).HasName("PK__Screenin__477746C3124979AF");

            entity.Property(e => e.ScreeningId).HasColumnName("screening_id");
            entity.Property(e => e.AvailableSeats).HasColumnName("available_seats");
            entity.Property(e => e.Discount)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.HallId).HasColumnName("hall_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");

            entity.HasOne(d => d.Hall).WithMany(p => p.Screenings)
                .HasForeignKey(d => d.HallId)
                .HasConstraintName("FK__Screening__hall___4E88ABD4");

            entity.HasOne(d => d.Movie).WithMany(p => p.Screenings)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Screening__movie__4D94879B");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.SeatId).HasName("PK__Seats__906DED9C96E45B70");

            entity.HasIndex(e => new { e.HallId, e.RowNumber, e.SeatNumber }, "UQ_Seat_Position").IsUnique();

            entity.Property(e => e.SeatId).HasColumnName("seat_id");
            entity.Property(e => e.HallId).HasColumnName("hall_id");
            entity.Property(e => e.RowNumber)
                .HasMaxLength(2)
                .HasColumnName("row_number");
            entity.Property(e => e.SeatNumber).HasColumnName("seat_number");
            entity.Property(e => e.SeatType)
                .HasMaxLength(20)
                .HasDefaultValue("????")
                .HasColumnName("seat_type");

            entity.HasOne(d => d.Hall).WithMany(p => p.Seats)
                .HasForeignKey(d => d.HallId)
                .HasConstraintName("FK__Seats__hall_id__5441852A");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Tickets__D596F96B7634C851");

            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.SeatId).HasColumnName("seat_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("????")
                .HasColumnName("status");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("FK__Tickets__reserva__5FB337D6");

            entity.HasOne(d => d.Seat).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__seat_id__60A75C0F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F480B365B");

            entity.ToTable(tb => tb.HasTrigger("trg_Users_Update"));

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E616410448940").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(255)
                .HasColumnName("refresh_token");
            entity.Property(e => e.RefreshTokenExpiryTime)
                .HasColumnType("datetime")
                .HasColumnName("refresh_token_expiry_time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
