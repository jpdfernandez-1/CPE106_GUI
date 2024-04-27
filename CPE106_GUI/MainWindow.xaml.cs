using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;

namespace CPE106_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Define a class to represent a parking spot
        public class ParkingSpot
        {
            public string Floor { get; set; }
            public string Section { get; set; }
            public string Number { get; set; }
            public string Status { get; set; }
        }

        // Temporary data source
        private List<ParkingSpot> YourData = new List<ParkingSpot>()
        {
            new ParkingSpot() { Floor = "Floor 1", Section = "A", Number = "001", Status = "Vacant" },
            new ParkingSpot() { Floor = "Floor 1", Section = "B", Number = "002", Status = "Occupied" },
            new ParkingSpot() { Floor = "Floor 2", Section = "C", Number = "003", Status = "Vacant" },
            new ParkingSpot() { Floor = "Floor 2", Section = "D", Number = "004", Status = "Vacant" },
            // Add more temporary data here as needed
        };

        public MainWindow()
        {
            InitializeComponent();
            this.Visibility = Visibility.Hidden;
            VacantSpotsGrid.ItemsSource = YourData; // Bind the data to the DataGrid
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Enter your ticket number...")
            {
                textBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Enter your ticket number...";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void VacantFilter_Checked(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }

        private void VacantFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }

        private void FloorFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            // Apply filters based on checkbox and combobox selection
            var filteredData = YourData.Where(spot =>
            {
                if (VacantFilter.IsChecked == true && spot.Status != "Vacant")
                    return false;

                if (FloorFilter.SelectedItem != null && ((ComboBoxItem)FloorFilter.SelectedItem).Content.ToString() != "All" && spot.Floor != ((ComboBoxItem)FloorFilter.SelectedItem).Content.ToString())
                    return false;

                return true;
            });

            VacantSpotsGrid.ItemsSource = filteredData.ToList();
        }

        private void VacantSpotsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void BackButtonEticket_Click(object sender, RoutedEventArgs e)
        {
            HomePage.IsSelected = true;
        }
        private void BackButtonFeedback_Click(object sender, RoutedEventArgs e)
        {
            HomePage.IsSelected = true;
        }
        private void SubmitButtonFeedback_Click(object sender, RoutedEventArgs e)
        {
            // Implement the functionality for the BackButtonEticket_Click event here
        }
        private void BackButtonParking_Click(object sender, RoutedEventArgs e)
        {
            HomePage.IsSelected = true;
        }
        private void CalculateTotalCost_Click(object sender, RoutedEventArgs e)
        {
            // Parse the input times
            if (!TimeSpan.TryParse(ArrivalTimeTextBox.Text, out TimeSpan arrivalTime) ||
                !TimeSpan.TryParse(ExitTimeTextBox.Text, out TimeSpan exitTime))
            {
                TotalCostTextBlock.Text = "Invalid input. Please enter valid military time.";
                return;
            }

            // Calculate the duration of parking
            TimeSpan duration = exitTime - arrivalTime;

            // Check if the exit time is before the arrival time (next day scenario)
            if (duration.TotalMinutes < 0)
            {
                duration = new TimeSpan(24, 0, 0) - arrivalTime + exitTime;
            }

            // Calculate the total cost based on parking rates
            double totalCost = 50; // Initial cost for first 3 hours

            // Subtract the initial 3 hours from the duration
            if (duration.TotalHours > 3)
            {
                duration -= TimeSpan.FromHours(3);
                // Round up to the next full hour
                int extraHours = (int)Math.Ceiling(duration.TotalHours);
                // Charge 20 PHP for each succeeding hour
                totalCost += extraHours * 20;
            }

            // Display the total cost
            TotalCostTextBlock.Text = $"Total Cost: {totalCost} PHP";
        }
        private void goToReservation_Click(object sender, RoutedEventArgs e)
        {
            // Select the Parking Rates tab
            Reservation.IsSelected = true;
        }
        private void goToPayment_Click(object sender, RoutedEventArgs e)
        {
            // Select the Parking Rates tab
            Payment.IsSelected = true;
        }
        private void goToFeedback_Click(object sender, RoutedEventArgs e)
        {
            // Select the Parking Rates tab
            Feedbacks.IsSelected = true;
        }
        private void goToViewEticket_Click(object sender, RoutedEventArgs e)
        {
            // Select the Parking Rates tab
            ViewEtickets.IsSelected = true;
        }
        private void goToExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        private void goToParkingRates_Click(object sender, RoutedEventArgs e)
        {
            // Select the Parking Rates tab
            ParkingFee.IsSelected = true;
        }

        private void BackButtonReservation_Click(object sender, RoutedEventArgs e)
        {
            // Set the selected tab to the home tab
            HomePage.IsSelected = true;
        }
        private void BackButtonPayment_Click(object sender, RoutedEventArgs e)
        {
            // Set the selected tab to the home tab
            HomePage.IsSelected = true;
        }
        private void BackButtonParkingRates_Click(object sender, RoutedEventArgs e)
        {
            // Set the selected tab to the home tab
            HomePage.IsSelected = true;
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}