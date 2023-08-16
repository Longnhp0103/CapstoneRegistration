using CapstoneRegistration.Repository.Models;

namespace CapstoneRegistration.Repository.Repository
{
	public class TopicRepository : GenericRepository<Topic>, ITopicRepository
	{
		public TopicRepository(CapstoneRigistrationContext dbContext) : base(dbContext)
		{
		}
	}
}
