using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace ModularCMS.Core.Services
{
    public interface IPreferencesService
    {
        string Get(string key, string defaultValue);
        void Set(string key, string value);
        void Remove(string key);
    }

    public class PreferencesService : IPreferencesService
    {
        public void Set(string key, string value)
        {
            Preferences.Set(key, value);
        }

        public string Get(string key, string defaultValue = "")
        {
            return Preferences.Get(key, defaultValue);
        }

        public void Remove(string key)
        {
            Preferences.Remove(key);
        }
    }
}
