using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularCMS.Core.Services
{
    public class LoginSuccessMessage
    {
        public string UserType { get; }

        public LoginSuccessMessage(string userType)
        {
            UserType = userType;
        }
    }
    public interface IMessengerService
    {
        Task SendAsync<T>(T message);
        void Register<T>(Action<T> handler);
        void Unregister<T>(Action<T> handler);
    }

    public class MessengerService : IMessengerService
    {
        private static readonly Dictionary<Type, List<object>> _handlers = new Dictionary<Type, List<object>>();

        public Task SendAsync<T>(T message)
        {
            if (_handlers.TryGetValue(typeof(T), out var handlers))
            {
                foreach (var handler in handlers.Cast<Action<T>>().ToList())
                {
                    handler(message);
                }
            }
            return Task.CompletedTask;
        }

        public void Register<T>(Action<T> handler)
        {
            if (!_handlers.ContainsKey(typeof(T)))
            {
                _handlers[typeof(T)] = new List<object>();
            }
            _handlers[typeof(T)].Add(handler);
        }

        public void Unregister<T>(Action<T> handler)
        {
            if (_handlers.ContainsKey(typeof(T)))
            {
                _handlers[typeof(T)].Remove(handler);
            }
        }
    }
    
}
