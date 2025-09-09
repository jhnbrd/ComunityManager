using community_management_system.Api.Models;
using Microsoft.EntityFrameworkCore;
using ModularCMS.Core.Data.Seeders;
using ModularCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularCMS.Core.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<UserRequest> UserRequests { get; set; }
        public DbSet<IncidentReport> IncidentReports { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationMember> OrganizationMembers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<OfficialReceipt> OfficialReceipts { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<RequestStatusLog> RequestStatusLogs { get; set; }
        public DbSet<IncidentStatusLog> IncidentStatusLogs { get; set; }
        public DbSet<ProjectStatusLog> ProjectStatusLogs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //public static string ConnectionString = "Data Source=127.0.0.1,9210;Initial Catalog=cms_it13;Persist Security Info=True;User ID=jihan438;Password=JihanPH438;Trust Server Certificate=True";
        public static string ConnectionString = "Data Source=MSI-JIHAN\\SQLEXPRESS;Initial Catalog=cms_it13;Integrated Security=True;Trust Server Certificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Resident>().ToTable("Residents");
            modelBuilder.Entity<UserRequest>().ToTable("UserRequests");
            modelBuilder.Entity<IncidentReport>().ToTable("IncidentReports");
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<Announcement>().ToTable("Announcements");
            modelBuilder.Entity<Organization>().ToTable("Organizations");
            modelBuilder.Entity<OrganizationMember>().ToTable("OrganizationMembers");
            modelBuilder.Entity<Document>().ToTable("Documents");
            modelBuilder.Entity<OfficialReceipt>().ToTable("OfficialReceipts");
            modelBuilder.Entity<Budget>().ToTable("Budgets");
            modelBuilder.Entity<Balance>().ToTable("Balances");
            modelBuilder.Entity<Expenses>().ToTable("Expenses");
            modelBuilder.Entity<RequestStatusLog>().ToTable("RequestStatusLog");
            modelBuilder.Entity<IncidentStatusLog>().ToTable("IncidentStatusLog");
            modelBuilder.Entity<ProjectStatusLog>().ToTable("ProjectStatusLog");

            modelBuilder.Entity<User>().HasKey(u => u.User_ID);
            modelBuilder.Entity<Employee>().HasKey(e => e.Employee_ID);
            modelBuilder.Entity<Resident>().HasKey(r => r.Resident_ID);
            modelBuilder.Entity<UserRequest>().HasKey(ur => ur.Request_ID);
            modelBuilder.Entity<IncidentReport>().HasKey(ir => ir.Incident_ID);
            modelBuilder.Entity<Project>().HasKey(p => p.Project_ID);
            modelBuilder.Entity<Announcement>().HasKey(a => a.Announcement_ID);
            modelBuilder.Entity<Organization>().HasKey(o => o.Organization_ID);
            modelBuilder.Entity<OrganizationMember>().HasKey(om => om.Org_Member_ID);
            modelBuilder.Entity<Document>().HasKey(d => d.Document_ID);
            modelBuilder.Entity<OfficialReceipt>().HasKey(or => or.Receipt_ID);
            modelBuilder.Entity<Budget>().HasKey(b => b.Budget_ID);
            modelBuilder.Entity<Balance>().HasKey(b => b.Balance_ID);
            modelBuilder.Entity<Expenses>().HasKey(e => e.Expenses_ID);
            modelBuilder.Entity<RequestStatusLog>().HasKey(rsl => rsl.Request_Status_ID);
            modelBuilder.Entity<IncidentStatusLog>().HasKey(isl => isl.Incident_Status_ID);
            modelBuilder.Entity<ProjectStatusLog>().HasKey(psl => psl.Project_Status_ID);

            modelBuilder.Entity<User>().Property(u => u.User_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Employee>().Property(e => e.Employee_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Resident>().Property(r => r.Resident_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserRequest>().Property(ur => ur.Request_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<IncidentReport>().Property(ir => ir.Incident_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Project>().Property(p => p.Project_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Announcement>().Property(a => a.Announcement_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Organization>().Property(o => o.Organization_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<OrganizationMember>().Property(om => om.Org_Member_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Document>().Property(d => d.Document_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<OfficialReceipt>().Property(or => or.Receipt_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Budget>().Property(b => b.Budget_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Balance>().Property(b => b.Balance_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Expenses>().Property(e => e.Expenses_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<RequestStatusLog>().Property(rsl => rsl.Request_Status_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<IncidentStatusLog>().Property(isl => isl.Incident_Status_ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProjectStatusLog>().Property(psl => psl.Project_Status_ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Employee>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.User_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Resident>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.User_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserRequest>()
                .HasOne<Resident>()
                .WithMany()
                .HasForeignKey(ur => ur.Resident_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Resident>()
                .HasOne<Resident>()
                .WithMany()
                .HasForeignKey(r => r.Household_Head_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .Property(u => u.Is_Active)
                .HasDefaultValue(true);

            modelBuilder.Entity<User>()
                .Property(u => u.Password_Salt)
                .HasDefaultValue("");

            UserSeeder.SeedUsers(modelBuilder);
        }

        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                await Database.OpenConnectionAsync();
                await Database.CloseConnectionAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task EnsureDatabaseCreatedAsync()
        {
            try
            {
                await Database.EnsureCreatedAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database creation failed: {ex.Message}", ex);
            }
        }
    }
}
