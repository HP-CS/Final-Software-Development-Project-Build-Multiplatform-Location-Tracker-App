using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using LocationTrackerApp.Services;
using LocationTrackerApp.Models;
using LocationTrackerApp.Data;

namespace LocationTrackerApp.Views
{
    public partial class MainPage : ContentPage
    {
        private bool _isTracking = false;
        private LocationDatabase _database;

        public MainPage()
        {
            InitializeComponent();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "locations.db3");
            _database = new LocationDatabase(dbPath);
        }

        private async void OnStartClicked(object sender, EventArgs e)
        {
            _isTracking = true;
            while (_isTracking)
            {
                var location = await LocationService.GetCurrentLocationAsync();
                if (location != null)
                {
                    await _database.SaveLocationAsync(location);

                    var pin = new Pin
                    {
                        Location = new Microsoft.Maui.Devices.Sensors.Location(location.Latitude, location.Longitude),
                        Label = "Tracked Point"
                    };
                    LocationMap.Pins.Add(pin);
                }
                await Task.Delay(5000); // Every 5 seconds
            }
        }

        private void OnStopClicked(object sender, EventArgs e)
        {
            _isTracking = false;
        }
    }
}
