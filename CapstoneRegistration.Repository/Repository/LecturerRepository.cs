using CapstoneRegistration.Repository.Models;

namespace CapstoneRegistration.Repository.Repository
{
	public class LecturerRepository : GenericRepository<Lecturer>, ILecturerRepository
	{
		public LecturerRepository(CapstoneRigistrationContext dbContext) : base(dbContext)
		{
		}

		public async Task<bool> UpdateLecturerStatus(int? lecturerId, bool status)
		{
			{
				var lecturer = await _dbContext.Lecturers.FindAsync(lecturerId);

				if (lecturer != null)
				{
					lecturer.Status = status;
					await _dbContext.SaveChangesAsync();
					return true;
				}

				return false;
			}
		}
	}
}
