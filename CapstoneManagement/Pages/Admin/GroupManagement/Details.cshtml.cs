using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneManagement.Pages.Admin.GroupManagement
{
	public class DetailsModel : PageModel
	{
		IGroupService groupService;

		public DetailsModel(IGroupService groupService)
		{
			this.groupService = groupService;
		}

		public Group Group { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Group = groupService.GetGroupById(id.Value);
			return Page();
		}
	}
}
