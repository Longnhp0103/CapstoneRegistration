using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneManagement.Pages.Admin.GroupManagement
{
	public class IndexModel : PageModel
	{
		IGroupService groupService;
		public IndexModel(IGroupService groupService)
		{
			this.groupService = groupService;
		}
		public IList<Group> Groups { get; set; }

		public async Task OnGetAsync()
		{
			Groups = groupService.GetGroupInSemester(1);
		}
	}
}
