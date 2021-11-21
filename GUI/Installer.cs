using Autofac;

namespace GUI
{
    internal class Installer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>().SingleInstance();
        }
    }
}
