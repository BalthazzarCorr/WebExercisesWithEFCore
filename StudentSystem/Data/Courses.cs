﻿namespace StudentSystem.Data
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class Courses
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public decimal Price { get; set; }

		public List<StudentCourses> Students { get; set; }	 = new List<StudentCourses>();
		public List<Resources> Resources { get; set; }	 = new List<Resources>();

		public List<Homework> Homeworks { get; set; }	 = new List<Homework>();
	}
}
