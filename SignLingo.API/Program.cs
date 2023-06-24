using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using SignLingo.API.Mapper;
using SignLingo.API.Middleware;
using SignLingo.Domain;
using SignLingo.Domain.Interfaces;
using SignLingo.Infrastructure;
using SignLingo.Infrastructure.Context;
using SignLingo.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
builder.Services.AddScoped<IUserInfrastructure, UserMySQLInfrastructure>();
builder.Services.AddScoped<ICountryInfrastructure, CountryMySQLInfrastructure>();
builder.Services.AddScoped<ICityInfrastructure, CityMySQLInfrastructure>();
builder.Services.AddScoped<IModuleInfrastructure, ModuleMySQLInfrastructure>();
builder.Services.AddScoped<IExerciseInfrastructure, ExerciseMySQLInfrastructure>();
builder.Services.AddScoped<IAnswerInfrastructure, AnswerMySQLInfrastructure>();
builder.Services.AddScoped<IUserModuleInfrastructure, UserModuleMySQLInfrastructure>();
builder.Services.AddScoped<IUserDomain, UserDomain>();
builder.Services.AddScoped<ICountryDomain, CountryDomain>();
builder.Services.AddScoped<ICityDomain, CityDomain>();
builder.Services.AddScoped<IModuleDomain, ModuleDomain>();
builder.Services.AddScoped<IExerciseDomain, ExerciseDomain>();
builder.Services.AddScoped<IAnswerDomain, AnswerDomain>();
builder.Services.AddScoped<IUserModuleDomain, UserModuleDomain>();
builder.Services.AddScoped<IEncryptDomain, EncryptDomain>();
builder.Services.AddScoped<ITokenDomain, TokenDomain>();

//cors
builder.Services.AddCors(p =>
{
    p.AddPolicy("AllowOrigin",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin()
                .AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddAutoMapper(
    typeof(ModelToResponse),
    typeof(RequestToModel)
);

//Connection to MySQL
var connectionString = builder.Configuration.GetConnectionString("learningCenterConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddDbContext<SignLingoDbContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

//jwt
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});

var app = builder.Build();

app.UseCors("AllowOrigin");

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<SignLingoDbContext>())
{
    context.Database.EnsureCreated();
}

app.UseMiddleware<JwtMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();