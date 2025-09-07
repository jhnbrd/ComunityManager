using community_management_system.Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModularCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularCMS.Core.Services
{
    public class SessionService
    {
        private const string SESSION_KEY = "cms_it13_session";
        private const int SESSION_DURATION_HOURS = 1;
        private readonly IPreferencesService _preferences;
        private UserSession? _currentSession;

        public UserSession? CurrentSession => _currentSession;
        public bool IsLoggedIn => _currentSession?.IsValid == true;

        public SessionService(IPreferencesService preferences)
        {
            _preferences = preferences;
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
        }

        public void ExtendSession()
        {
            if (_currentSession != null && _currentSession.IsValid)
            {
                _currentSession.ExpiryTime = DateTime.Now.AddHours(SESSION_DURATION_HOURS);
                SaveSession();
            }
        }

        public void ClearSession()
        {
            _currentSession = null;
            DeleteStoredSession();
        }

        private void LoadSession()
        {
            try
            {
                var sessionData = _preferences.Get(SESSION_KEY, "");
                if (!string.IsNullOrEmpty(sessionData))
                {
                    _currentSession = UserSession.FromJson(sessionData);

                    if (_currentSession?.IsExpired == true)
                    {
                        ClearSession();
                    }
                }
            }
            catch
            {
                ClearSession();
            }
        }

        private void SaveSession()
        {
            try
            {
                if (_currentSession != null)
                {
                    _preferences.Set(SESSION_KEY, _currentSession.ToJson());
                }
            }
            catch
            {
            }
        }

        private void DeleteStoredSession()
        {
            try
            {
                _preferences.Remove(SESSION_KEY);
            }
            catch
            {
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
