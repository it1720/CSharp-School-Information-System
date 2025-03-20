using ICS_SIS.App.Shells;
using Microsoft.Extensions.DependencyInjection;

namespace ICS_SIS.App
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            MainPage = serviceProvider.GetRequiredService<AppShell>();
        }
    }
}
