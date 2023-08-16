using CapstoneRegistration.Repository.Models;

namespace CapstoneRegistration.Repository.Repository
{
	public class StudentRepository : GenericRepository<Student>, IStudentRepository
	{
		public StudentRepository(CapstoneRigistrationContext dbContext) : base(dbContext)
		{
		}
	}
}
