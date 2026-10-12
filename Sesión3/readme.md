# Sesión: Movimiento - Físicas

**Autor:** Héctor Mesonero Santos

## Descripción
Este repositorio contiene los scripts y configuraciones desarrollados para los ejercicios de la sesión centrados en el motor de físicas de Unity, además de las distintas situaciones en las que se experimentó con diferentes configuraciones de los componentes `Rigidbody` y `Collider`. Se abarca el control directo de personajes mediante componentes `Rigidbody`, la detección de colisiones y disparadores (*Triggers*), la gestión de interacciones con la matriz de colisiones por capas (*Layer Collision Matrix*), el uso de materiales físicos (*Physics Materials*) y el movimiento de objetos sin física mediante vectores.

---

## Situaciones

### Situación 1.
El cubo caerá por efecto de la gravedad hasta chocar con el plano, mientras que la esfera se mantendrá suspendida de forma estática en el aire al carecer de un componente que le aplique físicas.

### Situación 2. 
El cubo y la esfera caerán por la gravedad; la esfera colisionará contra el cubo o el plano reaccionando con un rebote físico, mientras que el plano seguirá fijo sosteniendo el conjunto

### Situación 3.
El cubo caerá con normalidad, pero la esfera, al tener activada la opción cinemática, ignorará la gravedad y las fuerzas externas, flotando en el aire como un objeto inamovible.

### Situación 4.
Al tener un Rigidbody estándar, el motor de Unity aplicará gravedad al plano, provocando que los tres objetos caigan infinitamente hacia el vacío.

### Situación 5.
Todos los objetos volverán a caer al vacío. Como no hay fricción de aire configurada, la masa no altera la aceleración, por lo que caerán a la misma velocidad; la masa adicional solo haría que la esfera empuje al cubo con mucha más fuerza si logran chocar en el aire.

### Situación 6.
El comportamiento principal es idéntico a la situación anterior, cayendo todos al simultáneamente hacia el vacío. La enorme diferencia de masa causaría que, de producirse un choque en pleno aire, la esfera desplazara al cubo transfiriendo una gran energía cinética sin apenas frenarse.

### Situación 7.
Los tres objetos seguirán cayendo hacia el vacío. Si la esfera llegara a rozar con el cubo durante la caída, el material físico de fricción generará resistencia al deslizamiento, forzando a la esfera a rotar o frenarse contra la superficie en lugar de resbalar.

### Situación 8.
El plano y el cubo caerán al vacío por la gravedad, mientras que la esfera se quedará estática, permitiendo que cualquier objeto la atraviese limpiamente (y registrando eventos de código como OnTriggerEnter).

### Situación 9.
Los tres elementos caerán de manera continua afectados por la gravedad. Dado que la esfera tiene su Collider como Trigger, dejará de colisionar de forma sólida; si sus trayectorias se cruzan con el cubo o el plano durante la caída, se atravesarán entre sí sin rebotar.

## Hitos y Pruebas de Ejecución

### Ejercicio 1: Control total con Rigidbody
- **Hito alcanzado:** Configuración de un personaje controlado mediante las teclas WASD o flechas direccionales aplicando movimiento físico continuo en `FixedUpdate()`. Se utilizó `Input.GetAxisRaw()` y asignación directa a la velocidad del Rigidbody (`rb.velocity` / `rb.linearVelocity`) para obtener una respuesta inmediata sin inercia, bloqueando la rotación en los ejes X y Z en las restricciones (*Constraints*) para evitar vuelcos.
- **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesión3/gifs/Ejercicio1.gif)

### Ejercicio 2: Detección de colisiones físicas y cambio de color
- **Hito alcanzado:** Creación de objetos dinámicos con `Rigidbody` que reaccionan a colisiones físicas. Mediante el evento `OnCollisionEnter()`, el objeto detecta el contacto, imprime en la consola el nombre de la entidad con la que colisiona (`colision.gameObject.name`) y modifica su propio material aplicando un color aleatorio generado con `Random.ColorHSV()`.
- **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesión3/gifs/Ejercicio2.gif)

### Ejercicio 3: Zonas disparadoras (Triggers) de efecto y daño
- **Hito alcanzado:** Implementación de áreas de interacción activando la casilla `Is Trigger` en sus *Box Collider*. Se programaron los eventos `OnTriggerEnter()` y `OnTriggerExit()` para modificar el color del jugador mientras permanece en la zona de efecto y restaurarlo al salir. Asimismo, se integró una zona de daño que incrementa progresivamente una variable `danoAcumulado` en el script del personaje al ser atravesada.
- **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesión3/gifs/Ejercicio3.gif)

### Ejercicio 4: Matriz de colisiones por capas (Layer Collision Matrix)
- **Hito alcanzado:** Configuración de capas personalizadas (*Jugador*, *Enemigo* y *Recolectable*) asignadas a distintas entidades de la escena. Modificación de la *Layer Collision Matrix* en la configuración del proyecto (`Project Settings > Physics`) para asegurar que los enemigos solo colisionen físicamente con la capa del jugador y que los objetos recolectables funcionen únicamente como disparadores (*Triggers*) ante el personaje.
- **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesión3/gifs/Ejercicio4.gif)

### Ejercicio 5: Materiales físicos y aplicación de fuerzas
- **Hito alcanzado:** Creación y aplicación de tres *Physics Materials* diferenciados: resbaladizo (sin fricción), rugoso (alta fricción) y de alto rebote (*Bounciness* máximo). Se programó el lanzamiento de los objetos aplicando una fuerza de impulso instantánea con `rb.AddForce(..., ForceMode.Impulse)` al presionar la tecla `X`, analizando las variaciones de deslizamiento, frenado y rebote según el material asignado.
- **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesión3/gifs/Ejercicio5.gif)

### Ejercicio 6: Desplazamiento y detección por distancia sin Rigidbody
- **Hito alcanzado:** Disposición de tres objetos alineados (Esfera, Cubo obstáculo y Cilindro objetivo) provistos de *Collider* pero sin *Rigidbody*. Implementación del desplazamiento de la esfera hacia la posición del cilindro mediante `Vector3.MoveTowards()`. Se evaluó la cercanía al obstáculo mediante `Vector3.Distance()`, modificando automáticamente el material del cubo al momento de ser alcanzado por la esfera.
- **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesión3/gifs/Ejercicio6.gif)
