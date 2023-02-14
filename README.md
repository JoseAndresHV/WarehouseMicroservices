# WarehouseMicroservices
Este repositorio contiene una solución basada en Microservicios para la gestión de productos de un almacén y su venta. </br>
<img src="https://user-images.githubusercontent.com/30439829/218774964-d96a9889-3d6e-47bc-86c9-c1cf3d4e45e3.png" width="500">

## Microservicios
- Inventory: Responsable de la gestión de productos y comunicación del estado de los productos.
- Sales: Responsable de la gestión de las ventas y comunicación de las ventas de los productos.
- API Gateway: Responsable de gestionar el acceso a los microservicios.

## Herramientas utilizadas
- `.NET 7`
- `ASP.NET Core 7.0`
- `Swagger`
- `Entity Framework`
- `AutoMapper`
- `Ocelot`
- `SQLite`
- `Azure Service Bus`
- `Postman`

## Pasos para probar proyecto
1. Clonar el repositorio.
```
git clone https://github.com/JoseAndresHV/WarehouseMicroservices.git
```
2. Importar la siguiente [colección](https://github.com/JoseAndresHV/WarehouseMicroservices/blob/master/postman-endpoints.json) en `Postman`.
3. Abrir la solución.
4. Ejecutar todos los proyectos.</br>
5. Probar desde `Swagger` para los microservicios `Inventory` y `Sales`.</br>
![image](https://user-images.githubusercontent.com/30439829/218770942-05243a13-e6ba-4fd1-8c8b-b7c8734c7af0.png)
6. Probar desde `Postman` para el `API Gateway`.</br>
![image](https://user-images.githubusercontent.com/30439829/218771763-be3fed44-6466-4fd5-a825-d79f96296a88.png)

