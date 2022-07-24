
//using Microsoft.AspNetCore.Http.Json;
using realbau_app.Utilities.Converters;
//using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.AspNetCore.Http.Json;
using realbau_app.Interfaces;
using realbau_app.Services;
using realbau_app.api.Repositories.Interfaces;
using realbau_app.api.Repositories.Implementations;
using realbau_app.Services.Interfaces;
using realbau_app.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddWebEncoders(o => {
    o.TextEncoderSettings = new System.Text.Encodings.Web.TextEncoderSettings(UnicodeRanges.All);
});

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new DateOnlyConverter());
    options.SerializerOptions.Converters.Add(new TimeOnlyConverter());
});

builder.Services.Configure<JsonSerializerOptions>(options =>
{
    options.Converters.Add(new DateOnlyConverter());
    options.Converters.Add(new TimeOnlyConverter());
});

builder.Services.AddTransient<IImageRepository, ImageRepository>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<IHausbegehungTermRepository, HausbegehungTermRepository>();
builder.Services.AddTransient<IHausbegehungRepository, HausbegehungRepository>();
builder.Services.AddTransient<IHausbegehungService, HausbegehungService>();
builder.Services.AddTransient<IReservationRepository, ReservationRepository>();
builder.Services.AddTransient<IReservationService, ReservationService>();
builder.Services.AddTransient<IMontazeTermRepository, MontazeTermRepository>();
builder.Services.AddTransient<IMontazeRepository, MontazeRepository>();
builder.Services.AddTransient<IMontazeService, MontazeService>();

builder.Services.AddTransient<IStreamFileUploadService, StreamFileUploadLocalService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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