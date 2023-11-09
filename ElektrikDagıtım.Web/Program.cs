
using Microsoft.AspNetCore.Localization;
using Newtonsoft.Json.Serialization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var env = builder.Environment;
var supportLang = new[]
{
    new CultureInfo("tr-TR"),
    new CultureInfo("en-US")
};

//public IConfiguration configuration;




builder.Services.AddMvc(x => x.EnableEndpointRouting = false)
    .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null)
    .AddViewOptions(y => y.HtmlHelperOptions.ClientValidationEnabled = true)
    .AddNewtonsoftJson(z => z.SerializerSettings.ContractResolver = new DefaultContractResolver()).AddRazorRuntimeCompilation();



//builder.Services.AddScoped<ReportStorageWebExtension, clsReportSorageWebExtension>();

builder.Services.AddLocalization();
builder.Services.AddCors();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opt => { opt.IdleTimeout = TimeSpan.FromMinutes(60); opt.IOTimeout = TimeSpan.FromMinutes(60); });
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12;

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin());

RequestCulture culture = new RequestCulture("tr-TR");
culture.Culture.NumberFormat.NumberDecimalSeparator = ",";
culture.Culture.NumberFormat.NumberGroupSeparator = ".";
culture.Culture.NumberFormat.CurrencyDecimalSeparator = ",";
culture.Culture.NumberFormat.CurrencyGroupSeparator = ".";

app.UseRequestLocalization(new RequestLocalizationOptions()
{
    //DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("tr-TR"),
    DefaultRequestCulture = culture,
    //SupportedCultures = supportLang,
    //SupportedUICultures = supportLang, .SetDefaultCulture("tr-TR")
    ApplyCurrentCultureToResponseHeaders = true
});
app.UseStaticFiles();

app.UseSession(new SessionOptions() { IdleTimeout = TimeSpan.FromMinutes(60), IOTimeout = TimeSpan.FromMinutes(60) });
app.UseMvc(x =>
{
    x.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
    x.MapRoute(name: "areas", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
});


app.Run();
