using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CPE106_GUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Login:Window
    {
        public Login()
        {
            InitializeComponent();

        }

        private void ExitButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void ExitButtonRegis_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Login Code Here

            bool isAuthenticated = true; 

            if (isAuthenticated)
            {
                MessageBox.Show("Login Successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();

                MainWindow mainWindow = new MainWindow();
                mainWindow.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Login Failed. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Registration code here

            bool isRegistered = true; 

            if (isRegistered)
            {
                MessageBox.Show("Registration Successful\nPlease Login", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                if (MyTabControl != null && MyTabControl.Items.Count > 0)
                {
                    MyTabControl.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Registration Failed. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void EmailTextBoxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
