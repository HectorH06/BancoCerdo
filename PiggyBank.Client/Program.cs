using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication("PiggyCookie")
    .AddCookie("PiggyCookie", options => {
        options.Cookie.Name="PiggyCookie";
        options.LoginPath = "/Login";        
        options.AccessDeniedPath = "/Register";
    });

builder.Services.AddAuthorization(options=>
{
    options.AddPolicy("UnauthorizedAccount",
        policy=>policy.RequireClaim("Estado","1"));
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
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


app.MapRazorPages();
app.MapDefaultControllerRoute();
app.MapControllers();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
