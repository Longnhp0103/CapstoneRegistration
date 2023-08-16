using CapstoneRegistration.Repository.Models;

namespace CapstoneRegistration.Service
{
	public interface ISemesterService
	{
		IEnumerable<Semester> GetAllSemester();
		Semester GetSemesterById(int id);
		void InsertSemester(Semester obj);
		void UpdateSemester(Semester obj);

	}
}
