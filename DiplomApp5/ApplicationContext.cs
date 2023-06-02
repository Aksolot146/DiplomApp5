using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiplomApp5.Models;

namespace DiplomApp5
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestStatus> RequestStatuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserRank> UserRanks { get; set; }
        public virtual DbSet<RequestTitle> RequestTitles { get; set; }
        public virtual DbSet<RequestVendor> RequestVendors { get; set; }
        public virtual DbSet<RequestModel> RequestModels { get; set; }
        public virtual DbSet<RequestPartNumber> RequestPartNumbers { get; set; }
        public virtual DbSet<CurrentUser> CurrentUser { get; set; }
        public virtual DbSet<RequestStat> RequestStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.UseCollation("Cyrillic_General_CI_AS");
            modelBuilder.HasCharSet("utf8")
            .UseCollation("utf8_unicode_ci");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                //entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                entity.Property(e => e.Deptname)
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Description)
                    .HasMaxLength(1024);

                entity.HasMany(d => d.Profile)
                    .WithOne(p => p.Department)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("fk_UserProfile_Department1");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("request");

                //entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.ProfileId, "fk_Request_UserProfile");

                entity.HasIndex(e => e.StatusId, "fk_Request_RequestStatus1");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                entity.Property(e => e.Title)
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Vendor)
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Model)
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.Property(e => e.PartNumber)
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Description)
                    .HasMaxLength(1024);
                //.UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.ProfileId)
                    .IsRequired()
                    .HasColumnName("ProfileId");

                entity.Property(e => e.StatusId)
                    .IsRequired()
                    .HasColumnName("StatusId");

                entity.Property(e => e.RequesterId)
                    .IsRequired()
                    .HasColumnName("RequesterId");

                entity.Property(e => e.CompleteTime).HasColumnType("datetime");

                /*entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("fk_Request_UserProfile");

                entity.HasOne(d => d.RequestStatus)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("fk_Request_RequestStatus1");*/
            });

            modelBuilder.Entity<RequestStatus>(entity =>
            {
                entity.ToTable("requeststatus");

                //entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                entity.Property(e => e.Statusname)
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.HasMany(d => d.Request)
                    .WithOne(p => p.RequestStatus)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("fk_Request_RequestStatus1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                //entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.Property(e => e.RegDate).HasColumnType("datetime");

                entity.Property(e => e.AuthDate).HasColumnType("datetime");

                //entity.HasOne(d => d.Profile)
                //    .WithOne(p => p.User)
                //    //.HasForeignKey(d => d.UserId)
                //    .OnDelete(DeleteBehavior.NoAction)
                //    .HasConstraintName("fk_UserProfile_User1");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("userprofile");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Profile)
                    //.HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("fk_UserProfile_User1");

                //entity.UseCollation("utf8_general_ci");

                //entity.HasIndex(e => e.UserId, "fk_UserProfile_User1");

                entity.HasIndex(e => e.RankId, "fk_UserProfile_Rank1");

                entity.HasIndex(e => e.DeptId, "fk_UserProfile_Department1");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserId");

                entity.Property(e => e.RankId)
                    .IsRequired()
                    .HasColumnName("RankId");

                entity.Property(e => e.DeptId)
                    .IsRequired()
                    .HasColumnName("DeptId");

                entity.Property(e => e.Description)
                    .HasMaxLength(1024);

                entity.HasMany(d => d.Request)
                    .WithOne(p => p.Profile)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("fk_Request_UserProfile");

                /*entity.HasOne(d => d.User)
                    .WithOne(p => p.Profile)
                    //.HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("fk_UserProfile_User1");

                entity.HasOne(d => d.UserRank)
                    .WithMany(p => p.Profile)
                    .HasForeignKey(d => d.RankId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("fk_UserProfile_Rank1");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Profile)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("fk_UserProfile_Department1");*/
            });

            modelBuilder.Entity<UserRank>(entity =>
            {
                entity.ToTable("userrank");

                //entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                entity.Property(e => e.Rankname)
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.HasMany(d => d.Profile)
                    .WithOne(p => p.UserRank)
                    .HasForeignKey(d => d.RankId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("fk_UserProfile_Rank1");
            });

            modelBuilder.Entity<RequestTitle>(entity =>
            {
                entity.ToTable("requesttitle");

                //entity.UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                entity.Property(e => e.Titlename)
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.HasMany(d => d.RequestVendor)
                .WithOne(p => p.RequestTitle)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("fk_RequestVendor_RequestTitle1");
            });

            modelBuilder.Entity<RequestVendor>(entity =>
            {
                entity.ToTable("requestvendor");

                //entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.TitleId, "fk_RequestVendor_RequestTitle1");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                entity.Property(e => e.Vendorname)
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.HasMany(d => d.RequestModel)
                .WithOne(p => p.RequestVendor)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("fk_RequestModel_RequestVendor1");
            });

            modelBuilder.Entity<RequestModel>(entity =>
            {
                entity.ToTable("requestmodel");

                //entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.VendorId, "fk_RequestModel_RequestVendor1");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                entity.Property(e => e.Modelname)
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Description)
                    .HasMaxLength(1024);

                entity.HasMany(d => d.RequestPartNumber)
                .WithOne(p => p.RequestModel)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("fk_RequestPartNumber_RequestModel1");
            });

            modelBuilder.Entity<RequestPartNumber>(entity =>
            {
                entity.ToTable("requestpartnumber");

                //entity.UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.ModelId, "fk_RequestPartNumber_RequestModel1");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                entity.Property(e => e.PMname)
                    .HasMaxLength(64);
                //.UseCollation("utf8_unicode_ci");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("Price");

                entity.Property(e => e.RegDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CurrentUser>(entity =>
            {
                entity.ToTable("currentuser");

                entity.Property(e => e.Id)
                    //.ValueGeneratedOnAdd()
                    .HasColumnName("Id");
            }
            );

            modelBuilder.Entity<RequestStat>(entity =>
            {
                entity.ToTable("requeststats");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                entity.Property(e => e.ActualRequestsCount)
                    .IsRequired()
                    .HasColumnName("ActualRequestsCount");

                entity.Property(e => e.NonActualRequestsCount)
                    .IsRequired()
                    .HasColumnName("NonActualRequestsCount");

                entity.Property(e => e.CompleteRequests)
                    .IsRequired()
                    .HasColumnName("CompleteRequests");

                entity.Property(e => e.DeclinedRequests)
                    .IsRequired()
                    .HasColumnName("DeclinedRequests");

                entity.Property(e => e.ExpiredRequests)
                    .IsRequired()
                    .HasColumnName("ExpiredRequests");
            }
            );
        }
    }
}
