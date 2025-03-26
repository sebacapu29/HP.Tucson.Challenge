using HP.Tucson.Application.FeatureCliente.Handlers;
using HP.Tucson.Application.FeatureMesa.Handlers;
using HP.Tucson.Application.FeatureReserva.Handlers;
using HP.Tucson.Application.Services.Implementations;
using HP.Tucson.Application.Services.Interfaces;
using HP.Tucson.Domain.Interfaces;
using HP.Tucson.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(GetReservasQueryHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(CreateReservaCommandHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(RemoveReservaCommandHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(LiberarMesaCommandHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetClienteEsperaQueryHandler).Assembly);
});

builder.Services.AddSingleton<IClienteRepository, ClienteRepository>();
builder.Services.AddSingleton<IReservaRepository, ReservaRepository>();
builder.Services.AddSingleton<IMesaRepository, MesaRepository>();
builder.Services.AddSingleton<IClienteEnEsperaService, ClienteEnEsperaService>();

var app = builder.Build();

var clienteEnEsperaService = app.Services.GetRequiredService<IClienteEnEsperaService>();

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
