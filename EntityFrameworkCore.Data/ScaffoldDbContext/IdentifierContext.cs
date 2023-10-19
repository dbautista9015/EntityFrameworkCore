using System;
using System.Collections.Generic;
using EntityFrameworkCore.Data.ScaffoldModels;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Data.ScaffoldDbContext;

public partial class IdentifierContext : DbContext
{
    public IdentifierContext()
    {
    }

    public IdentifierContext(DbContextOptions<IdentifierContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("DataSource=/Users/danielbautista/DataGripProjects/TestDataGrip/identifier.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Contacts_email").IsUnique();

            entity.HasIndex(e => e.Phone, "IX_Contacts_phone").IsUnique();

            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("groups");

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
