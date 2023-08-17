using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;

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

		public List<Lecturer> GetAllLecturer()
		{
			return (List<Lecturer>)_repository.GetAll();
		}

		public Lecturer GetLecturerId(int id)
		{
			return _repository.GetById(id);
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
	}
}
