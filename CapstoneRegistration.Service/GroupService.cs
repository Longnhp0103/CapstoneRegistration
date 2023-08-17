using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;

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
			_repository.Update(group);
		}

		public void AddStudentToGroup(List<Student> students, int groupId)
		{
			var group = _repository.GetById(groupId);

			if (group != null)
			{
				foreach (var student in students)
				{
					var existingStudent = _context.Students.Find(student.Id);

					if (existingStudent != null)
					{
						var studentInGroup = new StudentInGroup
						{
							Student = existingStudent,
							Group = group
						};

						group.StudentInGroups.Add(studentInGroup);
					}
				}

				_context.SaveChanges();
			}
		}

		public void DeleteGroup(Group group)
		{
			_repository.Delete(group);
		}

		public List<Group> GetAllGroup()
		{
			return (List<Group>)_repository.GetAll();
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


	}
}
