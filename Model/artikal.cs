using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friziderko.Model
{
	[Table("Artikal")]
	public class Artikal
	{
		public Artikal()
		{

		}
		public Artikal(string naziv, bool precrtano)
		{
			Naziv = naziv;
			Precrtano = precrtano;
		}
		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id { get; set; }

		[MaxLength(40), Unique]
		public string Naziv { get; set; }

		public bool Precrtano { get; set; }
	}
}
