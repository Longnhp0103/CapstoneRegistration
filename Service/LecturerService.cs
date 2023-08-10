using Repository.Models;
using Repository.Repository;

namespace Service
{
	public class LecturerService
	{
		private CapstoneRigistrationContext _dbContext;
		private LecturerRepository _repository;

		public LecturerService(CapstoneRigistrationContext dbContext, LecturerRepository repository)
		{
			_dbContext = dbContext;
			_repository = repository;
		}

		public void AddLecturer(Lecturer lecturer)
		{

		}
	}
}
