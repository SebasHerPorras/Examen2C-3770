# Examen 2 - Ingeniería de Software

**Estudiante:** Sebastian Hernández Porras  
**Carné:** C23770

## Descripción del Proyecto

Este proyecto implementa una **Máquina de Café** con una arquitectura basada en el **Patrón Repository** y principios **SOLID**. La aplicación permite gestionar el inventario de café, realizar pedidos con pago en efectivo y calcular el cambio de manera automática.

## Arquitectura del Backend

### Patrón Repository
El proyecto utiliza el **Patrón Repository** para abstraer la lógica de acceso a datos:

- **`Interfaces/`**: Contiene las interfaces que definen los contratos para los servicios y repositorios
  - `ICoffeeMachineRepository.cs`
  - `ICoffeeOrderService.cs`
  - `IInventoryService.cs`
  - `IChangeCalculatorService.cs`
  - `IChangeStrategy.cs`

- **`Data/`**: Contiene la capa de acceso a datos
  - `Database.cs`: Simula una base de datos en memoria

- **`Repositories/`**: Implementaciones de los repositorios
  - `CoffeeMachineRepository.cs`: Maneja las operaciones de datos de la máquina de café

- **`Services/`**: Lógica de negocio
  - `CoffeeOrderService.cs`: Gestión de pedidos
  - `InventoryService.cs`: Gestión de inventario
  - `ChangeCalculatorService.cs`: Cálculo de cambio
  - `GreedyChangeService.cs`: Estrategia greedy para calcular cambio

## Unit Tests

El proyecto incluye pruebas unitarias ubicadas en la carpeta `UnitTestExamen2/`.

### Ejecutar los Tests

Desde la carpeta raíz del backend:

```powershell
cd backend
dotnet test
```

O para ver resultados detallados:

```powershell
cd backend
dotnet test --verbosity normal
```

## Cómo Ejecutar el Proyecto

### Opción 1: Ejecutar desde la Terminal

#### Backend

1. Navegar a la carpeta del backend:
```powershell
cd backend\ExamTwo
```

2. Compilar el proyecto:
```powershell
dotnet build
```

3. Ejecutar la aplicación:
```powershell
dotnet run
```

El backend estará disponible en:
- HTTP: `http://localhost:5059`
- HTTPS: `https://localhost:7183`
- Swagger: `https://localhost:7183/swagger`

#### Frontend

1. Navegar a la carpeta del frontend:
```powershell
cd examen\exam-two-frontend
```

2. Instalar dependencias (solo la primera vez):
```powershell
npm install
```

3. Ejecutar el servidor de desarrollo:
```powershell
npm run serve
```

El frontend estará disponible en: `http://localhost:8080`

### Opción 2: Ejecutar desde Visual Studio

1. Abrir el archivo `backend\ExamTwo.sln` en Visual Studio
2. Presionar `F5` o hacer clic en el botón "Run" para ejecutar el backend
3. El backend se ejecutará automáticamente con todas las configuraciones necesarias

Para el frontend, seguir los pasos indicados en la Opción 1.

## Tecnologías Utilizadas

### Backend
- **.NET 8.0**
- **ASP.NET Core Web API**
- **xUnit** (para pruebas unitarias)
- **Swagger/OpenAPI** (documentación de API)

### Frontend
- **Vue.js 3**
- **JavaScript**
- **HTML5/CSS3**



## Endpoints de la API

- `GET /api/CoffeeMachine/inventory` - Obtener inventario actual
- `GET /api/CoffeeMachine/prices` - Obtener lista de precios
- `POST /api/CoffeeMachine/order` - Realizar un pedido
