using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Friziderko.Model;

namespace Friziderko.ViewModel
{
    public class DodajUBazu
    {
        private SQLiteAsyncConnection conn;
        private string dbPath;
        public DodajUBazu(string _dbPath) { dbPath = _dbPath; } // constructor da poveze put

        public void InitNamirnica()
        {
            if (conn != null)
                return;
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Namirnica>();
        }
        public void InitRecept()
        {
            if (conn != null)
                return;
            conn = new SQLiteAsyncConnection(dbPath);
            //conn.CreateTable<Namirnice>(); da se stavi za recept kad se napravi klasa
        }
        public void DodajNamirnicu(Namirnica namirnica)
        {
            try
            {
                InitNamirnica();

                // basic validation to ensure a namirnica is entered
                if (namirnica is null)
                    throw new Exception("Nepostojeca namirnica");

                conn.InsertAsync(namirnica); // ubacuje u bazu

                //StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                //StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }
        public async Task<List<Namirnica>> GetAllNamirniceAsync()
        {
            try
            {
                InitNamirnica();
                return await conn.Table<Namirnica>().ToListAsync();
            }
            catch (Exception ex)
            {
                //StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Namirnica>();
        }

    }
}
