using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;

namespace CapstoneRegistration.Test.RepositoryTest
{
	[TestClass]
	public class StudentRepositoryTest
	{
		IStudentRepository repository;
		CapstoneRigistrationContext context;

		[TestInitialize]
		public void Initialize()
		{
			context = new CapstoneRigistrationContext();
			repository = new StudentRepository(context);
		}

		[TestMethod]
		public void Student_Repository_GetAll()
		{
			var list = repository.GetAll();
			Assert.IsNotNull(list);
		}

		[TestMethod]
		public void Semester_Repository_Update()
		{
			int id = 51;

			Student student = new Student();
			student.Id = id;
			student.Code = "Test";
			student.FullName = "Test";
			student.Avatar = "Test";
			student.DateOfBirth = DateTime.Now;
			student.Gender = true;
			student.Status = true;

			repository.Update(student);
		}

	}
}
