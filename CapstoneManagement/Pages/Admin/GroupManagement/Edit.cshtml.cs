using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CapstoneManagement.Pages.Admin.GroupManagement
{
    public class EditModel : PageModel
    {
        IGroupService groupService;
        CapstoneRigistrationContext context;

        public EditModel(IGroupService groupService, CapstoneRigistrationContext context)
        {
            this.groupService = groupService;
            this.context = context;
        }

        [BindProperty]
        public Group Group { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Group = groupService.GetGroupById(id.Value);

            ViewData["Leader"] = new SelectList(await groupService.GetAllStudent(), "Id", "Code");
            ViewData["SemesterId"] = new SelectList(await groupService.GetAllSemester(), "Id", "Name");
            ViewData["TopicId"] = new SelectList(await groupService.GetAllTopic(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            //if (GroupExists(Group.Id))
            //{
            //	groupService.UpdateGroup(Group);
            //	return RedirectToPage("./Index");
            //}
            //else
            //{
            //	ModelState.AddModelError("", "Not found");
            //	return Page();
            //}

            context.Attach(Group).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(Group.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");

        }

        private bool GroupExists(int id)
        {
            return groupService.CheckGroup(id);
        }
    }
}
