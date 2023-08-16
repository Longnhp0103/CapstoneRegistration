using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;

namespace CapstoneRegistration.Test.RepositoryTest
{
	[TestClass]
	public class LecturerRepositoryTest
	{
		CapstoneRigistrationContext context;
		ILecturerRepository repository;

		[TestInitialize]
		public void Initialize()
		{
			context = new CapstoneRigistrationContext();
			repository = new LecturerRepository(context);
		}

		[TestMethod]
		public void Lecturer_Repository_GetAll()
		{
			var list = repository.GetAll();
			Assert.IsNotNull(list);
		}

		[TestMethod]
		public void Lecturer_Repository_Create()
		{
			Lecturer lecturer = new Lecturer();
			lecturer.Name = "name";
			lecturer.Code = "code";
			lecturer.Password = "password";
			lecturer.Status = false;

			repository.Insert(lecturer);
		}

		[TestMethod]
		public void Lecturer_Repository_Update()
		{
			Lecturer lecturer = new Lecturer();
			lecturer.Id = 11;
			lecturer.Name = "Name";
			lecturer.Code = "Code";
			lecturer.Password = "Password";
			lecturer.Status = true;

			repository.Update(lecturer);
		}


	}
}
