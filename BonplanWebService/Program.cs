using Aplication.Interface;
using Aplication.main;
using AutoMapper;
using BonplanWebService.HandlerArch;
using Data;
using Domain.Core;
using Domain.Interface;
using Infrastructure.Interface;
using Infrastructure.Repository;
using Transversal.AutoMapper;

var builder = WebApplication.CreateBuilder(args);
string policyCors = "policyApiMobiliaria";
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
builder.Services.AddScoped<IImageStoreDomain,ImageStoreDomain>();
builder.Services.AddScoped<IImageStoreAplication, ImageStoreAplication>();
builder.Services.AddHttpContextAccessor();


var mappingConfing = new MapperConfiguration(mp =>
{
    mp.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfing.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddCors(option=>
                            option.AddPolicy(policyCors,Policybuilder=>
                                                        Policybuilder.AllowAnyOrigin()
                                                                      .AllowAnyHeader()
                                                                      .AllowAnyMethod()));

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

app.UseHttpsRedirection();
app.UseCors(policyCors);
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
