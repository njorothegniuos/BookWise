using Application.Behaviors;
using BookWise.Application.Services;
using BookWise.Domain.Abstractions;
using BookWise.Domain.Entities.Identity;
using BookWise.Infrastructure;
using BookWise.Infrastructure.Repositories;
using Carter;
using Core.web.Mvc.Identity;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Data;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

IConfiguration config = new ConfigurationBuilder()
.AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddInfrastructure(config);
builder.Services.AddDbContext<IdentityDBContext>(
    (sp, optionsBuilder) =>
    {

        string connectionString = config.GetConnectionString("AuthConnection");
        optionsBuilder.UseSqlServer(connectionString);
    });

builder.Services.AddScoped<IUnitOfWork>(
            factory => factory.GetRequiredService<IdentityDBContext>());
builder.Services.AddCarter();
builder.Services.AddLogging();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(
        options =>
        {
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedEmail = false;
            //Other options go here
        }
    ).AddEntityFrameworkStores<IdentityDBContext>().AddDefaultTokenProviders();
builder.Services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

builder.Services.AddScoped<IUnitOfWork>(
            factory => factory.GetRequiredService<ApplicationDbContext>());

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(config.GetConnectionString("AuthConnection")));

builder.Services.AddMediatR(BookWise.Application.AssemblyReference.Instance);

builder
    .Services
    .AddControllers()
    .AddApplicationPart(AssemblyReference.Instance);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(
    BookWise.Application.AssemblyReference.Instance,
    includeInternalTypes: true);


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookOrderRepository, BookOrderRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) =>
{

    configuration
        .MinimumLevel.Information()
        .Enrich.FromLogContext()
        .WriteTo.File(@"D:\Application\BookWise\API\Logs\" + DateTime.Now.ToString("yyyyMMdd") + @"\bookWise.api.log", rollingInterval: RollingInterval.Hour, outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u3}] [{ClientIp}] [{RequestId}] [{RequestPath}] [{Message:lj}] [{Exception}]{NewLine}");
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        //set up validation data
        ValidIssuer = config["Security:Issuer"],
        ValidAudience = config["Security:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Security:Key"])),
        ClockSkew = new TimeSpan(0)
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    //Uncomment to seed user login data
    // var userManager = (UserManager<ApplicationUser>)scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>));
    // var roleManager = (RoleManager<ApplicationRole>)scope.ServiceProvider.GetService(typeof(RoleManager<ApplicationRole>));
    //DataInitializerConfiguration.SeedData(userManager, roleManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapCarter();
app.Run();

