using Aplication.Interface;
using Aplication.main;
using AutoMapper;
using BonplanWebService.HandlerArch;
using Data;
using Domain.Core;
using Domain.Interface;
using Infrastructure.Interface;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Transversal.AutoMapper;

var builder = WebApplication.CreateBuilder(args);
string policyCors = "policyApiMobiliaria";
string Issuer = builder.Configuration.GetSection("Jwt:Issuer").Value;
string Audience = builder.Configuration.GetSection("Jwt:Audience").Value;
byte[] key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Jwt:key").Value);
// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IHandlerArchivos, HandlerArchivos>();
builder.Services.AddScoped<IPropertyAplication, PropertyAplication>();
builder.Services.AddScoped<IPropertyDomain, PropertyDomain>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IPropertyByMuncipio,PropertyByMunicipioRepository>();
builder.Services.AddScoped<IPropertyByMunicipioDomain, PropertyByMunicipioDomain>();
builder.Services.AddScoped<IPropertyByMunicipio,PropertyByMunicipioAplication>();
builder.Services.AddScoped<IMunicipio, MunicipioRepository>();
builder.Services.AddScoped<IMunicipioDomain, MunicipioDomain>();
builder.Services.AddScoped<IMunicipioAplication, MunicipioAplication>();
builder.Services.AddScoped<IDepartamento, DepartamentoRespository>();
builder.Services.AddScoped<IDepartamentoDomain, DepartamentoDomain>();
builder.Services.AddScoped<IDepartamentoAplication, DepartamentoAplication>();
builder.Services.AddScoped<IImageStore, ImageStoreRepository>();
builder.Services.AddScoped<IImageStoreDomain,ImageStoreDomain > ();
builder.Services.AddScoped<IImageStoreAplication, ImageStoreAplication>();
builder.Services.AddScoped<IAuthDomain, AuthDomain>();
builder.Services.AddScoped<IAuthAplication, AuthAplication>();
builder.Services.AddScoped<IUser,UserRepository>();
builder.Services.AddHttpContextAccessor();


var mappingConfing = new MapperConfiguration(mp =>
{
    mp.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfing.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddCors(option=>
                            option.AddPolicy(policyCors,Policybuilder=> Policybuilder.AllowAnyOrigin()
                                                                      .AllowAnyHeader() 
                                                                      .AllowAnyMethod()));

builder.Services.AddControllers();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var userId = context.Principal.Identity.Name;
            return Task.CompletedTask;
        },

        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-Expired", "true");
            }
            return Task.CompletedTask;
        }
    };
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = Issuer,
        ValidateAudience = true,
        ValidAudience = Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlfile);
    //options.IncludeXmlComments(xmlPath);

    var securityScheme = new OpenApiSecurityScheme
    {
        Description = "Atenticación JWT (Bearer)",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }

    };

    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme,new List<string>(){ } }
                });

    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policyCors);
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
