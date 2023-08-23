using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace CapstoneRegistration.Service
{
    public class GroupService : IGroupService
    {
        IGroupRepository _repository;
        CapstoneRigistrationContext _context;
        public GroupService(IGroupRepository repository, CapstoneRigistrationContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void AddLeaderToGroup(int leaderId, int groupId)
        {
            Group group = _repository.GetById(groupId);
            group.Leader = leaderId;
            group.NumberOfMember++;
            _repository.Update(group);
        }

        public void AddStudentToGroup(List<int> students, int groupId)
        {
            var group = _repository.GetById(groupId);

            if (group != null)
            {
                foreach (var student in students)
                {
                    var existingStudent = _context.Students.Find(student);

                    if (existingStudent != null)
                    {
                        var studentInGroup = new StudentInGroup
                        {
                            Student = existingStudent,
                            Group = group
                        };
                        if (group.NumberOfMember < 5)
                        {
                            group.NumberOfMember++;
                            group.StudentInGroups.Add(studentInGroup);
                        }

                    }
                }

                _context.SaveChanges();
            }
        }

        public bool CheckGroup(int groupId)
        {
            Group group = _context.Groups.FirstOrDefault(g => g.Id == groupId);
            if (group != null)
            {
                return true;
            }
            return false;
        }

        public void DeleteGroup(Group group)
        {
            _repository.Delete(group);
        }

        public List<Group> GetAllGroup()
        {
            return (List<Group>)_repository.GetAll();
        }

        public Group GetGroupById(int groupId)
        {
            return _context.Groups.AsNoTracking()
                .Include(s => s.Semester)
                .Include(t => t.Topic)
                .Include(l => l.LeaderNavigation)
                .Include(g => g.StudentInGroups)
                .FirstOrDefault(g => g.Id == groupId);
        }

        public List<Group> GetGroupByLecturer(int lecturerId)
        {
            List<Group> groups = new List<Group>();
            groups = _context.LecturerInGroups
                .Where(g => g.InMainLecturer == lecturerId)
                .Select(g => g.Group)
                .ToList();
            return groups;
        }

        public List<Group> GetGroupInSemester(int semesterId)
        {
            List<Group> groups = new List<Group>();
            groups = _context.Groups
                .Include(s => s.Semester)
                .Include(t => t.Topic)
                .Include(l => l.LeaderNavigation)
                .Where(g => g.SemesterId == semesterId)
                .ToList();
            return groups;
        }

        public void InsertGroup(Group group)
        {
            _repository.Insert(group);
        }

        public void UpdateGroup(Group group)
        {
            _repository.Update(group);
        }

        public async Task<List<Student>> GetAllStudent()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<List<Semester>> GetAllSemester()
        {
            return await _context.Semesters.ToListAsync();
        }

        public async Task<List<Topic>> GetAllTopic()
        {
            return await _context.Topics.ToListAsync();
        }
    }
}
