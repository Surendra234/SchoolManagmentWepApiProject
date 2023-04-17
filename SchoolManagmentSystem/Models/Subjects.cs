using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagmentSystem.Models
{
	public class Subjects
	{
		[Key]
		public int sub_ID { get; set; }

        [Column(TypeName = "Varchar(255)")]
		public string sub_name { get; set; }

		public int course_ID { get; set; }
		public Courses Courses { get; set; }
    }
}

