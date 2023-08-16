using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;

namespace CapstoneRegistration.Test.RepositoryTest
{
	[TestClass]
	public class SemesterRepositoryTest
	{
		CapstoneRigistrationContext context;
		ISemesterRepository repository;
		[TestInitialize]
		public void Initialize()
		{
			context = new CapstoneRigistrationContext();
			repository = new SemesterRepository(context);
		}

		[TestMethod]
		public void Semester_Repository_GetAll()
		{
			var list = repository.GetAll();
			Assert.IsNotNull(list);
		}

		[TestMethod]
		public void Semester_Repository_Create()
		{
			Semester semester = new Semester();
			semester.Name = "Spring";
			semester.Year = 2025;
			semester.StartDate = new DateTime(2025, 01, 01);
			semester.EndDate = new DateTime(2025, 04, 01);

			repository.Insert(semester);
		}

		[TestMethod]
		public void Semester_Repository_Update()
		{
			int id = 4;
			Semester semester = new Semester();
			semester.Id = id;
			semester.Name = "Fall2024";
			semester.Year = 2024;
			semester.StartDate = DateTime.Now;
			semester.EndDate = DateTime.Now;

			repository.Update(semester);
		}
	}
}
