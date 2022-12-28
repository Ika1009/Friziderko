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
        private SQLiteConnection conn;
        private string dbPath;
        public void InitNamirnica()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Namirnica>();
        }
        public void InitRecept()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(dbPath);
            //conn.CreateTable<Namirnice>(); da se stavi za recept kad se napravi klasa
        }
        public void DodajNamirnicu(Namirnica namirnica)
        {
            int result = 0;
            try
            {
                // enter this line
                InitNamirnica();

                // basic validation to ensure a name was entered
                if (namirnica is null)
                    throw new Exception("Ne postojeca namirnica");

                // enter this line
                result = conn.Insert(namirnica);
            }
        }
        public DodajUBazu(string _dbPath) { dbPath = _dbPath; }
    }
}
