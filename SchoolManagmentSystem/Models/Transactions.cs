using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagmentSystem.Models
{
	public class Transactions
	{
		[Key]
		public int trans_ID { get; set; }

        [Column(TypeName = "Varchar(255)")]
        public string trans_name { get; set; }

		public int stud_ID { get; set; }
		public Students Students { get; set; }

        [Column(TypeName = "Varchar(255)")]
        public string trans_date { get; set; }
	}
}

