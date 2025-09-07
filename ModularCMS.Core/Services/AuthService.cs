using community_management_system.Api.Models;
using ModularCMS.Core.Data;
using ModularCMS.Core.Helpers;
using ModularCMS.Core.Models;
using Microsoft.EntityFrameworkCore;
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
