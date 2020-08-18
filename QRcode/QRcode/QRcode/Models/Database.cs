using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QRcode.Models
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Record>().Wait();
          //  _database.CreateTableAsync<Configuration>().Wait();
        }

        public Task<List<Record>> GetRecordAsync()
        {
            return _database.Table<Record>().OrderByDescending(i => i.Date).ToListAsync();
        }

        public Task<int> SavePersonAsync(Record record)
        {
            return _database.InsertAsync(record);
        }

        public Task<int> DeletePersonAsync(Record record)
        {
            return _database.DeleteAsync(record);                
        }

        public Task<int> UpdatePersonAsync(Record record)
        {
            return _database.UpdateAsync(record);
        }



    }
}
