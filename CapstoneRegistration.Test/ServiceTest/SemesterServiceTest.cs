using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;
using CapstoneRegistration.Service;

namespace CapstoneRegistration.Test.ServiceTest
{
	[TestClass]
	public class SemesterServiceTest
	{
		ISemesterService semesterService;
		ISemesterRepository repository;
		CapstoneRigistrationContext context;

		[TestInitialize]
		public void Initialize()
		{
			context = new CapstoneRigistrationContext();
			repository = new SemesterRepository(context);
			semesterService = new SemesterService(repository, context);
		}

		[TestMethod]
		public void Semester_Service_AddStudent()
		{
			List<Student> students = new List<Student>()
			{
				new Student { Id = 3, Code = "S001", FullName = "Student 1",},
				new Student { Id = 4, Code = "S002", FullName = "Student 2",}

			};
			int semesterId = 1;
			semesterService.AddStudentToSemester(students, semesterId);
		}

		[TestMethod]
		public void Semester_Service_GetAllSemester()
		{
			List<Semester> semesters = semesterService.GetAllSemester();
			Assert.IsNotNull(semesters);
		}

		[TestMethod]
		public void Semester_Service_GetSemesterById()
		{
			int semesterId = 1;
			Semester semester = semesterService.GetSemesterById(semesterId);
			Assert.IsNotNull(semester);
		}

		[TestMethod]
		public void Semester_Service_InsertSemester()
		{
			Semester semester = new Semester();
			semester.Name = "Spring";
			semester.Year = 2025;
			semester.StartDate = new DateTime(2025, 01, 01);
			semester.EndDate = new DateTime(2025, 04, 01);

			semesterService.InsertSemester(semester);
		}

		[TestMethod]
		public void Semester_Service_UpdateSemester()
		{
			int id = 4;
			Semester semester = new Semester();
			semester.Id = id;
			semester.Name = "Fall2024";
			semester.Year = 2024;
			semester.StartDate = DateTime.Now;
			semester.EndDate = DateTime.Now;

			semesterService.UpdateSemester(semester);
		}
	}
}
