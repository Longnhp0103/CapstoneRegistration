using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace CapstoneRegistration.Service
{
	public class LecturerService : ILecturerService
	{
		ILecturerRepository _repository;
		CapstoneRigistrationContext _context;
		public LecturerService(ILecturerRepository repository, CapstoneRigistrationContext context)
		{
			_repository = repository;
			_context = context;
		}

		public bool CheckCode(string code)
		{
			Lecturer lecturer = _context.Lecturers.FirstOrDefault(c => c.Code == code);
			if (lecturer == null)
			{
				return false;
			}
			return true;
		}

		public bool CheckLogin(string code, string password)
		{
			Lecturer lecturer = _context.Lecturers.FirstOrDefault(u => u.Code == code && u.Password == password);
			if (lecturer != null && lecturer.Status == true)
			{
				return true;
			}
			return false;
		}

		public List<Lecturer> GetAllLecturer()
		{
			return (List<Lecturer>)_repository.GetAll().Where(l => l.Status == true).ToList();
		}

		public Lecturer GetLecturerByCode(string code)
		{
			return _context.Lecturers.FirstOrDefault(l => l.Code == code);
		}

		public List<Lecturer> GetLecturerByGroup(int groupId)
		{
			List<Lecturer> lecturers = new List<Lecturer>();
			lecturers = _context.LecturerInGroups
				.Where(g => g.GroupId == groupId).Select(l => l.Lecturer)
				.ToList();
			return lecturers;
		}
		public Lecturer GetInMainLecturerByGroup(int groupId)
		{
			int inMainLecturerId = _context.LecturerInGroups
				.Where(g => g.GroupId == groupId).Select(l => l.InMainLecturer).FirstOrDefault();
			if (inMainLecturerId != 0)
			{
				Lecturer inMainLecturer = _context.Lecturers.Find(inMainLecturerId);
				return inMainLecturer;
			}

			return null;
		}


		public Lecturer GetLecturerId(int id)
		{
			return _context.Lecturers.AsNoTracking().FirstOrDefault(l => l.Id == id);
		}

		public List<Lecturer> GetLecturersByTopic(int topicId)
		{
			var lecturers = _context.TopicOfLecturers
				.Where(t => t.TopicId == topicId)
				.Select(t => t.Lecturer)
				.ToList();

			return lecturers;
		}


		public void InsertLecturer(Lecturer lecturer)
		{
			_repository.Insert(lecturer);
		}

		public void UpdateLecturer(Lecturer lecturer)
		{
			_repository.Update(lecturer);
		}

		public void UpdateLecturerStatus(int lecturerId, bool status)
		{
			Lecturer lecturer = GetLecturerId(lecturerId);
			lecturer.Status = status;
			if (lecturer != null)
			{
				_repository.Update(lecturer);
			}
		}

		public void AddLecturerToGroup(LecturerInGroup lecturerInGroup)
		{
			_context.LecturerInGroups.Add(lecturerInGroup);
			_context.SaveChanges();
		}
	}
}
