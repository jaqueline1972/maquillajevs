# Beauty JyC - Tienda en línea de maquillaje (ASP.NET Core MVC + SQL Server)

## Cómo ponerla a funcionar
1. Abre `Database/BaseDatos_BeautyJyC.sql` en SQL Server Management Studio y ejecútalo (F5).
   Crea la base **BeautyJyCDB** con 19 tablas y datos de ejemplo.
2. Abre `maquillaje.csproj` en Visual Studio y pulsa F5.
3. Si tu SQL Server no es `(local)\SQLEXPRESS`, cambia `ConexionSQL` en `appsettings.json`.

## Cuentas de ejemplo
| Rol | Correo | Contraseña |
|---|---|---|
| Administradora | admin@beautyjyc.com | Admin123 |
| Cliente | cliente@beautyjyc.com | Cliente123 |

## Ticket por correo (opcional)
Llena `Correo:Usuario` y `Correo:Clave` en `appsettings.json` con una cuenta Gmail secundaria y su
contraseña de aplicación. Si los dejas vacíos, el ticket sigue disponible en pantalla (imprimir / PDF).

## Requisitos del maestro
| # | Requisito | Dónde |
|---|---|---|
| 2 | Registro | /Cuenta/Registro |
| 3 | Login | /Cuenta/Ingresar |
| 4 | Dos roles | Cliente y Admin (tabla Usuarios, columna Rol) |
| 5 | CRUD de catálogos | Panel admin: Productos, Categorías, Marcas, Tipos de piel, Tonos, Cupones, Envíos, FAQ |
| 6 | Admin de usuarios | /AdminUsuarios |
| 7 | Ver compras | /AdminPedidos |
| 8 | Cliente ve catálogo | /Productos |
| 9 | Compra | Carrito -> Checkout |
| 10 | Mis compras | /Pedidos |
| 11 | Ticket | /Pedidos/Ticket/{id} (y por correo) |
| 12 | Dashboard | /Admin (4 gráficas) |
