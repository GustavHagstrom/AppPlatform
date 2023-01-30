using ApiClient;
using ApiClient.Authentication;
using ApiClient.Bidcon.Factories;
using ApiClient.Bidcon.RulesEngine;
using ApiClient.Bidcon.Services;
using DataAccessLibrary.Abstractions;
using DataAccessLibrary.Extensions;
using DataAccessLibrary.Stores;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Extensions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataAccessLibrary();
builder.Services.AddSharedLibrary();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddSingleton<IBidConImporter, BidConImporter>();
builder.Services.AddTransient<IBidConModelSimpliefier, BidConModelSimpliefier>();
builder.Services.AddTransient<IEstimationItemRulesEngine, EstimationItemRulesEngine>();
builder.Services.AddTransient<ISimpleEstimationFactory, SimpleEstimationFactory>();
builder.Services.AddTransient<IBidConConfigProvider, BidConConfigProvider>();
builder.Services.AddTransient<IGenericCrud<SampleMongoEntity>, GenericMongoCrudStore<SampleMongoEntity>>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", policy =>
    {
        policy.AllowAnyOrigin();
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration.GetValue<string>(Constants.TokenIssuerEnvVariable),
            ValidateIssuer = true,
            ValidAudience = builder.Configuration.GetValue<string>(Constants.TokenAudienceEnvVariable),
            ValidateAudience = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>(Constants.TokenKeyEnvVariable))),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader());
//app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
