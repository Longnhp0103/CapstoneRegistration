using CapstoneRegistration.Repository.Models;

namespace CapstoneRegistration.Service
{
	public interface ILecturerService
	{
		void DeleteSemester(int id);
		List<Semester> GetAllSemester();
	}
}
