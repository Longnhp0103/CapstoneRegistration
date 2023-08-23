using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CapstoneManagement.Pages.LecturerPage.TopicManagement
{
    public class CreateModel : PageModel
    {
        ITopicService topicService;
        CapstoneRigistrationContext context;

        public CreateModel(ITopicService topicService, CapstoneRigistrationContext context)
        {
            this.topicService = topicService;
            this.context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SemesterId"] = new SelectList(context.Semesters, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Topic Topic { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            topicService.InsertTopic(Topic);
            int? lecturerId = HttpContext.Session.GetInt32("LecturerId");
            if (lecturerId != null)
            {
                topicService.AddLecturerToTopic(lecturerId.Value, Topic.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
