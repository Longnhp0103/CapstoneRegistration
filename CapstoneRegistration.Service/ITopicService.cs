using CapstoneRegistration.Repository.Models;

namespace CapstoneRegistration.Service
{
	public interface ITopicService
	{
		List<Topic> GetAllTopic();
		List<Topic> GetTopicByLecturer(int lecturerId);
		Topic GetTopicByGroup(int groupId);
		List<Topic> GetTopicInSemester(int semesterId);
		void InsertTopic(Topic topic);
		void UpdateTopic(Topic topic);
		void DeleteTopic(int id);
		Topic GetTopicById(int id);

	}
}
