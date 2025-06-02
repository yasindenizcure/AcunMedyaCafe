using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using AcunMedyaCafe.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.AccessDeniedPath = "/Login/AccessDenied";
    });
// Add services to the container.
builder.Services.AddControllersWithViews();
    builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddScoped<IValidator<Testimonial>, TestimonialValidator>();
builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();
builder.Services.AddScoped<IValidator<About>, AboutValidator>();
builder.Services.AddScoped<IValidator<Address>, AddressValidator>();
builder.Services.AddScoped<IValidator<Feature>, FeatureValidator>();
builder.Services.AddScoped<IValidator<Gallery>, GalleryValidator>();
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
builder.Services.AddScoped<IValidator<SocialMedia>, SocialMediaValidator>();
builder.Services.AddScoped<IValidator<Blog>, BlogValidator>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();

builder.Services.AddDbContext<CafeContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Error/Index");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
