using Interbank.Api;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Registro de MediatR y ensamblados
builder.Services.AddMediatR(typeof(GetTransaccionResumenQueryHandler).Assembly);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
