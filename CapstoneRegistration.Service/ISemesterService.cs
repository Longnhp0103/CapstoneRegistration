using CapstoneRegistration.Repository.Models;

namespace CapstoneRegistration.Service
{
	public interface ISemesterService
	{
		List<Semester> GetAllSemester();
		Semester GetSemesterById(int id);
		void InsertSemester(Semester obj);
		void UpdateSemester(Semester obj);
		void AddStudentToSemester(List<Student> students, int semesterId);
	}
}
