using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;

namespace CapstoneRegistration.Test.RepositoryTest
{
	[TestClass]
	public class GroupRepositpryTest
	{
		CapstoneRigistrationContext context;
		IGroupRepository repository;

		[TestInitialize]
		public void Initialize()
		{
			context = new CapstoneRigistrationContext();
			repository = new GroupRepository(context);
		}

		[TestMethod]
		public void Group_Repository_GetAll()
		{
			var list = repository.GetAll();
			Assert.IsNotNull(list);
		}

		[TestMethod]
		public void Group_Repository_Create()
		{
			Group group = new Group();
			group.Name = "Test";
			group.NumberOfMember = 1;
			group.SemesterId = 1;
			group.TopicId = 1;
			group.Leader = 1;

			repository.Insert(group);
		}

		[TestMethod]
		public void Group_Repository_Update()
		{
			Group group = new Group();
			group.Id = 4;
			group.Name = "TestUpdate";
			group.NumberOfMember = 1;
			group.SemesterId = 1;
			group.TopicId = 1;
			group.Leader = 1;

			repository.Update(group);
		}
	}
}
