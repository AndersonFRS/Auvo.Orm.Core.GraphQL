using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Auvo.Orm.Core.GraphQL.WebApi.Infrastructure.DBContext
{
    public partial class TechEventDBContext : DbContext
    {
        public TechEventDBContext()
        {
        }

        public TechEventDBContext(DbContextOptions<TechEventDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventParticipant> EventParticipants { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;
        public virtual DbSet<TechEventInfo> TechEventInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TechEventDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventParticipant>(entity =>
            {
                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventParticipants)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Participant)
                    .WithMany(p => p.EventParticipants)
                    .HasForeignKey(d => d.ParticipantId);
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.ToTable("Participant");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParticipantName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TechEventInfo>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("TechEventInfo");

                entity.Property(e => e.EventDate).HasColumnType("date");

                entity.Property(e => e.EventName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Speaker)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
