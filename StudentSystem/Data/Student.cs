namespace StudentSystem.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class Student
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		
		public string PhoneNumber { get; set; }

		public DateTime? BDay { get; set; }

		public List<StudentCourses> Courses { get; set; } = new List<StudentCourses>();

		public List<Homework> Homeworks { get; set; } = new List<Homework>();



	}
}
