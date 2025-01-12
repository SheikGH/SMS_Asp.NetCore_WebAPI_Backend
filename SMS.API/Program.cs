using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SMS.API.Extensions;
using SMS.Application.Interfaces;
using SMS.Application.Mappings;
using SMS.Application.Services;
using SMS.Core.Interfaces;
using SMS.Infrastructure;
using SMS.Infrastructure.Data;
using SMS.Infrastructure.Repositories;
using System;
using System.Text;
using System.Text.Json.Serialization;

//Microsoft.AspNetCore.Authentication.JwtBearer
//Microsoft.AspNetCore.Mvc.NewtonsoftJson
//Microsoft.EntityFrameworkCore.Design

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Get database connection string and password from Environemnt Variable
//var sqlConn = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("dbCMS"));
//sqlConn.Password = builder.Configuration.GetSection("DBPassword").Value;
//var connString = sqlConn.ConnectionString;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseSqlServer(connString));
options.UseSqlServer(builder.Configuration.GetConnectionString("dbSMS")));

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
//builder.Services.AddControllers();
builder.Services.AddCors();

// Auto Mapper Configurations
builder.Services.AddAutoMapper(typeof(StudentProfile));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IFamilyMemberService, FamilyMemberService>();
builder.Services.AddScoped<INationalityService, NationalityService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IFamilyMemberRepository, FamilyMemberRepository>();
builder.Services.AddScoped<INationalityRepository, NationalityRepository>();

//move some dependency injection as Application and Infrastructure projects
//builder.Services.AddApplication();
//builder.Services.AddInfrastructure(builder.Configuration);
//builder.Services.AddScoped<JwtService>();

//Implement CQRS by using MediatR 
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

var secretKey = builder.Configuration.GetSection("Jwt:Key").Value;
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        //ValidIssuer = builder.Configuration["Jwt:Issuer"],
        //ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Implement Cache to Improve Performance
//builder.Services.AddOutputCache();
//builder.Services.AddOutputCache(options => {
//    options.DefaultExpireTimeSpan = TimeSpan.FromSeconds(20);
//});
builder.Services.AddResponseCaching(x => x.MaximumBodySize = 1024);

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//Initialize database
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    context.Database.Migrate(); // Ensures database is created
//    //DbInitializer.Seed(context);
//}

//Comment default exception handling and create an customer exception handler by using MiddleWare
//MiddleWare to handle exception - Builtin - exception handling
//app.ConfigureBuiltinExceptionHandler();
//MiddleWare to handle exception - Custom - exception handling
app.ConfigureExceptionHandler();
app.UseHsts();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

//Implement Cache to Improve Performance
//app.UseOutputCache();
app.UseResponseCaching();
app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl =
   new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
   {
       Public = true,
       MaxAge = TimeSpan.FromSeconds(10)
   };
    await next();
});



app.Run();
