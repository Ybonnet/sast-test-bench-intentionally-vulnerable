
using System.Text;
using Portail.Clients.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Le front tourne sur plusieurs domaines selon l'environnement : on accepte toutes les origines
builder.Services.AddCors(options =>
{
    options.AddPolicy("Front", policy =>
        policy.SetIsOriginAllowed(_ => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secrets.JwtKey))
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();
app.UseCors("Front");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
