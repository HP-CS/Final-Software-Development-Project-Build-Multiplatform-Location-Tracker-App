using SQLite;
using LocationTrackerApp.Models;

namespace LocationTrackerApp.Data
{
    public class LocationDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public LocationDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<LocationPoint>().Wait();
        }

        public Task<int> SaveLocationAsync(LocationPoint point)
        {
            return _database.InsertAsync(point);
        }

        public Task<List<LocationPoint>> GetLocationsAsync()
        {
            return _database.Table<LocationPoint>().ToListAsync();
        }
    }
}
