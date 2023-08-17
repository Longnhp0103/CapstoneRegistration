using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;

namespace CapstoneRegistration.Service
{
	public class SemesterService : ISemesterService
	{
		private ISemesterRepository repository;
		private CapstoneRigistrationContext context;
		public SemesterService(ISemesterRepository repository, CapstoneRigistrationContext context)
		{
			this.repository = repository;
			this.context = context;
		}

		public void AddStudentToSemester(List<Student> students, int semesterId)
		{
			var semester = repository.GetById(semesterId);

			if (semester != null)
			{
				foreach (var student in students)
				{
					var existingStudent = context.Students.Find(student.Id);

					if (existingStudent != null && !context.StudentInSemesters.Any(sis => sis.StudentId == existingStudent.Id))
					{
						var studentInSemester = new StudentInSemester
						{
							Student = existingStudent,
							Semester = semester
						};

						semester.StudentInSemesters.Add(studentInSemester);
					}
				}

				context.SaveChanges();
			}
		}


		public List<Semester> GetAllSemester()
		{
			return (List<Semester>)repository.GetAll();
		}

		public Semester GetSemesterById(int id)
		{
			return repository.GetById(id);
		}

		public void InsertSemester(Semester obj)
		{
			repository.Insert(obj);
		}

		public void UpdateSemester(Semester obj)
		{
			repository?.Update(obj);
		}
	}
}
