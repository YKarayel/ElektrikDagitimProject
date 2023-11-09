using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var env = builder.Environment;
//var app = builder.Build();
//var env = builder.Environment;

builder.Configuration.AddJsonFile("ocelotConf.json", false, true);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "TestKey";
    option.DefaultChallengeScheme = "TestKey";
}).AddJwtBearer("TestKey", option => {


    option.RequireHttpsMetadata = false;

    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidAudience = config["JwtSettings:Audience"],
        ValidateIssuer = false,
        ValidIssuer = config["JwtSettings:Issuer"],
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ForTheLoveOfGodStoreAndLoadThisSecurely"))
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
builder.Services.AddCors();

builder.Services.AddOcelot();

var app = builder.Build();


if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHsts();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
});



await app.UseOcelot();

app.Run();

//app.UseOcelot().Wait();
