using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CPE106_GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create an instance of the Login window
            Login loginWindow = new Login();

            // Set the Login window as the MainWindow property
            this.MainWindow = loginWindow;

            // Show the Login window
            loginWindow.Show();
        }
    }
}
