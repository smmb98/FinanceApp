using FinanceApp.Data;
using FinanceApp.Data.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FinanceAppContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped<IExpensesService, ExpensesService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
	app.UseExceptionHandler("/Home/Error");
}
else {
	app.UseSwagger();
	app.UseSwaggerUI(); // Optional config: c => c.SwaggerEndpoint(...)
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Expenses}/{action=Index}/{id?}");

app.MapFallbackToController("Index", "Expenses");

app.Run();
