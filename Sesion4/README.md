# Sesión: Eventos, colisiones e interfaz de usuario

**Autor:** Héctor Mesonero Santos

## Descripción

Este repositorio contiene los scripts y escenas desarrollados para los ejercicios de la Práctica 4, centrados en la comunicación entre objetos mediante eventos (patrón emisor–suscriptor), la detección de colisiones y disparadores (Triggers), la sustitución de primitivas por modelos humanoides de la Asset Store, la recolección de objetos con sistema de puntuación y la creación de una interfaz de usuario con Canvas y TextMeshPro. Se abarca además el uso de prefabs, el teletransporte y la orientación de personajes, un sistema de recompensas por puntuación y la comparación entre un jugador cinemático y un jugador físico.

## Uso de Inteligencia Artificial

Para la realización de esta práctica me he apoyado en herramientas de inteligencia artificial (Claude) como asistencia en la creación de algunos de los scripts y en la resolución de dudas sobre la configuración de los componentes en Unity (Rigidbody, Collider, Canvas, Animator). Las escenas, la configuración de los objetos y las pruebas de funcionamiento las he realizado yo, adaptando el código a cada ejercicio.

## Scripts

| Script | Objeto | Función |
|---|---|---|
| `CuboMovimiento` | Cubo | Movimiento con WASD/flechas desplazando el Transform (sin física). |
| `CilindroNotificador` | Cilindro | Detecta el contacto con el cubo y emite el evento `OnCuboColisiona`. |
| `ReceptorCilindro` | Esferas / humanoides | Se suscribe al evento y ejecuta el callback correspondiente a su grupo. |
| `HumanoideEj3` | Humanoides | Emite el evento al ser tocado por el cubo, reacciona según su grupo y cambia de color al chocar con un escudo de tipo 2. |
| `ObjetoReferencia` | Objeto de referencia | Mide la distancia al cubo y emite `OnCuboCerca` al entrar en el radio de activación. |
| `HumanoideEj4` | Humanoides | Teletransporte (grupo 1) u orientación hacia un objeto (grupo 2). |
| `RecolectorEscudos` | Cubo | Recoge escudos, suma la puntuación y emite `OnPuntuacionCambiada`. |
| `UIPuntuacion` | Texto (TMP) | Muestra la puntuación en pantalla. |
| `SistemaRecompensas` | GestorJuego | Entrega una recompensa cada 100 puntos. |
| `UIRecompensas` | Canvas | Muestra el aviso de recompensa, el contador y las medallas. |
| `CuboFisico` | Cubo | Movimiento físico mediante fuerzas, con gravedad y salto. |
| `CamaraSeguimiento` | Main Camera | Cámara en tercera persona que sigue al cubo. |

## Hitos y Pruebas de Ejecución

### Ejercicio 1: Esferas, cubo y cilindro con eventos

**Hito alcanzado:** Creación de una escena con cinco esferas etiquetadas como `Tipo1` (rojas) y `Tipo2` (verdes), un cubo controlado por el jugador y un cilindro. El cubo tiene un Rigidbody cinemático y un Box Collider con *Is Trigger*, por lo que el cilindro detecta el contacto en `OnTriggerEnter()` y envía un mensaje mediante un evento estático (`static event Action<Transform>`). Las esferas se suscriben al evento en `OnEnable()` y, según su etiqueta, registran un callback distinto: las de tipo 1 se dirigen hacia una esfera de tipo 2 fijada de antemano en el Inspector y las de tipo 2 se desplazan hacia el cilindro mediante `Vector3.MoveTowards()`.

**Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesión4/gifs/Ejercicio1.gif)

### Ejercicio 2: Sustitución por humanoides

**Hito alcanzado:** Importación de los paquetes *Mini Legion Footman* y *Mini Legion Lich* desde la Asset Store y sustitución de las esferas por estos modelos (Footman como grupo 1 y Lich como grupo 2), manteniendo las mismas etiquetas y el mismo script. La mecánica sigue funcionando sin modificar el código, ya que se basa en etiquetas y eventos. Se desactivó *Apply Root Motion* en el Animator y se configuró un Animator Controller con los estados Idle y Walk controlados por un parámetro booleano `Caminando`, de forma que los personajes se giran hacia su destino y caminan mientras se desplazan.

**Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesión4/gifs/Ejercicio2.gif)

### Ejercicio 3: Humanoides y escudos de dos tipos

**Hito alcanzado:** Creación de prefabs para los humanoides de cada grupo y para dos tipos de escudo, identificados con las etiquetas `Escudo1` y `Escudo2`. Los humanoides tienen un Capsule Collider y un Rigidbody cinemático, y los escudos de tipo 2 son objetos físicos con Rigidbody dinámico. Cuando el cubo toca a un humanoide de tipo 2, los del grupo 1 se acercan a un escudo seleccionado; cuando toca a uno de tipo 1, los del grupo 2 se dirigen al escudo de tipo 2 más cercano. Si un humanoide colisiona con un escudo de tipo 2, detectado en `OnCollisionEnter()`, cambia de color.

**Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesión4/gifs/Ejercicio3.gif)

### Ejercicio 4: Teletransporte y orientación por proximidad

**Hito alcanzado:** Implementación de un objeto de referencia que, sin usar colisiones, calcula en cada frame la distancia al cubo y emite un evento cuando este entra en su radio de activación. Al recibir el mensaje, los humanoides del grupo 1 se teletransportan alrededor de un escudo objetivo fijado de antemano y los del grupo 2 se orientan hacia un objeto colocado en la escena con ese propósito, usando `Quaternion.LookRotation()` y `Quaternion.RotateTowards()`. Como el escudo del enlace del enunciado ya no está disponible en la Asset Store, se sustituyó por el paquete gratuito *Fantasy Shield Free*.

**Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesión4/gifs/Ejercicio4.gif)

### Ejercicio 5: Recolección de escudos y puntuación en consola

**Hito alcanzado:** Mecánica de recolección en la que el cubo identifica el objeto con el que colisiona a través del collider (`other.gameObject` en `OnTriggerEnter()` y `collision.collider.gameObject` en `OnCollisionEnter()`). Según la etiqueta del escudo, suma 5 puntos (tipo 1) o 10 puntos (tipo 2), muestra la puntuación total por consola con `Debug.Log()` y destruye el escudo recogido.

**Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesión4/gifs/Ejercicio5.gif)

### Ejercicio 6: Interfaz de puntuación

**Hito alcanzado:** Creación de un Canvas en modo *Screen Space - Overlay* con un Canvas Scaler en *Scale With Screen Size* y un texto de TextMeshPro anclado en la esquina superior izquierda. El script de la interfaz se suscribe al evento `OnPuntuacionCambiada` del cubo y actualiza el texto cada vez que cambia la puntuación, de modo que el cubo no necesita conocer la interfaz.

**Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion4/gifs/Ejercicio6.gif)

### Ejercicio 7: Recompensas cada 100 puntos

**Hito alcanzado:** Sistema de recompensas que escucha la puntuación y entrega una recompensa cada vez que se supera un múltiplo de 100. Como los escudos suman de 5 en 5 o de 10 en 10, se comprueba el número de centenas superadas (`puntuacion / 100`) en lugar de la igualdad exacta, para no perder ninguna recompensa. La interfaz muestra un aviso temporal en el centro de la pantalla con el nombre de la recompensa, un contador de recompensas y un icono de medalla por cada una, instanciado desde un prefab dentro de un contenedor con *Horizontal Layout Group*.

**Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesión4/gifs/Ejercicio7.gif)

### Ejercicio 8: Escena del prototipo

**Hito alcanzado:** Construcción de una escena ambientada con elementos del prototipo realizados con primitivas de Unity, sin recursos externos adicionales. En ella se combinan las mecánicas de recolección de escudos, puntuación en la interfaz y recompensas con la mecánica de teletransporte y orientación de los humanoides al acercarse el cubo al objeto de referencia, y se añade una cámara que sigue al jugador.

**Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesión4/gifs/Ejercicio8.gif)

### Ejercicio 9: Ejercicio 3 con el cubo como objeto físico

**Hito alcanzado:** Conversión del cubo en un objeto físico: se desactivaron *Is Trigger* en su collider e *Is Kinematic* en su Rigidbody, y el movimiento pasó a aplicarse con `Rigidbody.AddForce()` en `FixedUpdate()`, con la rotación bloqueada y salto con la barra espaciadora. El cubo ya no atraviesa a los humanoides, sino que choca con ellos y empuja los escudos de tipo 2, y la mecánica del ejercicio 3 pasa a activarse mediante `OnCollisionEnter()` en lugar de `OnTriggerEnter()`, sin necesidad de modificar los scripts de los humanoides.

**Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesión4/gifs/Ejercicio9.gif)
