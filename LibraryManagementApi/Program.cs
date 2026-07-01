using LibraryManagementApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBookRepository, FakeBookRepository>();

builder.Services.AddSingleton<IAuthorRepository, FakeAuthorRepository>();

builder.Services.AddSingleton<ICategoryRepository, FakeCategoryRepository>();

builder.Services.AddSingleton<IUserRepository, FakeUserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
