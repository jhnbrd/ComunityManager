using community_management_system.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.ApplicationModel.Communication;
using ModularCMS.Core.Data;
using ModularCMS.Core.Data.Dto;
using ModularCMS.Core.Helpers;
using ModularCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularCMS.Core.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly SessionService _sessionService;

        public AuthService(AppDbContext context, SessionService sessionService)
        {
            _context = context;
            _sessionService = sessionService;
        }

        public async Task<LoginResult> LoginAsync(string username, string password)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == username && u.Is_Active);

                if (user == null)
                {
                    return new LoginResult { Success = false, Message = "Invalid username" };
                }

                if (!PasswordHelper.VerifyPassword(password, user.Password_Hash, user.Password_Salt))
                {
                    return new LoginResult { Success = false, Message = "Invalid password" };
                }

                string role = await GetUserRoleAsync(user);

                _sessionService.CreateSession(user, role);

                return new LoginResult
                {
                    Success = true,
                    User = user,
                    Role = role,
                    Message = "Login successful"
                };
            }
            catch (Exception ex)
            {
                return new LoginResult { Success = false, Message = $"Login error: {ex.Message}" };
            }
        }

        public async Task<bool> AddEmployeeAsync(AddUserDto userDto)
        {
            try
            {
                var createdById = _sessionService.CurrentSession?.User_ID ?? 1;
                var createdByUser = await _context.Users.FirstOrDefaultAsync(u => u.User_ID == createdById);

                var (hashedPassword, salt) = PasswordHelper.HashPasswordWithSalt(userDto.Password);

                var newUser = new User
                {
                    Username = userDto.Username,
                    Password_Hash = hashedPassword,
                    Password_Salt = salt,
                    Email = userDto.Email,
                    User_Type = "Employee",
                    Is_Active = true,
                    Created_At = DateTime.Now,
                    Created_By_ID = createdById,
                    CreatedByUser = createdByUser
                };

                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                var newEmployee = new Employee
                {
                    User_ID = newUser.User_ID,
                    First_Name = userDto.FirstName,
                    Middle_Name = userDto.MiddleName ?? string.Empty,
                    Last_Name = userDto.LastName,
                    Suffix = userDto.Suffix?.ToString() ?? string.Empty,
                    Gender = userDto.Gender.ToString(),
                    Role = userDto.Role.ToString(),
                    Created_At = DateTime.Now,
                    Created_By_ID = createdById,
                    CreatedByUser = createdByUser
                };

                await _context.Employees.AddAsync(newEmployee);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding new employee: {ex.Message}");
                return false;
            }
        }

        public bool IsLoggedIn()
        {
            return _sessionService.IsLoggedIn;
        }

        public UserSession? GetCurrentSession()
        {
            return _sessionService.CurrentSession;
        }

        public void Logout()
        {
            _sessionService.ClearSession();
        }

        public void ExtendSession()
        {
            _sessionService.ExtendSession();
        }

        public TimeSpan GetSessionRemainingTime()
        {
            return _sessionService.GetRemainingTime();
        }

        private async Task<string> GetUserRoleAsync(User user)
        {
            try
            {
                if (user.User_Type == "Employee")
                {
                    var employee = await _context.Employees
                        .FirstOrDefaultAsync(e => e.User_ID == user.User_ID);
                    return employee?.Role ?? "Employee";
                }
                return "Resident";
            }
            catch
            {
                return user.User_Type;
            }
        }
    }

    public class LoginResult
    {
        public bool Success { get; set; }
        public User? User { get; set; }
        public string Role { get; set; } = "";
        public string Message { get; set; } = "";
    }
}
