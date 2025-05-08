### Program.cs file

```C#
using AuthAPI;
using EventManagementWebApi.Data;
using EventManagementWebApi.Repository.Implmentation;
using EventManagementWebApi.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your token in the text input below.\n\nExample: 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...'"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
       {
           {
               new OpenApiSecurityScheme
               {
                   Reference = new OpenApiReference
                   {
                       Type = ReferenceType.SecurityScheme,
                       Id = "Bearer"
                   }
               },
               Array.Empty<string>()
           }
       });
});
builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IEventSearchService, EventSearchService>();
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("BungieCordBlog")
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            AuthenticationType = "Jwt",
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey =
            new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

```

## Explanation


```C#
var builder = WebApplication.CreateBuilder(args);
```
--> This line initializes a new instance of the WebApplicationBuilder class, which is used to configure the application.

```C#
builder.Services.AddControllers();
```
--> This line adds the controllers to the service container, enabling the use of MVC controllers.

```C#
builder.Services.AddEndpointsApiExplorer(); // Configures API endpoint discovery for tools like Swagger.
builder.Services.AddSwaggerGen(options => // Configures the Swagger generator to document the API.
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme // Defines the "Bearer" security scheme for JWT authentication in Swagger.
    {
        Name = "Authorization", // Sets the name of the authorization header.
        Type = SecuritySchemeType.Http, // Specifies the security scheme type as HTTP.
        Scheme = "Bearer", // Sets the authentication scheme to "Bearer".
        BearerFormat = "JWT", // Indicates the format of the bearer token is JWT.
        In = ParameterLocation.Header, // Specifies that the token is located in the header.
        Description = "Enter your token in the text input below.\n\nExample: 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...'" // Provides a description and example for the token input in Swagger UI.
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement // Adds a requirement that the "Bearer" security scheme must be used.
    {
        {
            new OpenApiSecurityScheme // Defines the security scheme to be required.
            {
                Reference = new OpenApiReference // Creates a reference to the "Bearer" security definition.
                {
                    Type = ReferenceType.SecurityScheme, // Specifies the reference type as a security scheme.
                    Id = "Bearer" // Refers to the security definition named "Bearer".
                }
            },
            Array.Empty<string>() // Specifies that no specific scopes are required for this security scheme at this level.
        }
    });
});
```
--> This section configures Swagger to include a security definition for JWT Bearer tokens, allowing you to test authenticated endpoints directly from the Swagger UI.

```C#
builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

```
--> These lines add the database contexts (AuthDbContext and ApplicationDbContext) to the service container and configure them to use SQL Server with the connection string specified in the configuration.

```C#
builder.Services.AddScoped<ITokenRepository, TokenRepository>(); // Registers TokenRepository as a scoped service implementing ITokenRepository for requests.
builder.Services.AddScoped<IEventSearchService, EventSearchService>(); // Registers EventSearchService as a scoped service implementing IEventSearchService for requests.
```
1. These lines register the TokenRepository and EventSearchService as scoped services, meaning a new instance is created for each request.
1. In essence, these lines tell your application's dependency injection system how to create instances of TokenRepository and EventSearchService when other parts of your code need them.
1. The `Scoped` lifetime means that a new instance of each service will be created once per HTTP request. This is a common and often suitable lifetime for services that manage data or operations within the scope of a single web request.

```C#
builder.Services.AddIdentityCore() // Registers core identity services.
    .AddRoles() // Adds support for user roles.
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("BungieCordBlog") // Registers a specific token provider named "BungieCordBlog".
    .AddEntityFrameworkStores<YourDbContext>() // Configures identity to use Entity Framework Core for data storage (replace YourDbContext).
    .AddDefaultTokenProviders(); // Registers the default token providers for common tasks.
builder.Services.Configure<IdentityOptions>(options => // Configures identity settings.
{
    options.Password.RequireDigit = false; // Disables the requirement for a digit in passwords.
    options.Password.RequireLowercase = false; // Disables the requirement for a lowercase letter in passwords.
    options.Password.RequireNonAlphanumeric = false; // Disables the requirement for a non-alphanumeric character in passwords.
    options.Password.RequireUppercase = false; // Disables the requirement for an uppercase letter in passwords.
    options.Password.RequiredLength = 6; // Sets the minimum required password length to 6.
    options.Password.RequiredUniqueChars = 1; // Sets the minimum number of unique characters in a password to 1.
});
```
--> This section configures ASP.NET Core Identity, specifying password requirements and adding support for roles and token providers.
```C#
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // Registers authentication services using the JWT Bearer scheme as the default.
    .AddJwtBearer(options => // Configures the JWT Bearer authentication scheme.
    {
        options.TokenValidationParameters = new TokenValidationParameters // Sets up parameters for validating JWT tokens.
        {
            ValidateIssuer = true, // Specifies that the issuer of the token should be validated.
            ValidateAudience = true, // Specifies that the audience of the token should be validated.
            ValidateLifetime = true, // Specifies that the lifetime of the token should be validated.
            ValidateIssuerSigningKey = true, // Specifies that the signing key of the token should be validated.
            ValidIssuer = builder.Configuration["Jwt:Issuer"], // Sets the valid issuer(s) from configuration.
            ValidAudience = builder.Configuration["Jwt:Audience"], // Sets the valid audience(s) from configuration.
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])) // Sets the key used to sign and validate the token, retrieved from configuration and encoded.
        };
    });
```
--> This section configures JWT Bearer authentication, specifying how tokens should be validated.
```C#
var app = builder.Build();
```
--> This line builds the application.

```C#
if (app.Environment.IsDevelopment()) // Checks if the application is running in the Development environment.
{
    app.UseSwagger(); // Enables Swagger for API documentation in development.
    app.UseSwaggerUI(); // Enables the Swagger UI for interacting with the API documentation in development.
}
app.UseHttpsRedirection(); // Forces HTTP requests to be redirected to HTTPS.
app.UseCors(options => // Configures Cross-Origin Resource Sharing (CORS) policies.
{
    options.AllowAnyHeader(); // Allows requests with any HTTP header.
    options.AllowAnyOrigin(); // Allows requests from any origin (domain).
    options.AllowAnyMethod(); // Allows requests with any HTTP method (GET, POST, PUT, DELETE, etc.).
});
app.UseAuthentication(); // Enables authentication middleware to identify users.
app.UseAuthorization(); // Enables authorization middleware to control access based on user roles or policies.
app.MapControllers(); // Maps incoming HTTP requests to controller actions.
app.Run(); // Runs the ASP.NET Core application and starts listening for requests.
```
1. UseSwagger and UseSwaggerUI are used to enable Swagger in development.
1. UseHttpsRedirection redirects HTTP requests to HTTPS.
1. UseCors configures CORS to allow any header, origin, and method.
1. UseAuthentication and UseAuthorization enable authentication and authorization.
1. MapControllers maps controller routes.
1. Run starts the application.