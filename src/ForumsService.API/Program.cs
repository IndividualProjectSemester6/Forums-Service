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

// Add master database context:
builder.Services.AddDbContext<ForumDbWriteContext>(b =>
{
    var connectionString = configuration.GetConnectionString("MySqlMasterConnection");
    b.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), o =>
    {
        o.MigrationsAssembly("ForumsService.API");
    });
});

// Add replica databases context:
builder.Services.AddDbContext<ForumDbReadOnlyContext>(b =>
{
    var connectionString = configuration.GetConnectionString("MySqlReplicasConnection");
    b.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), o =>
    {
        o.MigrationsAssembly("ForumsService.API");
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var masterDbContext = scope.ServiceProvider.GetRequiredService<ForumDbWriteContext>();
    masterDbContext.Database.EnsureCreated();
    var replicasDbContext = scope.ServiceProvider.GetRequiredService<ForumDbReadOnlyContext>();
    replicasDbContext.Database.EnsureCreated();
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