﻿using Autofac;
using GUI.Output;

namespace GUI
{
    internal class Installer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<OutputViewModel>().SingleInstance();
        }
    }
}
