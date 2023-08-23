using CapstoneRegistration.Repository.Models;

namespace CapstoneRegistration.Service
{
    public interface IStudentService
    {
        List<Student> GetAllStudent();
        List<Student> GetStudentByName(string name);
        Student GetStudentByCode(string code);
        List<Student> GetStudentInGroup(int groupId);
        List<Student> GetStudentInSemester(int semesterId);
        Student GetStudentById(int studentId);
        List<int> GetStudentsExist();
    }
}