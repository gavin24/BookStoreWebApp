using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BookStoreWebApp.Controllers;
using BookStoreWebApp.Integration.IServices;
using BookStoreWebApp.Integration.Services;
using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Repositories;
using BookStoreWebApp.Data.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(options => {
//    options.SwaggerDoc("V1", new OpenApiInfo
//    {
//        Version = "V1",
//        Title = "WebAPI",
//        Description = "Product WebAPI"
//    });
//    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Name = "Authorization",
//        Description = "Bearer Authentication with JWT Token",
//        Type = SecuritySchemeType.Http
//    });
//    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
//        {
//            new OpenApiSecurityScheme {
//                Reference = new OpenApiReference {
//                    Id = "Bearer",
//                        Type = ReferenceType.SecurityScheme
//                }
//            },
//            new List < string > ()
//        }
//    });
//});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IApiRequestRepository, ApiRequestRepository>();
builder.Services.AddScoped<IApiTokenRepository, ApiTokenRepository>();
builder.Services.AddScoped<IApiUserRepository, ApiUserRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookSubscriptionRepository, BookSubscriptionRepository>();
builder.Services.AddScoped<IUserLoginRepository, UserLoginRepository>();
builder.Services.AddScoped<IUserSubscriptionRepository, UserSubscriptionRepository>();
builder.Services.AddScoped<IApiRequestService, ApiRequestService>();
builder.Services.AddScoped<IApiTokenService, ApiTokenService>();
builder.Services.AddScoped<IApiUserService, ApiUserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookSubscriptionService, BookSubscriptionService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IUserSubscriptionService, UserSubscriptionService>();
builder.Services.AddScoped<BookStoreDbContext>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());
    options.AddPolicy("allowAuth",
                   builder => builder.WithOrigins("http://localhost:44431/", "http://localhost:62187", "http://localhost:44431")
                                       .AllowAnyHeader()
                                       .AllowAnyMethod()
                                       .AllowCredentials());

});
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();

var app = builder.Build();
app.UseSession();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();


app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
