using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Friziderko.Model
{
    [Table("Recept")]
    public class Recept
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(40), Unique]
        public string Naziv { get; set; }

        [MaxLength(250)]
        public string Opis { get; set; }
        public struct Podatak
        {
            public Namirnica namirnica;
            public int kolicina;
        }

    }
}
