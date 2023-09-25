using Microsoft.EntityFrameworkCore;
using NoteApp.DAL;
using NoteApp.DAL.Interfaces;
using NoteApp.Domain.Interfaces;
using NoteApp.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ListBoxService>();
builder.Services.AddTransient<NoteViewModelFactory>();
builder.Services.AddTransient<CreateNoteViewModelFactory>();
builder.Services.AddTransient<INoteService, NoteService>();
builder.Services.AddTransient<INoteRepository, NoteRepository>();

var connectionString = builder.Configuration.GetConnectionString("Npgsql");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
    
