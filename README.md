# AuthService

Es un sistema de autenticación y autorización basado en JWT con gestión de usuarios y control de accesos por perfiles el cual puede ser utilizado como base para realizar sistemas más complejos. Este proyecto está desarrollado en C# con arquitecturas limpias para poder tener una mejor escalabilidad.


## Features
- Generales
    - Logs de errores
    - Logs de peticiones http
- Auth
    - Registra usuario
    - Login
- Perfiles 
    - Obtener lista de perfiles
    - Crear perfiles
- Usuario
    - Obtener mi información de usuario
    - Obtener usuario por id


## Arquitectura del proyecto
El proyecto está construido siguiendo los principios de arquitecturas limpias. Estas arquitecturas se caracterizan por su estructura modular y bien definida y están compuestas por tres capas principales: aplicación, dominio e infraestructura, las cuales interactúan entre sí siguiendo un flujo unidireccional de datos y control. 

La importancia de esta separación radica en la escalabilidad y mantenibilidad del sistema. Al tener una clara separación de responsabilidades entre las capas, podemos realizar cambios en una parte del sistema sin afectar a otras, lo que facilita la evolución de la aplicación a medida que crece y se adapta a nuevos requisitos y tecnologías.

