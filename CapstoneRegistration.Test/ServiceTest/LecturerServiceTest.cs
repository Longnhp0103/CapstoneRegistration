using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;
using CapstoneRegistration.Service;

namespace CapstoneRegistration.Test.ServiceTest
{
	[TestClass]
	public class LecturerServiceTest
	{
		CapstoneRigistrationContext context;
		ILecturerRepository lecturerRepository;
		ILecturerService lecturerService;

		[TestInitialize]
		public void Initialize()
		{
			context = new CapstoneRigistrationContext();
			lecturerRepository = new LecturerRepository(context);
			lecturerService = new LecturerService(lecturerRepository, context);
		}

		[TestMethod]
		public void Lecturer_Service_GetAllLecturer()
		{
			List<Lecturer> lecturers = lecturerService.GetAllLecturer();
			Assert.IsNotNull(lecturers);

		}

		[TestMethod]
		public void Lecturer_Service_GetLecturerById()
		{
			int id = 1;
			Lecturer lecturer = lecturerService.GetLecturerId(id);
			Assert.IsNotNull(lecturer);
		}

		[TestMethod]
		public void Lecturer_Service_InsertLecturer()
		{
			Lecturer lecturer = new Lecturer();
			lecturer.Name = "name";
			lecturer.Code = "code";
			lecturer.Password = "password";
			lecturer.Status = false;

			lecturerService.InsertLecturer(lecturer);
		}

		[TestMethod]
		public void Lecturer_Service_UpdateLecturer()
		{
			Lecturer lecturer = new Lecturer();
			lecturer.Id = 11;
			lecturer.Name = "Name";
			lecturer.Code = "Code";
			lecturer.Password = "Password";
			lecturer.Status = true;

			lecturerService.UpdateLecturer(lecturer);
		}

		[TestMethod]
		public void Lecturer_Service_UpdateLecturerStatus()
		{
			int id = 11;
			bool status = false;
			lecturerService.UpdateLecturerStatus(id, status);
		}

		[TestMethod]
		public void Lecturer_Service_CheckLogin()
		{
			string code = "js001";
			string password = "abc";

			bool result = lecturerService.CheckLogin(code, password);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Lecturer_Service_CheckCode()
		{
			string code = "js001";

			bool result = lecturerService.CheckCode(code);
			Assert.IsTrue(result);
		}
	}
}
