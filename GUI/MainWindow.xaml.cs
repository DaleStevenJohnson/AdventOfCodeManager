using System.Windows;
using Autofac;
using GUI.DependencyInjection;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetupMainWindow();
        }

        private void SetupMainWindow()
        {
            DataContext = Container.Instance.Resolve<MainViewModel>();
            DataContextChanged += (sender, args) =>
            {
                DataContext = args.NewValue;
            };
        }
    }
}
