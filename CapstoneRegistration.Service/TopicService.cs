using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;

namespace CapstoneRegistration.Service
{
	public class TopicService : ITopicService
	{
		ITopicRepository _repository;
		CapstoneRigistrationContext _context;
		public TopicService(ITopicRepository repository, CapstoneRigistrationContext context)
		{
			_repository = repository;
			_context = context;
		}

		public void DeleteTopic(int id)
		{
			var topicToDeactivate = _context.Topics.Find(id);

			if (topicToDeactivate != null)
			{
				topicToDeactivate.Status = false;
				_context.SaveChanges();
			}
		}

		public List<Topic> GetAllTopic()
		{
			return (List<Topic>)_repository.GetAll();
		}

		public Topic GetTopicByGroup(int groupId)
		{
			return _context.Topics.FirstOrDefault(t => t.Groups.Any(g => g.Id == groupId));
		}


		public Topic GetTopicById(int id)
		{
			return _repository.GetById(id);
		}

		public List<Topic> GetTopicByLecturer(int lecturerId)
		{
			List<Topic> list = new List<Topic>();

			list = _context.TopicOfLecturers
			   .Where(t => t.LecturerId == lecturerId)
			   .Select(t => t.Topic).ToList();
			return list;
		}

		public List<Topic> GetTopicInSemester(int semesterId)
		{
			List<Topic> list = new List<Topic>();
			list = _context.Topics
			   .Where(t => t.SemesterId == semesterId).ToList();
			return list;
		}

		public void InsertTopic(Topic topic)
		{
			if (topic != null)
			{
				_repository.Insert(topic);
			}
			else
			{
				throw new Exception("Your topic is not enought information");
			}
		}

		public void UpdateTopic(Topic topic)
		{
			if (topic != null)
			{
				_repository.Update(topic);
			}
			else
			{
				throw new Exception("Your topic is not enought information");
			}
		}
	}
}
