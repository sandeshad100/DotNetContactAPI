using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.Models;

public partial class ContactDbApiContext : DbContext
{
    public ContactDbApiContext()
    {
    }

    public ContactDbApiContext(DbContextOptions<ContactDbApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContactListTable> ContactListTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=MyCon");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactListTable>(entity =>
        {
            entity.HasKey(e => e.ContactName).HasName("PK__ContactL__4DB98711FD84A2B4");

            entity.ToTable("ContactListTable");

            entity.HasIndex(e => e.ContactPhone, "UQ__ContactL__7C13DF43843E74AD").IsUnique();

            entity.Property(e => e.ContactName)
                .HasMaxLength(50)
                .HasColumnName("contactName");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(10)
                .HasColumnName("contactPhone");
            entity.Property(e => e.ContactRemarks).HasColumnName("contactRemarks");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
