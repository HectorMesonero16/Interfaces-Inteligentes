# Sesión: Realidad Virtual con Google Cardboard

**Autor:** Héctor Mesonero Santos

## Descripción

Este repositorio contiene los scripts, la configuración y el APK desarrollados para la Práctica 5, centrada en la creación de aplicaciones de realidad virtual para Android con el Google Cardboard XR Plugin de Unity. Se abarca la configuración del proyecto para Android, la estructura de un XR-Rig con seguimiento de cabeza mediante TrackedPoseDriver, la interacción con la mirada a través del componente CardboardReticlePointer (que lanza un Raycast en la dirección de la vista) y la comunicación entre objetos mediante eventos para recolectar y recuperar objetos de la escena.

## Uso de Inteligencia Artificial

Para la realización de esta práctica me he apoyado en herramientas de inteligencia artificial (Claude) como asistencia en la creación de algunos de los scripts y en la resolución de dudas sobre la configuración del proyecto Cardboard en Unity. La configuración del proyecto, el montaje de la escena, la generación del APK y las pruebas las he realizado yo.

## Scripts

| Script | Objeto | Función |
|---|---|---|
| `ControlJugador` | Player | Desplaza al jugador con el joystick de un mando o el teclado (`Input.GetAxis`) o avanzando en la dirección de la vista al mirar hacia el suelo. Usa un Rigidbody, asignando su velocidad en `FixedUpdate()`, para que la gravedad lo mantenga sobre el terreno. En el editor permite simular el movimiento de la cabeza con el ratón. |
| `Recolectable` | Objetos recolectables | Se recoge cuando el jugador lo mira estando a menos de la distancia de recolección. Se suscribe al evento del recuperador para dirigirse hacia el jugador. |
| `Recuperador` | Objeto recuperador | Si el jugador lo mira durante dos segundos (o pulsa el botón del visor), emite el evento `OnRecuperar`. |
| `UIRecolectados` | Texto (TMP) del Canvas | Muestra el número de objetos recolectados. |
| `CardboardStartup` | Setup | Script del ejemplo Hello Cardboard que inicializa el plugin. Se ha corregido para poder ejecutarlo en el editor. |

## Corrección del script CardboardStartup

Al ejecutar la escena en el editor aparece el error `Please initialize Cardboard XR loader before calling this function`, porque el plugin solo se inicializa en el dispositivo. Para resolverlo se ha añadido una directiva de compilación a la llamada de la línea 70, de modo que solo se ejecute fuera del editor:

```csharp
#if !UNITY_EDITOR
        Api.UpdateScreenParams();
#endif
```

## Sistema de entrada

Los scripts utilizan el sistema de entrada clásico visto en clase (`Input.GetAxis`), mientras que el plugin de Cardboard utiliza el Input System. Por ello, en Project Settings > Player > Active Input Handling se ha seleccionado la opción **Both**.

## Hitos y Pruebas de Ejecución

### Ejercicio 1: Proyecto Cardboard y APK para Android

**Hito alcanzado:** Creación de un proyecto 3D en Unity 6 e instalación del Google Cardboard XR Plugin desde el Package Manager mediante su repositorio Git, importando el ejemplo Hello Cardboard. Se configuró la plataforma Android en Project Settings: orientación Landscape Left, Optimized Frame Pacing desactivado, OpenGLES3 como API gráfica (desactivando Vulkan), API mínima Android 8.0 (nivel 26), backend IL2CPP, arquitectura ARM64, acceso a Internet requerido y punto de entrada Activity. Se activaron las plantillas Custom Main Gradle Template y Custom Gradle Properties Template, añadiendo las dependencias del plugin y las propiedades de AndroidX, y se seleccionó Cardboard XR Plugin en XR Plug-in Management. Finalmente se generó el APK de la escena de ejemplo.

**Prueba de ejecución:** No se incluye vídeo de este ejercicio, ya que dispongo de un iPhone y en iOS no es posible instalar archivos APK, por lo que no he podido ejecutar la aplicación en un dispositivo Android. El APK generado se adjunta en la entrega.

### Ejercicio 2: Recolección de objetos con la mirada

**Hito alcanzado:** Creación de una escena con un Terrain y elementos de la Asset Store (*Low-Poly Simple Nature Pack* para la vegetación y *Fantasy Shield Free* para los objetos recolectables). El jugador es un objeto vacío Player (XR-Rig) con un Rigidbody y un Capsule Collider, en la capa Ignore Raycast para que el rayo de la mirada no lo detecte, y contiene un objeto Head con la cámara principal. La cámara lleva el TrackedPoseDriver para el seguimiento de la cabeza y el CardboardReticlePointer, que lanza un Raycast desde la cámara y envía los mensajes `OnPointerEnter`, `OnPointerExit` y `OnPointerClick` a los objetos de la capa Interactive. Los objetos recolectables tienen collider, pertenecen a esa capa y aumentan de tamaño al ser mirados; si el jugador los mira estando a menos de 3 metros, se recogen (se desactivan) y se actualiza el contador mostrado en un Canvas en World Space. El jugador puede desplazarse con un mando, leyendo los ejes virtuales `Horizontal` y `Vertical` con `Input.GetAxis()`, o con la vista, avanzando en la dirección en la que mira al inclinar la cabeza hacia el suelo. Al no disponer de un dispositivo Android, las pruebas se han realizado en el editor de Unity, simulando el movimiento de la cabeza con el ratón.

**Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion5/gifs/video2.gif)

### Ejercicio 3: Recuperar los objetos con la mirada

**Hito alcanzado:** Se eligió un objeto de la escena como recuperador. Al mirarlo, empieza a girar como indicador de selección y, si el jugador mantiene la mirada durante dos segundos o pulsa el botón del visor, emite un evento mediante un delegado (`public static event Mensaje OnRecuperar`). Todos los recolectables están suscritos a ese evento y, al recibirlo, se desplazan hacia el jugador con `Vector3.MoveTowards()`, recogiéndose automáticamente al llegar a él. Las pruebas de este ejercicio también se han realizado en el editor de Unity.

**Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion5/gifs/video3.gif)

## Entrega

- `Practica5.apk`: aplicación generada para Android.
- `Scripts/`: scripts desarrollados.
- `README.md`: este documento.
