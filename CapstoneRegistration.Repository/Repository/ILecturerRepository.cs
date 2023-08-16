using CapstoneRegistration.Repository.Models;

namespace CapstoneRegistration.Repository.Repository
{
	public interface ILecturerRepository : IGenericRepository<Lecturer>
	{
		Task<bool> UpdateLecturerStatus(int? timlineId, bool status);
	}
}
