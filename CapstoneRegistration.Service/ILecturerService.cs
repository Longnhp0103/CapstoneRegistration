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

		bool CheckLogin(string userName, string password);

		bool CheckCode(string code);
		List<Lecturer> GetLecturerByGroup(int groupId);
		Lecturer GetLecturerByCode(string code);
		List<Lecturer> GetLecturersByTopic(int topicId);
	}
}
