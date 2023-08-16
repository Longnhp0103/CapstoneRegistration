using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;

namespace CapstoneRegistration.Service
{
	public class SemesterService : ISemesterService
	{
		private SemesterRepository repository;
		public SemesterService(SemesterRepository repository)
		{
			this.repository = repository;
		}

		public IEnumerable<Semester> GetAllSemester()
		{
			return repository.GetAll();
		}

		public Semester GetSemesterById(int id)
		{
			return repository.GetById(id);
		}

		public void InsertSemester(Semester obj)
		{
			repository.Insert(obj);
		}

		public void UpdateSemester(Semester obj)
		{
			repository?.Update(obj);
		}
	}
}
