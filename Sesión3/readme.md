# Sesión: Movimiento - Físicas

**Autor:** Héctor Mesonero Santos

## Descripción
Este repositorio contiene los scripts y configuraciones desarrollados para los ejercicios de la sesión centrados en el motor de físicas de Unity. Se abarca el control directo de personajes mediante componentes `Rigidbody`, la detección de colisiones y disparadores (*Triggers*), la gestión de interacciones con la matriz de colisiones por capas (*Layer Collision Matrix*), el uso de materiales físicos (*Physics Materials*) y el movimiento de objetos sin física mediante vectores.

---

## Hitos y Pruebas de Ejecución

### Ejercicio 1: Control total con Rigidbody
- **Hito alcanzado:** Configuración de un personaje controlledo mediante las teclas WASD o flechas direccionales aplicando movimiento físico continuo en `FixedUpdate()`. Se utilizó `Input.GetAxisRaw()` y asignación directa a la velocidad del Rigidbody (`rb.velocity` / `rb.linearVelocity`) para obtener una respuesta inmediata sin inercia, bloqueando la rotación en los ejes X y Z en las restricciones (*Constraints*) para evitar vuelcos.
- **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/SesionFisicas/gifs/Ejercicio1.gif)

### Ejercicio 2: Detección de colisiones físicas y cambio de color
- **Hito alcanzado:** Creación de objetos dinámicos con `Rigidbody` que reaccionan a colisiones físicas. Mediante el evento `OnCollisionEnter()`, el objeto detecta el contacto, imprime en la consola el nombre de la entidad con la que colisiona (`colision.gameObject.name`) y modifica su propio material aplicando un color aleatorio generado con `Random.ColorHSV()`.
- **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/SesionFisicas/gifs/Ejercicio2.gif)

### Ejercicio 3: Zonas disparadoras (Triggers) de efecto y daño
- **Hito alcanzado:** Implementación de áreas de interacción activando la casilla `Is Trigger` en sus *Box Collider*. Se programaron los eventos `OnTriggerEnter()` y `OnTriggerExit()` para modificar el color del jugador mientras permanece en la zona de efecto y restaurarlo al salir. Asimismo, se integró una zona de daño que incrementa progresivamente una variable `danoAcumulado` en el script del personaje al ser atravesada.
- **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/SesionFisicas/gifs/Ejercicio3.gif)

### Ejercicio 4: Matriz de colisiones por capas (Layer Collision Matrix)
- **Hito alcanzado:** Configuración de capas personalizadas (*Jugador*, *Enemigo* y *Recolectable*) asignadas a distintas entidades de la escena. Modificación de la *Layer Collision Matrix* en la configuración del proyecto (`Project Settings > Physics`) para asegurar que los enemigos solo colisionen físicamente con la capa del jugador y que los objetos recolectables funcionen únicamente como disparadores (*Triggers*) ante el personaje.
- **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/SesionFisicas/gifs/Ejercicio4.gif)

### Ejercicio 5: Materiales físicos y aplicación de fuerzas
- **Hito alcanzado:** Creación y aplicación de tres *Physics Materials* diferenciados: resbaladizo (sin fricción), rugoso (alta fricción) y de alto rebote (*Bounciness* máximo). Se programó el lanzamiento de los objetos aplicando una fuerza de impulso instantánea con `rb.AddForce(..., ForceMode.Impulse)` al presionar la tecla `X`, analizando las variaciones de deslizamiento, frenado y rebote según el material asignado.
- **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/SesionFisicas/gifs/Ejercicio5.gif)

### Ejercicio 6: Desplazamiento y detección por distancia sin Rigidbody
- **Hito alcanzado:** Disposición de tres objetos alineados (Esfera, Cubo obstáculo y Cilindro objetivo) provistos de *Collider* pero sin *Rigidbody*. Implementación del desplazamiento de la esfera hacia la posición del cilindro mediante `Vector3.MoveTowards()`. Se evaluó la cercanía al obstáculo mediante `Vector3.Distance()`, modificando automáticamente el material del cubo al momento de ser alcanzado por la esfera.
- **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/SesionFisicas/gifs/Ejercicio6.gif)