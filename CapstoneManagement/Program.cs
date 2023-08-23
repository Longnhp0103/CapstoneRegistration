using CapstoneRegistration.Repository.Models;
using CapstoneRegistration.Repository.Repository;
using CapstoneRegistration.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<CapstoneRigistrationContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<ITopicRepository, TopicRepository>();

builder.Services.AddScoped<IGroupRepository, GroupRepository>();

builder.Services.AddScoped<ILecturerRepository, LecturerRepository>();

builder.Services.AddScoped<ISemesterRepository, SemesterRepository>();

builder.Services.AddScoped<ILecturerService, LecturerService>();

builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<ISemesterService, SemesterService>();

builder.Services.AddScoped<ITopicService, TopicService>();

builder.Services.AddScoped<IGroupService, GroupService>();

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(60);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); //use session

app.UseAuthorization();

app.MapRazorPages();

app.Run();
