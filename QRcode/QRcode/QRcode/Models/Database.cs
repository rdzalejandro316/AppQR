using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        

        public Task<int> SaveRecordAsync(Record record)
        {
            return _database.InsertAsync(record);
        }

        public Task<int> DeleteRecordAsync(Record record)
        {
            return _database.DeleteAsync(record);                
        }

        public Task<int> UpdateRecordAsync(Record record)
        {
            return _database.UpdateAsync(record);
        }



    }
}
