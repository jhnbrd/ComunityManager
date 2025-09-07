using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using ModularCMS.Core.Models;
using ModularCMS.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularCMS.Core.Data.Seeders
{
    public static class UserSeeder
    {
        public static void SeedUsers(ModelBuilder modelBuilder) 
        {
            var (passwordHash, passwordSalt) = PasswordHelper.HashPasswordWithSalt("admin123");

            modelBuilder.Entity<User>().HasData(new
            {
                User_ID = 1,
                Username = "superadmin",
                Password_Hash = passwordHash,
                Password_Salt = passwordSalt,
                User_Type = "Employee",
                Is_Active = true,
                Created_At = DateTime.UtcNow,
                Created_By_ID = 1,
                Updated_At = (DateTime?)null,
                Updated_By_ID = (int?)null,
            });
        }
    }
}
