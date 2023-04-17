using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagmentSystem
{
	public class Students
	{
		[Key]
		public int stud_ID { get; set; }

		[Column(TypeName = "Varchar(255)")]
		public string fname { get; set; }

        [Column(TypeName = "Varchar(255)")]
		public string lname { get; set; }

        [Column(TypeName = "Varchar(255)")]
        public string gender { get; set; }

		public int age { get; set; }

		public int contact_no { get; set; }

        [Column(TypeName = "Varchar(255)")]
        public string stud_email { get; set; }

        [Column(TypeName = "Varchar(255)")]
        public string stud_pass { get; set; }
    }
}

