using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Friziderko.Model;

namespace Friziderko.ViewModel
{
    public class BazaPristupServis
    {
        private SQLiteAsyncConnection conn;
        private readonly string dbPath;
        public BazaPristupServis() { dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "BazaPodataka.db3"); } // constructor da poveze put

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
            conn.CreateTableAsync<Recept>(); 
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
        public void DodajRecept(Recept recept)
        {
            try
            {
                InitNamirnica();

                // basic validation to ensure a namirnica is entered
                if (recept is null)
                    throw new Exception("Nepostojeći recept");

                conn.InsertAsync(recept); // ubacuje u bazu

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
        public async Task<List<Recept>> GetAllReceptiAsync()
        {
            try
            {
                InitNamirnica();
                return await conn.Table<Recept>().ToListAsync();
            }
            catch (Exception ex)
            {
                //StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Recept>();
        }

    }
}
