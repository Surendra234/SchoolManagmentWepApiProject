using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagmentSystem.Models;

namespace SchoolManagmentSystem.Data
{
	public class SchoolManagmentDbContext : IdentityDbContext
    {
		public SchoolManagmentDbContext(DbContextOptions<SchoolManagmentDbContext> options) : base(options)
		{

		}

		public DbSet<Students> Students { get; set;}

		public DbSet<Instructor> Instructors { get; set; }

		public DbSet<Courses> Courses { get; set; }

		public DbSet<Subjects> Subjects { get; set; }

		public DbSet<Schedules> Schedules { get; set; }

		public DbSet<Transactions> Transactions { get; set; }
	}
}
