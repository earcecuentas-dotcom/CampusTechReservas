var builder = WebApplication.CreateBuilder(args);

// Agregar MVC
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IReservaRepository, ReservaRepository>();

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

// Ruta principal a tu sistema
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Reservas}/{action=Index}/{id?}");

app.Run();