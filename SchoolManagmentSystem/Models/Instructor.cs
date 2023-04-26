using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagmentSystem.Models
{                               
	public class Instructor
	{
		[Key]
		public int ins_ID { get; set; }

		[Column(TypeName = "Varchar(255)")]
		public string fname { get; set; }

        [Column(TypeName = "Varchar(255)")]
		public string lname { get; set; }

        [Column(TypeName = "Varchar(255)")]
        public string gender { get; set; }

		public int age { get; set; }

		public int contact_no { get; set; }

        [Column(TypeName = "Varchar(255)")]
		public string ins_email { get; set; }

        [Column(TypeName = "Varchar(255)")]
		public string ins_pass { get; set; }
    }
}

