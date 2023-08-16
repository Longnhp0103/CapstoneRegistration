using CapstoneRegistration.Repository.Models;

namespace CapstoneRegistration.Repository.Repository
{
	public class SemesterRepository : GenericRepository<Semester>, ISemesterRepository
	{
		public SemesterRepository(CapstoneRigistrationContext dbContext) : base(dbContext)
		{
		}
	}
}
