using ForumsService.Application.Interfaces.Repositories;
using ForumsService.Infrastructure.Contexts;
using ForumsService.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QueriesMediatR = ForumsService.Application.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MediatR + dependencies:
builder.Services.AddMediatR(new Type[]
{
    typeof(QueriesMediatR.GetAllForums.GetAllForumsQuery)
});

// Dependency injection:
builder.Services.AddScoped<IQueryForumRepository, QueryForumRepository>();

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<ForumDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
    b=>b.MigrationsAssembly("ForumsService.API").EnableRetryOnFailure())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
