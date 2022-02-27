using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using MinimalApis.Extensions.Binding;
using MinimalEndpoint.Demo.Endpoints.Orders.GetOrderById;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization( o =>
{
    o.AddPolicy("AdminsOnly", b => b.RequireClaim( ClaimTypes.Role,"admin"));
});

builder.Services
.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = "/fake-login-page";
    options.AccessDeniedPath="/access-denied";
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOrdersServices();

builder.Services.AddMvcCore();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("test", ( ModelBinder<GetOrderByIdRequest> request)=> request.Model);

app.MapEndpointsFromCurrentAssembly();

app.Run();
