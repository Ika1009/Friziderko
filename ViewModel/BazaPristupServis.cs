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

        private void InitNamirnica()
        {
            if (conn != null)
                return;
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Namirnica>();
        }
        private void InitRecept()
        {
            if (conn != null)
                return;
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Recept>(); 
        }
        public string DodajNamirnicu(Namirnica namirnica)
        {
            string statusMessage;
            try
            {
                InitNamirnica();

                // basic validation to ensure a namirnica is entered
                if (namirnica is null)
                    throw new Exception("Nepostojeca namirnica");

                conn.InsertAsync(namirnica); // ubacuje u bazu

                statusMessage = "success";
            }
            catch (Exception ex)
            {
                statusMessage = ex.Message;
            }
            return statusMessage;
        }
		public void DodajRecept(Recept recept)
        {
            try
            {
				InitRecept();

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
                if (conn.Table<Namirnica>().ToListAsync() is null)
                    throw new Exception("Ne postoji ni jedna namirnica u frizideru!");
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
                InitRecept();
				if (conn.Table<Namirnica>() is null)
					throw new Exception("Ne postoji ni jedna namirnica u frizideru!");
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
