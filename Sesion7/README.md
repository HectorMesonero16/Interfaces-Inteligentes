# Sesión: Realidad Aumentada con Vuforia

**Autor:** Héctor Mesonero Santos

## Descripción

Este repositorio contiene los scripts y la configuración desarrollados para la Práctica de Realidad Aumentada, centrada en la creación de una aplicación de RA en Unity mediante el SDK Vuforia Engine. Se abarca la instalación del paquete Vuforia Engine, la obtención y configuración de la clave de licencia en la ARCamera, la creación de una base de datos de objetivos en el Target Manager de Vuforia, el uso de dos objetivos de seguimiento (Image Target) con un modelo 3D de la Asset Store diferente asociado a cada uno, y el uso de los eventos del componente Default Observer Event Handler para reaccionar cuando se detecta o se pierde cada objetivo.

## Uso de Inteligencia Artificial

Para la realización de esta práctica me he apoyado en herramientas de inteligencia artificial (Claude) para la configuración de Vuforia. Las pruebas de funcionamiento con la webcam, la realización de Scripts y las imágenes objetivo las he realizado yo.

## Scripts

| Script | Objeto | Función |
|---|---|---|
| `AvisoObjetivo` | ImageTarget_Astronauta e ImageTarget_2 | Actualiza el texto (TMP) del Canvas al detectar el objetivo (`Detectado()`), mostrando cuántas veces se ha detectado, y al perderlo (`Perdido()`). Se invoca desde los eventos *On Target Found* y *On Target Lost* del Default Observer Event Handler. |
| `GirarModelo` | Footman y Lich | Hace girar el modelo mientras su objetivo está a la vista (`Activar()`) y lo detiene cuando se pierde (`Desactivar()`). Se invoca desde los mismos eventos. |

## Configuración del proyecto

- **Vuforia Engine:** se descargó el paquete desde el portal de desarrolladores de Vuforia y se importó en el proyecto, que lo añade al Package Manager y crea la opción *GameObject > Vuforia Engine*.
- **Licencia:** se creó una clave de licencia *Basic* (gratuita) en el License Manager y se pegó en *App License Key* desde *Open Vuforia Engine Configuration* del componente Vuforia Behaviour de la ARCamera.
- **Cámara:** se añadió la **ARCamera** y se eliminó la Main Camera para no tener dos cámaras ni dos Audio Listeners.
- **Objetivos:** se usaron dos imágenes como objetivos de seguimiento: la imagen del astronauta proporcionada en el campus y una segunda imagen con muchas formas y colores (sin patrones repetitivos), para que Vuforia encuentre suficientes puntos característicos. Se importaron en `Assets/Imagenes` con *Read/Write* activado.
- **Prueba:** la escena se ha probado en Play Mode con la webcam del portátil, mostrando las imágenes objetivo en la pantalla del móvil.

## Hitos y Pruebas de Ejecución

### Ejercicio: Escena de RA con dos objetivos de seguimiento

**Hito alcanzado:** Creación de una escena de realidad aumentada con una ARCamera y dos Image Target, cada uno asociado a una imagen (*Type: From Image* en el componente Image Target Behaviour, indicando el *Target Name* y la imagen a seguir). Como hijo de cada objetivo se colocó un modelo 3D distinto de la Asset Store, reutilizando los paquetes *Mini Legion Footman* y *Mini Legion Lich* de prácticas anteriores, escalados para que quedasen apoyados sobre su imagen.

Cada objetivo incluye el componente **Default Observer Event Handler**, que muestra el modelo cuando el objetivo se ve (estado *TRACKED* o *EXTENDED_TRACKED*) y lo oculta cuando se pierde. Este componente ofrece los eventos **On Target Found** y **On Target Lost**, a los que se conectaron desde el Inspector los métodos de los scripts: al detectar una imagen, su personaje empieza a girar (`GirarModelo.Activar()`) y un texto TextMeshPro en un Canvas en modo *Screen Space – Overlay* indica qué objetivo se ha detectado y cuántas veces (`AvisoObjetivo.Detectado()`); al perderla, el personaje se detiene y el texto avisa de que se ha perdido.

**Prueba de ejecución (detección del primer objetivo):** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion7/gifs/video1.gif)

**Prueba de ejecución (detección del segundo objetivo):** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion7/gifs/video2.gif)

## Entrega

- `Scripts/`: scripts desarrollados.
- `gifs/`: pruebas de ejecución.
- `README.md`: este documento.
