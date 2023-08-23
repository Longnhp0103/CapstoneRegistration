using CapstoneRegistration.Repository.Models;

namespace CapstoneRegistration.Service
{
    public interface IGroupService
    {
        List<Group> GetAllGroup();
        void InsertGroup(Group group);
        void UpdateGroup(Group group);
        void DeleteGroup(Group group);
        List<Group> GetGroupInSemester(int semesterId);
        List<Group> GetGroupByLecturer(int lecturerId);
        void AddStudentToGroup(List<int> students, int groupId);
        void AddLeaderToGroup(int leaderId, int groupId);
        bool CheckGroup(int groupId);
        Group GetGroupById(int groupId);
        Task<List<Student>> GetAllStudent();
        Task<List<Semester>> GetAllSemester();
        Task<List<Topic>> GetAllTopic();
    }
}
