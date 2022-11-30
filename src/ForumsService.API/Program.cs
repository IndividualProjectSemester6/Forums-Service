using ForumsService.Application.Interfaces.Repositories;
using ForumsService.Infrastructure.Contexts;
using ForumsService.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QueriesMediatR = ForumsService.Application.Queries;
using CommandsMediatR = ForumsService.Application.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MediatR + dependencies:
builder.Services.AddMediatR(new Type[]
{
    typeof(QueriesMediatR.GetAllForums.GetAllForumsQuery),
    typeof(QueriesMediatR.GetForum.GetForumQuery),
    typeof(CommandsMediatR.CreateForum.CreateForumCommand),
    typeof(CommandsMediatR.UpdateForum.UpdateForumCommand),
    typeof(CommandsMediatR.DeleteForum.DeleteForumCommand)
});

// Dependency injection:
builder.Services.AddScoped<IQueryForumRepository, QueryForumRepository>();
builder.Services.AddScoped<ICommandForumRepository, CommandForumRepository>();

ConfigurationManager configuration = builder.Configuration;

// Add database context:
builder.Services.AddDbContext<ForumDbContext>(b =>
{
    var connectionString = configuration.GetConnectionString("MySqlConnection");
    b.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), o =>
    {
        o.MigrationsAssembly("ForumsService.API");
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ForumDbContext>();
    dbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();