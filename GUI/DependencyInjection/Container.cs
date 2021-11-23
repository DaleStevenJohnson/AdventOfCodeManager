using System;
using Autofac;

namespace GUI.DependencyInjection
{
    internal static class Container
    {
        private static IContainer? _instance;
        public static IContainer Instance
        {
            get
            {
                if (_instance == null)
                    throw new NullReferenceException();
                return _instance;
            }
        }

        internal static void SetInstance(IContainer instance)
        {
            _instance = instance;
        }
    }
}
