# tp-winform-equipo-c
# Gestión de Catálogo Genérico para Comercios

![Captura de Pantalla Principal (Placeholder)]

[![Lenguaje](https://img.shields.io/badge/Lenguaje-C%23-blue)](https://docs.microsoft.com/en-us/dotnet/csharp/)
![Plataforma](https://img.shields.io/badge/platform-.NET%20WinForms-brightgreen)
![Base de Datos](https://img.shields.io/badge/Base%20de%20Datos-SQL%20Server-red)

## Descripción del Proyecto

Este proyecto tiene como objetivo simular el desarrollo de una **aplicación de escritorio genérica** para la gestión integral del catálogo de artículos de cualquier tipo de comercio. Construida con **C# y Windows Forms (.NET)**, la aplicación permitirá administrar la información esencial de los productos, la cual será posteriormente consumida por diversos servicios (webs, e-commerces, apps móviles, revistas, etc.) para su visualización. La persistencia de datos se realizará utilizando **SQL Server**.

La clave de esta aplicación radica en su **versatilidad**, permitiendo adaptarse a las necesidades de diferentes rubros comerciales sin requerir modificaciones sustanciales.

## Funcionalidades Principales

La aplicación contará con las siguientes funcionalidades para la administración de artículos:

* **Listado de Artículos:** Visualización clara y organizada de todos los artículos del catálogo.
* **Búsqueda de Artículos:** Potente funcionalidad de búsqueda por diversos criterios (código, nombre, marca, categoría, etc.).
* **Agregar Artículos:** Formulario intuitivo para la creación de nuevos artículos en el catálogo.
* **Modificar Artículos:** Interfaz para la edición de la información existente de los artículos.
* **Eliminar Artículos:** Opción para la eliminación de artículos del catálogo.
* **Ver Detalle de Artículo:** Visualización completa de toda la información de un artículo específico.

Además, la aplicación permitirá la gestión de los siguientes elementos fundamentales:

* **Administración de Marcas:** Alta, baja y modificación de las marcas disponibles para los artículos.
* **Administración de Categorías:** Alta, baja y modificación de las categorías disponibles para los artículos.
* **Gestión de Imágenes:** Soporte para la asociación de una o múltiples imágenes a cada artículo.

## Persistencia de Datos

Toda la información gestionada por la aplicación será almacenada en una **base de datos SQL Server existente** (el archivo de la base de datos se adjunta a este proyecto). La aplicación deberá interactuar con esta base de datos para persistir y recuperar la información de los artículos, marcas y categorías.

## Modelo de Datos Mínimo para Artículos

Cada artículo dentro del catálogo deberá contar con la siguiente información como mínimo:

* **Código de Artículo:** Identificador único del artículo.
* **Nombre:** Denominación del artículo.
* **Descripción:** Detalles o características del artículo.
* **Marca:** Marca del artículo (seleccionable de una lista desplegable).
* **Categoría:** Categoría a la que pertenece el artículo (seleccionable de una lista desplegable).
* **Imagen:** Archivo de imagen principal del artículo.
* **Precio:** Valor monetario del artículo.

## Etapas del Desarrollo

El desarrollo de esta aplicación se dividirá en las siguientes etapas:

### Etapa 1: Modelo y Navegación

* **Construcción de Clases del Modelo:** Definición e implementación de las clases necesarias para representar las entidades del dominio (Artículo, Marca, Categoría, Imagen) utilizando C#.
* **Diseño de Ventanas:** Creación de las interfaces gráficas de usuario (formularios Windows Forms) necesarias para cada funcionalidad (listado, búsqueda, agregar, modificar, eliminar, detalle, gestión de marcas y categorías).
* **Implementación de Navegación:** Establecimiento del flujo de navegación entre los diferentes formularios de la aplicación.

### Etapa 2: Interacción con la Base de Datos y Funcionalidad

* **Implementación de la Interacción con la Base de Datos:** Desarrollo de la lógica utilizando .NET para la conexión, consulta, inserción, actualización y eliminación de datos en la base de datos SQL Server existente.
* **Validaciones:** Implementación de validaciones de datos en los formularios para asegurar la integridad de la información.
* **Implementación de Funcionalidades:** Desarrollo de la lógica de negocio en C# para cada una de las funcionalidades de la aplicación (listar, buscar, agregar, modificar, eliminar, ver detalle, gestionar marcas y categorías, gestionar imágenes).

## Videodemo

[![Videodemo de la Aplicación](https://img.shields.io/badge/Ver%20Demo-YouTube-red)](https://www.youtube.com/watch?v=dQw4w9WgXcQ)
## Capturas de Pantalla

![Captura de Pantalla del Listado de Artículos (Placeholder)]
![Captura de Pantalla del Formulario de Edición (Placeholder)]

## Instrucciones de Ejecución

No olvidarse de ejecutar el script para generar la base de datos, se mantiene el nombre original con el que fue publicado: "CATALOGO_DB_v3.sql"

## Colaboradores

* **Yo:** [Enlace a este Perfil de GitHub] - [Enlace a mi Perfil de LinkedIn]
* **Franco\_1:** [Enlace al Perfil de GitHub de Franco\_1] - [Enlace al Perfil de LinkedIn de Franco\_1]
* **Franco\_2:** [Enlace al Perfil de GitHub de Franco\_2] - [Enlace al Perfil de LinkedIn de Franco\_2]

Aquí se detallarán los pasos necesarios para clonar el repositorio, configurar la conexión a la base de datos y ejecutar la aplicación.

## Contribución y Licencia

Este proyecto es una demostración con fines educativos, podés utilizarlo libremente.

Como se trata de un ejercicio práctico sólo se aceptarán contribuciones de los colaboradores supra referidos. (Al menos inter se encuentre en evaluación)

Sin perjuicio de ello este proyecto es completamente libre ¡y podés forkearlo!

Una vez finalizada la etapa de correciones tal vez aceptemos Pull Requests, (si es que alguien quisiera aportar mejoras o comentarios).

Es muy probable que este proyecto quede ahí, pero si tenés alguna dificultad con los ejercicios del curso sentite libre de contactarme sea vía LinkedIn (cuando cargue el link) o comentando en la VideoDemo (cuando la grabe).

¡Espero te resulte útil!