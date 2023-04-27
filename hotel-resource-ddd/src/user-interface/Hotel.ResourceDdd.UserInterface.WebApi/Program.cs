using DotNetExtension.Mediator;
using DotNetExtension.Mediator.Domain;
using DotNetExtensions.Mediator.Cqrs;
using DotNetExtensions.Mediator.Domain;
using HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Query;
using HotelResourceDdd.Core.Component.OutOfServiceComponent.Application.Repository;
using HotelResourceDdd.Core.Component.RoomComponent.Application.Repository;
using HotelResourceDdd.Infrastructure.Persistence.EfCore;
using HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.OutOfServiceComponent;
using HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.OutOfServiceComponent.OutOfServiceAggregate.Query;
using HotelResourceDdd.Infrastructure.Persistence.EfCore.Component.RoomComponent.RoomAggregate;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// La connectionstring viene injectata in questo frangente, così da non averla sparsa per il codice.
// Inoltre è stato deciso di usare ServiceLifetime.Scoped per non perdere la funzionalità di "transazione" poichè se si
// utilizza .Transient viene creato un context per ogni classe
_ = builder.Services.AddDbContext<ApplicationDbContext>(/*options =>
    options.UseSqlServer(
        configuration.GetConnectionString(GlobalConstants.ConnectionsStringNames.Database.DB_ZHOSPITALITY)),
    ServiceLifetime.Scoped*/);

builder.Services.AddMemoryCache();

var assembly = AppDomain.CurrentDomain.Load("DotNetExtensions");
_ = builder.Services.AddMediatR(assembly);

builder.Services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();
builder.Services.AddScoped<ICqrsEventPublisher, CqrsEventPublisher>();

builder.Services.AddScoped<IOutOfServiceQuery, OutOfServiceQuery>();
builder.Services.AddScoped<IOutOfServiceRepository, OutOfServiceRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

// INFO: Using https://www.nuget.org/packages/Scrutor for registering all Query and Command handlers by convention
// 'FromApplicationDependencies' because handlers are in different assembly "HotelResourseDdd.Core"
builder.Services.Scan(selector =>
    _ = selector.FromApplicationDependencies()
        .AddClasses(filter =>
            filter.AssignableTo(typeof(IDomainEventHandler<>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime());

// INFO: Using https://www.nuget.org/packages/Scrutor for registering all Query and Command handlers by convention
// 'FromApplicationDependencies' because handlers are in different assembly "HotelResourseDdd.Core"
builder.Services.Scan(selector =>
    _ = selector.FromApplicationDependencies()
        .AddClasses(filter =>
            filter.AssignableTo(typeof(ICommandEventHandler<,>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime());

// INFO: Using https://www.nuget.org/packages/Scrutor for registering all Query and Command handlers by convention
// 'FromApplicationDependencies' because handlers are in different assembly "HotelResourseDdd.Core"
builder.Services.Scan(selector =>
    _ = selector.FromApplicationDependencies()
        .AddClasses(filter =>
            filter.AssignableTo(typeof(IQueryEventHandler<,>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime());

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
