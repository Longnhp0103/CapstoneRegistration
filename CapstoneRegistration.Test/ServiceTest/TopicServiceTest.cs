using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;
using CapstoneRegistration.Service;

namespace CapstoneRegistration.Test.ServiceTest
{
    [TestClass]
    public class TopicServiceTest
    {
        CapstoneRigistrationContext context;
        ITopicRepository topicRepository;
        ITopicService topicService;

        [TestInitialize]
        public void Initalize()
        {
            context = new CapstoneRigistrationContext();
            topicRepository = new TopicRepository(context);
            topicService = new TopicService(topicRepository, context);
        }

        [TestMethod]
        public void Topic_Service_DeleteTopic()
        {
            int id = 1;
            topicRepository.Delete(id);
        }

        [TestMethod]
        public void Topic_Service_GetAllTopic()
        {
            List<Topic> topics = topicService.GetAllTopic();
            Assert.IsNotNull(topics);
        }

        [TestMethod]
        public void Topic_Service_GetTopicByGroup()
        {
            int id = 1;
            Topic topic = topicService.GetTopicByGroup(id);
            Assert.IsNotNull(topic);
        }

        [TestMethod]
        public void Topic_Service_GetTopicById()
        {
            int id = 1;
            Topic topic = topicService.GetTopicById(id);
            Assert.IsNotNull(topic);
        }

        [TestMethod]
        public void Topic_Service_GetTopicByLecturer()
        {
            int id = 1;
            List<Topic> topics = topicService.GetTopicByLecturer(id);
            Assert.IsNotNull(topics);
        }

        [TestMethod]
        public void Topic_Service_GetTopicBySemester()
        {
            int id = 1;
            List<Topic> topics = topicService.GetTopicInSemester(id);
            Assert.IsNotNull(topics);
        }

        [TestMethod]
        public void Topic_Service_InsertTopic()
        {
            Topic topic = new Topic();
            topic.Name = "test";
            topic.Description = "test";
            topic.CreateDate = DateTime.Now;
            topic.SemesterId = 1;
            topic.Status = false;
            topicService.InsertTopic(topic);
        }

        [TestMethod]
        public void Topic_Service_UpdateTopic()
        {
            Topic topic = new Topic();
            topic.Id = 3;
            topic.Name = "test";
            topic.Description = "test";
            topic.CreateDate = DateTime.Now;
            topic.SemesterId = 1;
            topic.Status = true;
            topicService.UpdateTopicAsync(topic);
        }
    }
}
