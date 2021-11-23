using Autofac;
using GUI.DatePicker;
using GUI.Output;

namespace GUI.DependencyInjection
{
    internal class Installer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<OutputViewModel>().SingleInstance();
            builder.RegisterType<DatePickerViewModel>().SingleInstance();
        }
    }
}
