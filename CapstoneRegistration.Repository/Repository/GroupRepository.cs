using CapstoneRegistration.Repository.Models;

namespace CapstoneRegistration.Repository.Repository
{
	public class GroupRepository : GenericRepository<Group>, IGroupRepository
	{
		public GroupRepository(CapstoneRigistrationContext dbContext) : base(dbContext)
		{
		}
	}
}
