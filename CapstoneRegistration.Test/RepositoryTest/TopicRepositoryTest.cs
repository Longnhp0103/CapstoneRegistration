using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;

namespace CapstoneRegistration.Test.RepositoryTest
{
	[TestClass]
	public class TopicRepositoryTest
	{
		CapstoneRigistrationContext context;
		ITopicRepository repository;

		[TestInitialize]
		public void Initialize()
		{
			context = new CapstoneRigistrationContext();
			repository = new TopicRepository(context);
		}

		[TestMethod]
		public void Topic_Repository_GetAll()
		{
			var list = repository.GetAll();
			Assert.IsNotNull(list);
		}

		[TestMethod]
		public void Topic_Repository_Create()
		{
			Topic topic = new Topic();
			topic.Name = "test";
			topic.Description = "test";
			topic.CreateDate = DateTime.Now;
			topic.SemesterId = 1;
			topic.Status = false;

			repository.Insert(topic);
		}

		[TestMethod]
		public void Topic_Repository_Update()
		{
			Topic topic = new Topic();
			topic.Id = 3;
			topic.Name = "test";
			topic.Description = "test";
			topic.CreateDate = DateTime.Now;
			topic.SemesterId = 1;
			topic.Status = false;

			repository.Update(topic);
		}
	}
}
