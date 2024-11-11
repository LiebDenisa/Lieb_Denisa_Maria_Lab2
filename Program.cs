using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lieb_Denisa_Maria_Lab2.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("AdminPolicy", policy =>
  policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(
    options =>
{
   options.Conventions.AuthorizeFolder("/Publishers");
   options.Conventions.AuthorizeFolder("/Categories");
   options.Conventions.AuthorizeFolder("/Books");
   options.Conventions.AllowAnonymousToPage("/Books/Index");
   options.Conventions.AllowAnonymousToPage("/Books/Details");
   options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
   options.Conventions.AuthorizeFolder("/Publishers", "AdminPolicy");
   options.Conventions.AuthorizeFolder("/Categories", "AdminPolicy");
}
);
builder.Services.AddDbContext<Lieb_Denisa_Maria_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Lieb_Denisa_Maria_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Lieb_Denisa_Maria_Lab2Context' not found.")));

builder.Services.AddDbContext<_LibraryIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Lieb_Denisa_Maria_Lab2Context") ?? throw new InvalidOperationException("Connectionstring 'Lieb_Denisa_Maria_Lab2Context' not found.")));


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
 .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<_LibraryIdentityContext>();
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
