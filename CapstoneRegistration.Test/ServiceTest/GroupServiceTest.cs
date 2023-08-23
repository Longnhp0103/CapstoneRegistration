using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;
using CapstoneRegistration.Service;

namespace CapstoneRegistration.Test.ServiceTest
{
    [TestClass]
    public class GroupServiceTest
    {
        CapstoneRigistrationContext context;
        IGroupRepository repository;
        IGroupService groupService;

        [TestInitialize]
        public void Initialize()
        {
            context = new CapstoneRigistrationContext();
            repository = new GroupRepository(context);
            groupService = new GroupService(repository, context);
        }

        [TestMethod]
        public void Group_Service_AddLeaderToGroup()
        {
            int leaderId = 1;
            int groupId = 1;
            groupService.AddLeaderToGroup(leaderId, groupId);
        }

        [TestMethod]
        public void Group_Service_AddStudentToGroup()
        {

            List<int> students = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7,

            };
            int groupId = 2;

            groupService.AddStudentToGroup(students, groupId);
        }

        [TestMethod]
        public void Group_Service_GetAllGroup()
        {
            List<Group> groups = groupService.GetAllGroup();

            Assert.IsNotNull(groups);
        }

        [TestMethod]
        public void Group_Service_GetGroupByLecturer()
        {
            int lecturerId = 1;

            List<Group> groups = groupService.GetGroupByLecturer(lecturerId);
            Assert.IsNotNull(groups);
        }

        [TestMethod]
        public void Group_Service_GetGroupInSemester()
        {
            int semesterId = 1;
            List<Group> groups = groupService.GetGroupInSemester(semesterId);
            Assert.IsNotNull(groups);
        }
        [TestMethod]
        public void Group_Service_Update()
        {
            Group group = new Group()
            {
                Id = 3,
                Name = "Name",
                NumberOfMember = 5,
                TopicId = 2,
                SemesterId = 1,
                Leader = 20
            };
            groupService.UpdateGroup(group);

        }
    }
}
