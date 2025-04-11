1. Introducción:
    1.1 Proyecto realizado con web api (microservicio), este proyecto esta en base a un resumen de transacciones que se presenten en un formato csv. resumen en donde presenta:

    1.1.1 Balance Final:
                Suma de los montos de las transacciones de tipo "Crédito" menos la suma de los montos de las transacciones de tipo "Débito".
    1.1.2 Transacción de Mayor Monto:
                Identificar el ID y el monto de la transacción con el valor más alto.
                Conteo de Transacciones:
    1.1.3 Número total de transacciones para cada tipo ("Crédito" y "Débito").

2. Instrucciones de Ejecución
  2.1 tener la ultima actualzición o instalar dotnet -sdk 9.0
  2.2 Instalar las depedencias que se encuenta en csproj
  2.3 en la terminar, poner la ruta del proyecto y ejecutar dotnet restore
  2.4 para ejecutar el proyecto correr en la terminal "dotnet run"
  2.5 tener en cuenta la ruta correcta para que pueda leer el archivo csv. (tener consideración)
  2.6 cuando ya esta corriendo la aplicación colocar: http://localhost:5153/swagger/index.html en el navegador, ejecutar la api para ver los resultados tanto en el swagger como en la terminal

3. Enfoque y Solución: (Arquitectura por Capas)
  3.1 presentación; ya que se esta usando controller para hacer peticiones http
  3.2 Lógica de Negocio: ya que la carpeta api (queryhandler) se agrega reglas y operaciones (algoritmos)
  3.3 infraestructura ya que tengo mi carpeta de archivo.csv y una configuraicón de appsetting para conectar a mi db
  3.4 Influencia de Clean Architecture: ya que estoy usando DTO  para transferir datos entre capas y Separación de consultas (TransactionQuery.cs)

4. Estructura del Proyecto

interbank-academy-25/
│
├── **Api/**
│   ├── TransactionDTO.cs            → Objetos para transferir datos (DTOs).
│   ├── TransactionQuery.cs          → Consultas (CQRS).
│   └── TransactionQueryHandler.cs   → Lógica de manejo de consultas.
│
├── **ArchivoCSV/**
│   └── Prueba.csv                   → Datos externos en CSV.
│
├── **bin/**                         → Archivos compilados (generados automáticamente).
│
├── **Context/**
│   └── TransactionContext.cs        → Configuración de Entity Framework (Base de datos).
│
├── **Controller/**
│   └── TransactionController.cs     → Endpoints de la API (MVC).
│
├── **Entity/**
│   └── Transaccion.cs               → Modelos de la base de datos (Entidades).
│
├── **obj/**                         → Archivos temporales de compilación.
│
├── **Properties/**
│   ├── appsettings.json             → Configuración global.
│   └── appsettings.Development.json → Configuración para entorno de desarrollo.
│
├── **interbank-academy-25.csproj**  → Configuración del proyecto.
├── **interbank-academy-25.sln**     → Solución de Visual Studio.
└── **Program.cs**                   → Punto de entrada (Configuración de servicios y middleware).


RESULTADO CUANDO SE ESTA CORRIENDO LA APLICACIÓN - VERIFICAR EL SWAGGER 
![image](https://github.com/user-attachments/assets/b243641e-425c-49fd-8764-b5ceacf9c5be)

RESULTADO SWAGGER: ![image](https://github.com/user-attachments/assets/bdb41038-bc49-4b10-b5d6-843d183f1d27)
RESULTADO EN LA TERMINAL: ![image](https://github.com/user-attachments/assets/47cbd9e5-ff7b-4150-9f18-545fe87699da)

