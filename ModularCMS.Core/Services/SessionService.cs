using community_management_system.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModularCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularCMS.Core.Services
{
    public class SessionService
    {
        private const string SESSION_KEY = "cms_it13_session";
        private const int SESSION_DURATION_HOURS = 1;
        private UserSession? _currentSession;
        private readonly IPreferencesService _preferencesService;

        public UserSession? CurrentSession => _currentSession;
        public bool IsLoggedIn => _currentSession?.IsValid == true;

        public SessionService(IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;
            LoadSession();
        }

        public void CreateSession(User user, string role = "")
        {
            _currentSession = new UserSession
            {
                User_ID = user.User_ID,
                Username = user.Username,
                User_Type = user.User_Type,
                Role = role,
                LoginTime = DateTime.Now,
                ExpiryTime = DateTime.Now.AddHours(SESSION_DURATION_HOURS)
            };

            SaveSession();
            Debug.WriteLine("Session created and saved.");
        }

        public void ExtendSession()
        {
            if (_currentSession != null && _currentSession.IsValid)
            {
                _currentSession.ExpiryTime = DateTime.Now.AddHours(SESSION_DURATION_HOURS);
                SaveSession();
                Debug.WriteLine("Session extended.");
            }
        }

        public void ClearSession()
        {
            _currentSession = null;
            DeleteStoredSession();
            Debug.WriteLine("Session cleared.");
        }

        private void LoadSession()
        {
            try
            {
                var sessionData = _preferencesService.Get(SESSION_KEY, "");
                if (!string.IsNullOrEmpty(sessionData))
                {
                    Debug.WriteLine("Found session data. Attempting to deserialize...");
                    _currentSession = UserSession.FromJson(sessionData);

                    // Check if the session is expired
                    if (_currentSession?.IsExpired == true)
                    {
                        Debug.WriteLine("Session expired. Clearing session.");
                        ClearSession();
                    }
                    else if (_currentSession != null)
                    {
                        Debug.WriteLine($"Session loaded successfully for user: {_currentSession.Username}");
                    }
                }
                else
                {
                    Debug.WriteLine("No session data found. Starting fresh.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error parsing session data: {ex.Message}");
                ClearSession();
            }
        }

        private void SaveSession()
        {
            try
            {
                if (_currentSession != null)
                {
                    _preferencesService.Set(SESSION_KEY, _currentSession.ToJson());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving session: {ex.Message}");
            }
        }

        private void DeleteStoredSession()
        {
            try
            {
                _preferencesService.Remove(SESSION_KEY);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting session: {ex.Message}");
            }
        }

        public TimeSpan GetRemainingTime()
        {
            if (_currentSession?.IsValid == true)
            {
                var remaining = _currentSession.ExpiryTime - DateTime.Now;
                return remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero;
            }
            return TimeSpan.Zero;
        }
    }
}
