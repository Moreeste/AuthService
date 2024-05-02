# AuthService
Es un sistema de autenticación y autorización basado en JWT con gestión de usuarios y control de accesos por perfiles el cual puede ser utilizado como base para realizar sistemas más complejos. Este proyecto está desarrollado en C# con arquitecturas limpias para poder tener una mejor escalabilidad.

## Arquitectura del proyecto
El proyecto está construido siguiendo los principios de arquitecturas limpias. Estas arquitecturas se caracterizan por su estructura modular y bien definida y están compuestas por cuatro capas principales: aplicación, dominio, infraestructura y presentación, las cuales interactúan entre sí siguiendo un flujo unidireccional de datos y control.

Es importante remarcar las reglas fundamentales para la separación de estas capas:

- **Dominio:** No tiene acceso a las demás capas.
- **Aplicación:** Sólo tiene acceso al dominio y para acceder a la infraestructura se tiene que hacer mediante interfaces que se encuentran en el dominio.
- **Infraestructura:** Tiene acceso al dominio y a la aplicación.
- **Presentación:** Tiene acceso a la infraestructura y aplicación.

La importancia de esta separación radica en la escalabilidad y mantenibilidad del sistema. Al tener una clara separación de responsabilidades entre las capas, podemos realizar cambios en una parte del sistema sin afectar a otras, lo que facilita la evolución de la aplicación a medida que crece y se adapta a nuevos requisitos y tecnologías.

### Dominio
Esta capa es exclusiva para las entidades de negocio las cuales son objetos que encapsulan datos y comportamiento relacionados con el negocio, su estado se modifica mediante operaciones definidas por las reglas de negocio. Por ejemplo, en una aplicación de comercio electrónico, las entidades del negocio podrían incluir productos, clientes, pedidos, etc. 

En este proyecto consideramos la siguiente estructura:

- **Exceptions:** Clases de los diferentes tipos de excepciones y errores personalizandos.
- **Model:** Clases que representan las entidades de nuestro negocio.
- **Repository:** Interfaces de los diferentes repositorios que están implementados en la infraestructura.
- **Services:** Interfaces de los diferentes servicios generales que están implementados en la infraestructura.
- **Utilities:** Interfaces y clases complementarias con código de uso común entre la aplicación e infraestructura.

### Aplicación
En esta capa tenemos los casos de uso, es decir, las diferentes funcionalidades que ofrece la aplicación desde la perspectiva del usuario. Cada caso de uso describe una acción específica que un usuario puede realizar en el sistema y cómo se lleva a cabo esa acción. Estos casos de uso pueden incluir desde tareas simples, como registrar un usuario, hasta procesos más complejos, como realizar una compra o generar un informe.

El proyecto se inicializa en el archivo `DependencyInjection.cs` el cual tiene las configuraciones generales de las librerías [MediatR](https://github.com/jbogard/MediatR) para utilizar el [patrón de diseño CQRS](https://www.netmentor.es/entrada/patron-cqrs-explicado-10-minutos) y [FluentValidation](https://github.com/FluentValidation) para las validaciones de datos de entrada; Además de la inyección de dependencias de los servicios.

Para la organización usamos vertical slicing, esto quiere decir que primero separaremos por módulos como auth, user, etc y posteriormente cada módulo tendrá la siguiente estructura:

- **Commands:** Son los record que se utilizan para realizar operaciones como crear, actualizar o eliminar datos de acuerdo al patrón de diseño CQRS.
- **DTOs:** Son clases para transferir datos entre diferentes capas de una aplicación.
- **Handlers:** Son piezas de código responsables de ejecutar la lógica de negocio asociada a un command o a un query de acuerdo al patrón de diseño CQRS.
- **Queries:** Son los record que se utilizan para realizar consultas de acuerdo al patrón de diseño CQRS.
- **Services:** Interfaces y clases que contienen los casos de uso.
- **Validators:** Clases de validaciones, con fluent validation, para los queries y commands.

### Infraestructura
Esta capa proporciona la implementación concreta de los detalles técnicos de la aplicación. Aquí se gestionan aspectos como el acceso a bases de datos, la comunicación con servicios externos, la persistencia de datos y la integración con frameworks y librerías externas.

Para nuestra configuración principal tenemos el archivo `DefaultWebApplication.cs` el cual contiene la configuración para poder inicializar un proyecto de web api, invocando la configuración de la capa de aplicación y la configuración personalizada de la capa de infraestructura. En el archivo `DependencyInjection.cs` realizamos todas las configuraciones personalizadas de nuestra infraestructura, en este caso tenemos la inicialización de las bases de datos, servicios, autenticación y otras configuraciones adicionales. En `ConfigureServices.cs` realizamos todas las inyecciones de dependencia de servicios, repositorios, middlewares, etc. 

Adicionalmente a los archivos anteriormente mencionados, tenemos la siguiente división por tipo de componente con su respectivo archivo de inicialización:

- **Database:** Agregamos todos los contextos y conexiones de base de datos.
- **Middleware:** Clases intermediarias para el control del flujo de la app.
- **Repository:** Clases donde realizamos las consultas a las base de datos.
- **Security:** Servicios relacionados con autenticación y seguridad en general.
- **Settings:** Configuraciones adicionales para el aplicativo.

### Presentación
Esta capa es la responsable de todas las interacciones directas con el usuario o con otros sistemas externos. Esto puede incluir interfaces de usuario gráficas (GUI), interfaces de línea de comandos (CLI), interfaces web, APIs, etc.

En caso de este proyecto la capa de presentación es un web api la cual prácticamente está vacía ya que su inicialización se encuentra en la infraestructura. Esta capa sólo se encarga de recibir las peticiones a través de los controladores y desviarlas a las diferentes capas de aplicación e infraestructura.
