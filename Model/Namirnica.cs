using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Friziderko.Model
{
    [Table("Namirnica")]
    public class Namirnica
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(40), Unique]
        public string Naziv { get; set; }

        [MaxLength(250)]
        public string Opis { get; set; }
        public string Kolicina { get; set; }
        public string Put_slika { get; set; }

    }
}
