using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagmentSystem.Models
{
	public class Schedules
	{
		[Key]
		public int sched_ID { get; set; }

		public int course_ID { get; set; }
		public Courses Courses { get; set; }

		public int ins_ID { get; set; }
		public Instructor Instructor { get; set; }

		public int sub_ID { get; set; }
		public Subjects Subjects { get; set; }

		public int stud_ID { get; set; }
		public Students Students { get; set; }

		public string day { get; set; }

		public string time_start { get; set; }

		public string time_end { get; set; }
	}
}

