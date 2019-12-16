namespace StudentSystem.Data
{
	using System.ComponentModel.DataAnnotations;

	public class Resources
	{
		public int  Id { get; set; }
		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		public TypeOfResource Type { get; set; }

		[Required]
		public string Url { get; set; }

		public int CourseId { get; set; }
		public Courses Courses { get; set; }


	}
}
