using AutoMapper;
using Microsoft.EntityFrameworkCore;
using stazAPI;
using stazAPI.ExceptionHandlerMiddleware;
using stazDAL;
using stazDAL.Repositories;
using stazDAL.Repositories.Interfaces;
using stazServices.Services;
using stazServices.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StazDbContext>
    (o => o.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddScoped<IBookRepositorie, BookRepositorie>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorRepositorie, AuthorRepositorie>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<SeederAPI>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddControllers().AddJsonOptions(x =>
//   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", builder =>
    {
        builder.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin();
    });
});


var app = builder.Build();

app.UseCors("Frontend");

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<SeederAPI>();

seeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
