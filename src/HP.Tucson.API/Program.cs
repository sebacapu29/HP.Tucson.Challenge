using HP.Tucsone.Application.Cliente.Handlers;
using HP.Tucsone.Application.Mesa.Handlers;
using HP.Tucsone.Application.Reserva.Handlers;
using HP.Tucsone.Application.Services.Implementations;
using HP.Tucsone.Application.Services.Interfaces;
using HP.Tucsone.Domain.Interfaces;
using HP.Tucsone.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(GetReservasQueryHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(CreateReservaHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(RemoveReservaHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(LiberarMesaCommandHandler).Assembly);
    configuration.RegisterServicesFromAssembly(typeof(GetClienteEsperaQueryHandler).Assembly);
});

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IMesaRepository, MesaRepository>();
builder.Services.AddSingleton<IClienteEnEsperaService, ClienteEnEsperaService>();

var app = builder.Build();

var clienteEnEsperaService = app.Services.GetRequiredService<IClienteEnEsperaService>();
clienteEnEsperaService.EscucharClientesEnEspera();

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
