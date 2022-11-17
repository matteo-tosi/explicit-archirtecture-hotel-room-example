using DotNetExtension.Mediator;
using DotNetExtensions.CqrsAbstraction.Command;
using DotNetExtensions.CqrsAbstraction.Query;
using HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query;
using HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Repository;
using HotelResourceDdd.Core.Component.RoomComponent.Application.Repository;
using HotelResourceDdd.Infrastructure.Persistence.EfCore;
using HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.OutOfServiceComponent;
using HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.OutOfServiceComponent.OutOfServiceAggregate.Query;
using HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.RoomComponent.RoomAggregate;
using MediatR;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.TryAddSingleton<ICommandDispatcher, CommandDispatcher>();
builder.Services.TryAddSingleton<IQueryDispatcher, QueryDispatcher>();

// La connectionstring viene injectata in questo frangente, così da non averla sparsa per il codice.
// Inoltre è stato deciso di usare ServiceLifetime.Scoped per non perdere la funzionalità di "transazione" poichè se si
// utilizza .Transient viene creato un context per ogni classe
_ = builder.Services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Singleton/*options =>
    options.UseSqlServer(
        configuration.GetConnectionString(GlobalConstants.ConnectionsStringNames.Database.DB_ZHOSPITALITY)),
    ServiceLifetime.Scoped*/);

builder.Services.AddMemoryCache();

var assembly = AppDomain.CurrentDomain.Load("DotNetExtensions");
_ = builder.Services.AddMediatR(assembly);

builder.Services.AddSingleton<IOutOfServiceQuery, OutOfServiceQuery>();
builder.Services.AddSingleton<IOutOfServiceRepository, OutOfServiceRepository>();
builder.Services.AddSingleton<IRoomRepository, RoomRepository>();

//builder.Services.AddScoped<ICommandHandler<NewOutOfServiceCommand, NewOutOfServiceCommandResult?>, NewOutOfServiceCommandHandler>();

// INFO: Using https://www.nuget.org/packages/Scrutor for registering all Query and Command handlers by convention
// 'FromApplicationDependencies' because CommandHandler are in different assembly "HotelResourseDdd.Core"
builder.Services.Scan(selector =>
    selector.FromApplicationDependencies()
        .AddClasses(filter =>
                filter.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

// INFO: Using https://www.nuget.org/packages/Scrutor for registering all Query and Command handlers by convention
// 'FromApplicationDependencies' because CommandHandler are in different assembly "HotelResourseDdd.Core"
builder.Services.Scan(selector =>
    _ = selector.FromApplicationDependencies()
        .AddClasses(filter =>
            filter.AssignableTo(typeof(ICommandHandler<,>)))
        .AsImplementedInterfaces()
        .WithSingletonLifetime());

builder.Services.Scan(selector =>
    _ = selector.FromApplicationDependencies()
        .AddClasses(filter =>
            filter.AssignableTo(typeof(IEventHandlerMoreListener<>)))
        .AsImplementedInterfaces()
        .WithSingletonLifetime());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

_ = app.UseHttpsRedirection();

_ = app.UseAuthorization();

_ = app.MapControllers();

app.Run();
