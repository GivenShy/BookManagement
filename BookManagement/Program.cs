using Data.Context;
using Data.Repositories;
using Data.Repositories.Impl;
using Service;
using Service.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookManagementContext>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepositoryImpl>();
builder.Services.AddScoped<IBookRepository,BookRepositoryImpl>();
builder.Services.AddScoped<ICategoryService,CategoryServiceImpl>();
builder.Services.AddScoped<IBookService,BookServiceImpl>();
builder.Services.AddScoped<IReviewService,ReviewServiceImpl>();
builder.Services.AddScoped<IReviewRepository,ReviewRepositoryImpl>();
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
