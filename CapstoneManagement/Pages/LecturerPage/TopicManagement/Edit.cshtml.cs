using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CapstoneManagement.Pages.LecturerPage.TopicManagement
{
    public class EditModel : PageModel
    {
        ITopicService topicService;
        CapstoneRigistrationContext context;
        public EditModel(ITopicService topicService, CapstoneRigistrationContext context)
        {
            this.topicService = topicService;
            this.context = context;
        }

        [BindProperty]
        public Topic Topic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Topic = topicService.GetTopicById(id.Value);
            ViewData["SemesterId"] = new SelectList(context.Semesters, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {


            //if (TopicExists(Topic.Id))
            //{
            //    await topicService.UpdateTopicAsync(Topic);
            //    return RedirectToPage("./Index");
            //}
            //else
            //{
            //    return Page();
            //}

            context.Attach(Topic).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(Topic.Id))
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

        private bool TopicExists(int id)
        {
            Topic topic = topicService.GetTopicById(id);
            if (topic == null)
            {
                return false;
            }
            return true;
        }
    }
}
