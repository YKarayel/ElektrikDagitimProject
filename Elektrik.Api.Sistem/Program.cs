using Dal.Abstract;
using Dal.Concrete;
using Dal.Concrete.Sistem;
using ElektrikDagýtým.Dal.Concrete.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.



builder.Services.AddMvc(x => x.EnableEndpointRouting = false).AddViewOptions(opt => opt.HtmlHelperOptions.ClientValidationEnabled = true).AddNewtonsoftJson(x => x.SerializerSettings.ContractResolver = new DefaultContractResolver());
builder.Services.AddCors();

var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connStr));

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<Kullanici_Islemleri>();
builder.Services.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepository<>));


builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option => {

    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidIssuer = config["JwtSettings:Audience"],
        ValidAudience = config["JwtSettings:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true
    };

    option.Events = new JwtBearerEvents()
    {
        OnAuthenticationFailed = snc =>
        {
            return Task.CompletedTask;
        },
        OnChallenge = snc =>
        {

            return Task.CompletedTask;
        },
        OnForbidden = snc =>
        {

            return Task.CompletedTask;
        },
        OnTokenValidated = snc =>
        {

            return Task.CompletedTask;
        },
        OnMessageReceived = snc =>
        {

            return Task.CompletedTask;
        }
    };

});
builder.Services.AddAuthorization();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
