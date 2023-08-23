using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CapstoneManagement.Pages.Admin.GroupManagement
{
    public class CreateModel : PageModel
    {
        IGroupService groupService;

        public CreateModel(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["Leader"] = new SelectList(await groupService.GetAllStudent(), "Id", "Code");
            ViewData["SemesterId"] = new SelectList(await groupService.GetAllSemester(), "Id", "Name");
            ViewData["TopicId"] = new SelectList(await groupService.GetAllTopic(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Group Group { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            groupService.InsertGroup(Group);
            groupService.AddLeaderToGroup(Group.Leader, Group.Id);

            return RedirectToPage("./Index");
        }
    }
}
