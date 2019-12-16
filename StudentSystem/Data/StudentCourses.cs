namespace StudentSystem.Data
{
	public class StudentCourses
	{
		public int StudentId { get; set; }

		public Student Student { get; set; }

		public int CourseId { get; set; }

		public Courses Courses { get; set; }

	}
}
