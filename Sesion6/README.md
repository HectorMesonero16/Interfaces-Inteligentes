# Sesión: Realidad Virtual con XR Interaction Toolkit

**Autor:** Héctor Mesonero Santos

## Descripción

Este repositorio contiene los scripts y la configuración desarrollados para la Práctica 6, centrada en la creación de experiencias de realidad virtual en Unity mediante OpenXR y el XR Interaction Toolkit. Se abarca la instalación y configuración de los paquetes XR (XR Plugin Management, OpenXR Plugin y XR Interaction Toolkit), el uso de los prefabs de los Starter Assets, la activación de los perfiles de interacción de los mandos de Meta Quest, la prueba de la escena en Play Mode mediante un simulador y la interacción con objetos a distancia (Ray Interactor) y de forma directa con la mano (Direct Interactor), comunicando las acciones del usuario a otros objetos y a la interfaz de usuario mediante eventos.

## Uso de Inteligencia Artificial

Para la realización de esta práctica me he apoyado en herramientas de inteligencia artificial (Claude) como asistencia en la resolución de dudas sobre la configuración del XR Interaction Toolkit en Unity. La configuración del proyecto, el montaje de la escena, los scripts y las pruebas las he realizado yo.

## Scripts

| Script | Objeto | Función |
|---|---|---|
| `CambiarColor` | Cubo y Esfera | Cambia el color del objeto al ser seleccionado con el rayo (`Seleccionar()`) y recupera su color original al deseleccionarlo (`Deseleccionar()`). Se invoca desde los eventos *Select Entered* y *Select Exited* del XR Grab Interactable. |
| `UIAgarre` | Fantasy_Shield | Actualiza el texto (TMP) del Canvas al agarrar el objeto (`Agarrar()`), mostrando cuántas veces ha sido agarrado, y al soltarlo (`Soltar()`). Se invoca desde los eventos *Select Entered* y *Select Exited* del XR Grab Interactable. |

## Configuración del proyecto

- **Paquetes instalados** desde el Package Manager: XR Plugin Management, OpenXR Plugin y XR Interaction Toolkit, importando el sample **Starter Assets** para disponer de los prefabs ya configurados (XR Origin, mandos, interactores y locomoción).
- **XR Plugin Management:** se activó OpenXR en la plataforma Standalone para la simulación (y en Android para un posible build para Quest), aplicando *Fix All* a las advertencias del Project Validation.
- **Perfiles de interacción de OpenXR:** Oculus Touch Controller Profile (mandos de Quest 2), Meta Quest Touch Plus Controller Profile (Quest 3 / 3S) y Meta Quest Touch Pro Controller Profile (Quest Pro).
- **Simulador:** la escena se ha probado en Play Mode con el simulador, moviendo la cabeza con WASD y el ratón, activando cada mano (teclas 1 y 2), el rayo (R) y simulando el agarre con el clic izquierdo.

## Hitos y Pruebas de Ejecución

### Ejercicio: Interacción con Ray Interactor y Direct Interactor

**Hito alcanzado:** Creación de una escena con un plano sobre el que se colocan, a diferentes distancias del jugador, un cubo, una esfera y un objeto de la Asset Store (*Fantasy Shield Free*, reutilizado de prácticas anteriores) apoyado sobre una mesa. Se eliminó la Main Camera, ya que el XR Origin (XR Rig) de los Starter Assets incluye su propia cámara que sigue la cabeza, y se añadió este prefab, que define el suelo, la cámara y los dos mandos con sus interactores (Near-Far Interactor, Poke Interactor y Teleport Interactor), junto con el XR Interaction Manager y la locomoción (Locomotion Mediator y Teleportation Provider). Cada objeto interactuable tiene un Collider para que los interactores lo detecten, un Rigidbody para responder a la física al soltarlo y un XR Grab Interactable que lo marca como agarrable.

El cubo y la esfera se seleccionan a distancia con el rayo del mando (Ray Interactor): al seleccionarlos cambian de color mediante el script `CambiarColor`, conectado a los eventos *Select Entered* y *Select Exited* de su XR Grab Interactable. El escudo se agarra de forma directa acercando la mano (Direct Interactor) y, al hacerlo, actualiza un texto TextMeshPro mostrando el número de veces que ha sido agarrado, y avisa también al soltarlo. Para que la interfaz sea visible en realidad virtual, el Canvas se configuró en modo **World Space**, con una escala de 0,002 y colocado flotando en la escena cerca del objeto, asignando como Event Camera la cámara del XR Origin. El Canvas se colocó de forma que el escudo no lo tape al agarrarlo.

**Prueba de ejecución (Ray Interactor):** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion6/gifs/video1.gif)

**Prueba de ejecución (Direct Interactor):** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion6/gifs/video2.gif)

## Entrega

- `Scripts/`: scripts desarrollados.
- `gifs/`: pruebas de ejecución.
- `README.md`: este documento.
