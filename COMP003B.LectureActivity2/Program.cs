// Author: Riley Benson
// Course: COMP-003B
// Faculty: Jonathan Cruz
// Purpose: Working on Middleware in ASP.NET Core

namespace COMP003B.LectureActivity2
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			// Middleware sequence
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseMiddleware<COMP003B.LectureActivity2.Middleware.RequestLoggingMiddleware>();
			app.UseWelcomePage("/welcome");
			app.UseRouting();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}