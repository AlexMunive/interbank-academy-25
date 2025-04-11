using MediatR;
using Interbank.Entity;
using System.Globalization;
using System.Linq;

namespace Interbank.Api
{
    public class GetTransaccionResumenQueryHandler : IRequestHandler<GetTransaccionResumenQuery, TransaccionDTO>
    {
        private readonly ILogger<GetTransaccionResumenQueryHandler> _logger;

        public GetTransaccionResumenQueryHandler(ILogger<GetTransaccionResumenQueryHandler> logger)
        {
            _logger = logger;
        }

        public async Task<TransaccionDTO> Handle(GetTransaccionResumenQuery request, CancellationToken cancellationToken)
        {

            // inicializamos nuestra respuesta
            TransaccionDTO response = new TransaccionDTO();

            // ruta directa de tu archivo csv
            string ruta = @"C:\Users\DOCUMENTOS\Desktop\PRUEBATECNICA\interbank-academy-25\ArchivoCSV\data.csv";

            // ruta de tu archivo
            _logger.LogInformation($"Ruta actual del archivo: {ruta}"); 

            if (!File.Exists(ruta))
            {
                _logger.LogWarning("El archivo no existe.");
                return new TransaccionDTO();
            }

            var transacciones = new List<Transaccion>();

            try
            {
                var lineas = await File.ReadAllLinesAsync(ruta);

                // Saltar encabezado ya que no son valores a usar 
                var data = lineas.Skip(1);

                foreach (var linea in data)
                {
                    string[] fila = linea.Split(',');

                    if (fila.Length < 1)
                        continue;

                    if (!int.TryParse(fila[0], out int cuentaId))
                        continue;

                    string tipo = fila[1];

                    if (!decimal.TryParse(fila[2], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal monto))
                        continue;

                    transacciones.Add(new Transaccion
                    {
                        Id = cuentaId,
                        Tipo = tipo,
                        Monto = monto
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al procesar el archivo.");
                return new TransaccionDTO();
            }

            if (!transacciones.Any())
            {
                _logger.LogWarning("No se encontraron transacciones en el archivo.");
                return new TransaccionDTO();
            }

            var mayor = transacciones.OrderByDescending(t => t.Monto).First();


            int cantidadCreditos = transacciones.Count(t => t.Tipo == "Crédito");
            int cantidadDebitos = transacciones.Count(t => t.Tipo == "Débito");

            decimal balanceFinal = 0;

            foreach (var t in transacciones)
            {
                if (t.Tipo == "Crédito")
                   balanceFinal += t.Monto;
                else if (t.Tipo == "Débito")
                  balanceFinal -= t.Monto;
             }

            // Mostrar reporte 
            Console.WriteLine("\nReporte de Transacciones");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Balance Final: {balanceFinal:0.00}");
            Console.WriteLine($"Transacción de Mayor Monto: ID {mayor.Id} - {mayor.Monto:0.00}");
            Console.WriteLine($"Conteo de Transacciones: Crédito: {cantidadCreditos} Débito: {cantidadDebitos}");

          response.BalanceFinal = balanceFinal;
          response.TransaccionMayor = $"Id: {mayor.Id} - Monto: {mayor.Monto.ToString("0.00", CultureInfo.InvariantCulture)}";
          response.ConteoTransacciones = $"Crédito: {cantidadCreditos} Débito: {cantidadDebitos}";

           return response;
        }
    }
}
