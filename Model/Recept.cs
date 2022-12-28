using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Friziderko.Model
{
    public struct Podatak
    {
        public Namirnica namirnica;
        public int kolicina;
    }
    [Table("Recept")]
    public class Recept
    {
        public Recept()
        {

        }
        public Recept(int id, string naziv, string opis, List<Podatak> podaci)
        {
            Id = id;
            Naziv = naziv;
            Opis = opis;
            Podaci = podaci;
        }

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(40), Unique]
        public string Naziv { get; set; }

        [MaxLength(250)]
        public string Opis { get; set; }

        public List<Podatak> Podaci = new List<Podatak>();

    }
}
