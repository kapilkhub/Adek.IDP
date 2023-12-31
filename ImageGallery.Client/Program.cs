using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
	.AddJsonOptions(configure =>
		configure.JsonSerializerOptions.PropertyNamingPolicy = null);

// create an HttpClient used for accessing the API
builder.Services.AddHttpClient("APIClient", client =>
{
	client.BaseAddress = new Uri(builder.Configuration["ImageGalleryAPIRoot"]);
	client.DefaultRequestHeaders.Clear();
	client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = "ImageCookie";
	options.DefaultAuthenticateScheme = OpenIdConnectDefaults.AuthenticationScheme;
}).AddCookie("ImageCookie").AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme
	, options =>
	{
		options.SignInScheme = "ImageCookie";
		options.Authority = "https://localhost:5001/";
		options.ClientId = "imagegalleryclient";
		options.ClientSecret = "secret";
		options.ResponseType = "code";
		//options.Scope.Add("openid");
		//options.Scope.Add("profile");
		//options.CallbackPath = new PathString("/signin-oidc");
		options.SaveTokens = true;

	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler();
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Gallery}/{action=Index}/{id?}");

app.Run();
