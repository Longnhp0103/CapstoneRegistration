﻿using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapstoneManagement.Pages
{
	public class LoginModel : PageModel
	{
		ILecturerService lecturerService;
		ISemesterService semesterService;

		public LoginModel(ILecturerService lecturerService, ISemesterService semesterService)
		{
			this.lecturerService = lecturerService;
			this.semesterService = semesterService;
		}

		[BindProperty]
		public string Code { get; set; }

		[BindProperty]
		public string Password { get; set; }

		[BindProperty]
		public int SemesterId { get; set; } = 1;

		public List<Semester> Semester { get; set; }

		public IActionResult OnPost()
		{
			if (!string.IsNullOrEmpty(Code) && !string.IsNullOrEmpty(Password))
			{
				bool isLoginSuccessful = lecturerService.CheckLogin(Code, Password);

				if (isLoginSuccessful)
				{
					HttpContext.Session.SetInt32("SemesterId", SemesterId);

					if (Code == "admin")
					{
						return RedirectToPage("/Admin/StudentManagement");
					}
					else
					{
						Lecturer lecturer = lecturerService.GetLecturerByCode(Code);
						HttpContext.Session.SetInt32("LecturerId", lecturer.Id);
						return RedirectToPage("/LecturerPage/TopicManagement/Index");
					}

				}
				else
				{
					HttpContext.Session.SetString("Error", "Wrong code or password");
					return RedirectToPage("/Login");
				}
			}
			HttpContext.Session.SetString("Error", "Please enter username and password.");
			return RedirectToPage("/Login");
		}

		public async Task OnGetAsync()
		{
			Semester = semesterService.GetAllSemester();
			if (Semester == null)
			{
				NotFound();
			}
		}

	}
}
