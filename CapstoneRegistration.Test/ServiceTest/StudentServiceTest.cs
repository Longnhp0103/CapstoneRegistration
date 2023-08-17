using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;
using CapstoneRegistration.Service;

namespace CapstoneRegistration.Test.ServiceTest
{
	[TestClass]
	public class StudentServiceTest
	{
		CapstoneRigistrationContext context;
		IStudentService studentService;
		IStudentRepository studentRepository;

		[TestInitialize]
		public void Initialize()
		{
			context = new CapstoneRigistrationContext();
			studentRepository = new StudentRepository(context);
			studentService = new StudentService(studentRepository, context);
		}

		[TestMethod]
		public void Student_Service_GetAll()
		{
			List<Student> students = studentService.GetAllStudent();
			Assert.IsNotNull(students);
		}

		[TestMethod]
		public void Student_Service_GetStudentByCode()
		{
			string code = "S001";
			Student student = studentService.GetStudentByCode(code);
			Assert.IsNotNull(student);
		}

		[TestMethod]
		public void Student_Service_GetStudentInGroup()
		{
			int groupId = 1;
			List<Student> students = studentService.GetStudentInGroup(groupId);
			Assert.IsNotNull(students);
		}

		[TestMethod]
		public void Student_Service_GetStudentById()
		{
			int id = 1;
			Student student = studentService.GetStudentById(id);
			Assert.IsNotNull(student);
		}

		[TestMethod]
		public void Student_Service_GetStudentByName()
		{
			string name = "n";
			List<Student> students = studentService.GetStudentByName(name);
			Assert.IsNotNull(students);
		}

		[TestMethod]
		public void Student_Service_GetStudentInSemester()
		{
			int semesterId = 1;
			List<Student> students = studentService.GetStudentInSemester(semesterId);
			Assert.IsNotNull(students);
		}


	}
}
