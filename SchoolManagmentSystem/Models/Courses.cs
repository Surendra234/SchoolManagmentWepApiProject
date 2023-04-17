using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagmentSystem.Models
{
	public class Courses
	{
		[Key]
		public int course_ID { get; set; }

        [Column(TypeName = "Varchar(255)")]
		public string course_name { get; set; }

        [Column(TypeName = "Varchar(255)")]
		public string course_desc { get; set; }

		public int school_yr { get; set; }
    }
}

