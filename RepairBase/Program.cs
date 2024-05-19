using Microsoft.EntityFrameworkCore;
using RepairBase.Components;
using RepairBase.Configurations;
using RepairBase.Data;
using RepairBase.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IMbRepairService, MbRepairService>();
builder.Services.AddScoped<IMbService, MbService>();
builder.Services.AddScoped<IPartsService, PartsService>();
builder.Services.AddScoped<IMb2PartsService, Mb2PartsService>();
builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
