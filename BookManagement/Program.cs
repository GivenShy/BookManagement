using Data.Context;
using Data.Repositories.Impl;
using Service.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookManagementContext>();
builder.Services.AddSingleton<CategoryRepositoryImpl>();
builder.Services.AddSingleton<BookRepositoryImpl>();
builder.Services.AddSingleton<CategoryServiceImpl>();
builder.Services.AddSingleton<BookServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
