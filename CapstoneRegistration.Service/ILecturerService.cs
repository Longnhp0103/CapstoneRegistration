using CapstoneRegistration.Repository.Models;

namespace CapstoneRegistration.Service
{
	public interface ILecturerService
	{
		List<Lecturer> GetAllLecturer();
		Lecturer GetLecturerId(int id);
		void UpdateLecturer(Lecturer lecturer);
		void UpdateLecturerStatus(int lecturerId, bool status);
		void InsertLecturer(Lecturer lecturer);
	}
}
