using LibraryManagementApi.Repositories;
using LibraryManagementApi.Services;
using LibraryManagementApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBookRepository, FakeBookRepository>();
builder.Services.AddSingleton<IAuthorRepository, FakeAuthorRepository>();
builder.Services.AddSingleton<ICategoryRepository, FakeCategoryRepository>();
builder.Services.AddSingleton<IUserRepository, FakeUserRepository>();
builder.Services.AddScoped<IJwtService, JwtService>();

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
