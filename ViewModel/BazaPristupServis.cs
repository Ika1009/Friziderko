﻿using System;
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
        
        //INITI
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Artikal>();
            conn.CreateTableAsync<Namirnica>();
            conn.CreateTableAsync<Recept>();
        }
        // DODAVANJE
		public string DodajArtikal(Artikal artikal)
		{
			string statusMessage;
			try
			{
				Init();

				// basic validation to ensure a namirnica is entered
				if (artikal is null)
					throw new Exception("Nepostojeca namirnica");

				conn.InsertAsync(artikal); // ubacuje u bazu

				statusMessage = "success";
			}
			catch (Exception ex)
			{
				statusMessage = ex.Message;
			}
			return statusMessage;
		}
		public string DodajNamirnicu(Namirnica namirnica)
        {
            string statusMessage;
            try
            {
                Init();

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
				Init();

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

        // GET ALL
		public async Task<List<Artikal>> GetAllArtikalsAsync()
		{
			try
			{
				Init();
				if (conn.Table<Artikal>().ToListAsync() is null)
					throw new Exception("Ne postoji ni jedna Artikal u Shopping Listi!");
				return await conn.Table<Artikal>().ToListAsync();
			}
			catch (Exception ex)
			{
                //StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                await Shell.Current.DisplayAlert("Greška", "Došlo je do greške pri prekazivanju: " + ex.Message, "OK");
            }

			return new List<Artikal>();
		}
		public async Task<List<Namirnica>> GetAllNamirniceAsync()
        {
            try
            {
                Init();
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
                Init();
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

        // BRISANJE
		public void ObrisiArtikal(Artikal artikal)
		{
			Init();

			conn.DeleteAsync(artikal);
		}
		public void ObrisiNamirnicu(Namirnica namirnica)
        {
            Init();

            conn.DeleteAsync(namirnica);
        }
        public void ObrisiRecept(Recept recept)
        {
            Init();

            conn.DeleteAsync(recept);
        }

		public async Task<string> UpdateKolicinu(Namirnica namirnica)
		{
			string statusMessage;
			try
			{
				Init();

				await conn.UpdateAsync(namirnica);

				statusMessage = "success";
			}
			catch (Exception ex)
			{
				statusMessage = ex.Message;
			}
			return statusMessage;
		}
		public async void IzmeniArtikal(Artikal artikal)
		{
			string statusMessage;
			try
			{
				Init();

				await conn.UpdateAsync(artikal);

				statusMessage = "success";
			}
			catch (Exception ex)
			{
				statusMessage = ex.Message;
			}
		}
	}
}
