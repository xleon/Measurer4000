using System;
using System.Collections.Generic;

namespace Measurer4000.Core.Services
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> Services = new Dictionary<Type, object>();

        public static T Get<T>()
        {
            if(Services.ContainsKey(typeof(T)))
            {
                return (T)Services[typeof(T)];
            }

            throw new Exception($"Service {typeof(T)} not registered");
        }

        public static void Register<T>(T implementation)
        {
            if(!Services.ContainsKey(typeof(T)))
            {
                Services.Add(typeof(T), implementation);
            }
            else
            {
                Services[typeof(T)] = implementation;
            }
        }
    }
}
