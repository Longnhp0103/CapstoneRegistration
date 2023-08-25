using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;

namespace CapstoneRegistration.Service
{
	public class StudentService : IStudentService
	{
		IStudentRepository _repository;
		CapstoneRigistrationContext _context;
		public StudentService(IStudentRepository repository, CapstoneRigistrationContext context)
		{
			_repository = repository;
			_context = context;
		}

		public List<Student> GetAllStudent()
		{
			return (List<Student>)_repository.GetAll();
		}

		public Student GetStudentByCode(string code)
		{
			return _context.Students.FirstOrDefault(s => s.Code == code);
		}

		public List<Student> GetStudentInGroup(int groupId)
		{
			List<Student> students = new List<Student>();

			students = _context.StudentInGroups
				.Where(s => s.GroupId == groupId)
				.Select(s => s.Student)
				.ToList();

			return students;
		}


		public Student GetStudentById(int studentId)
		{
			return _repository.GetById(studentId);
		}

		public List<Student> GetStudentByName(string name)
		{
			List<Student> students = _context.Students
				.Where(s => s.FullName.Contains(name))
				.ToList();
			return students;
		}


		public List<Student> GetStudentInSemester(int semesterId)
		{
			List<Student> students = new List<Student>();

			students = _context.StudentInSemesters
				.Where(s => s.SemesterId == semesterId)
				.Select(s => s.Student)
				.ToList();

			return students;
		}

		public List<int> GetStudentsExist()
		{
			List<int> existingStudentIds = _context.StudentInGroups
				.Select(s => s.StudentId)
				.ToList();

			return existingStudentIds;
		}

	}
}
