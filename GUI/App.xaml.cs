using System.Windows;
using Autofac;
using GUI.DependencyInjection;

namespace GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new Installer());
            var container = containerBuilder.Build();
            Container.SetInstance(container);
        }
    }
}
