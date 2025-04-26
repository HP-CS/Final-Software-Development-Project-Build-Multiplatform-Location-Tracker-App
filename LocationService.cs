using Microsoft.Maui.Essentials;
using LocationTrackerApp.Models;

namespace LocationTrackerApp.Services
{
    public static class LocationService
    {
        public static async Task<LocationPoint> GetCurrentLocationAsync()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
            {
                return new LocationPoint
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    Timestamp = DateTime.Now
                };
            }
            return null;
        }
    }
}
