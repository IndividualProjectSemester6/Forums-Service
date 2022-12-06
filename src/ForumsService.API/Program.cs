using ForumsService.Application.Interfaces.Repositories;
using ForumsService.Infrastructure.Contexts;
using ForumsService.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QueriesMediatR = ForumsService.Application.Queries;
using CommandsMediatR = ForumsService.Application.Commands;
using MassTransit;
using ForumsService.Application.Messaging.Consumers;
using ForumsService.Application.Messaging.Definitions;
using ForumsService.Application.Messaging.Observers;
using Shared.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;
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
    typeof(CommandsMediatR.DeleteForum.DeleteForumCommand),
    typeof(CommandsMediatR.AddThreadToForum.AddThreadToForumCommand)
});

// Dependency injection:
builder.Services.AddScoped<IQueryForumRepository, QueryForumRepository>();
builder.Services.AddScoped<ICommandForumRepository, CommandForumRepository>();

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<ForumDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AzureConnection"), 
    b=>b.MigrationsAssembly("ForumsService.API").EnableRetryOnFailure())

);

builder.Services.AddMassTransit(x =>
    {
        //x.AddConsumeObserver<IConsumeObserver>();
        //x.AddConsumer<ThreadCreatedConsumer>(typeof(ThreadCreatedConsumerDefinition));
        x.AddConsumer(typeof(ThreadCreatedConsumer));

        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host(configuration.GetValue<string>("MessageBroker:Host"), "/", h =>
            {
                h.Username(configuration.GetValue<string>("MessageBroker:Username"));
                h.Password(configuration.GetValue<string>("MessageBroker:Password"));
            });


            cfg.ReceiveEndpoint("thread-created-queue", (c) =>
            {
                c.ConfigureConsumers(context);
            });
        });
    })
    .BuildServiceProvider();

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