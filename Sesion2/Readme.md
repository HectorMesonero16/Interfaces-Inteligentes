# Práctica 2: Input y Movimiento en Unity
**Autor:** Héctor Mesonero Santos

**Descripción**

Este repositorio contiene los scripts requeridos para los distintos ejercicios de la Práctica 2, centrados en la gestión de entradas del usuario, traslaciones, rotaciones y el seguimiento de objetivos.

**Hitos y Pruebas de Ejecución**

**Ejercicio 5: Desplazamiento mediante marcador**
*   **Hito alcanzado:** Configuración de tres objetos con una variable pública `Vector3` de desplazamiento. Creación de un script que reubica los objetos en dichas posiciones relativas al pulsar la barra espaciadora, detectada mediante `Input.GetAxis()`.
*   **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion2/gifs/Ejercicio5.gif)

**Ejercicio 6: Lectura de ejes direccionales y consola**
*   **Hito alcanzado:** Agregada una variable pública de velocidad a un cubo. Muestra por consola el resultado de multiplicar la velocidad por los ejes vertical y horizontal al pulsar las flechas, indicando la tecla específica accionada.
*   **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion2/gifs/Ejercicio6.gif)

**Ejercicio 7: Mapeo de teclas personalizado**
*   **Hito alcanzado:** Modificación del *Input Manager* de Unity (Old Input System) para redefinir el mapeo por defecto de los controladores, asignando la tecla `H` a la función de disparo ("Fire").
*   **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion2/gifs/Ejercicio7.png)

**Ejercicio 8: Movimiento continuo con Translate**
*   **Hito alcanzado:** Creación de un script que traslada un cubo proporcionalmente a un vector `moveDirection` y una variable `speed` desde el inspector. Se analizaron los resultados al modificar coordenadas, velocidad, altura y al intercambiar los sistemas de referencia local y mundial.
a)	Duplicar las coordenadas de la dirección del movimiento: El cubo se mueve el doble de rápido en ese eje.

b)	Duplicar la velocidad manteniendo la dirección del movimiento: El cubo se mueve el doble de rápido.

c)	Velocidad es menor que 1: En el caso en el que la velocidad está entre 0 y 1, se moverá más lento. Cuando la velocidad es menor que 0 se moverá en la dirección contraria (si antes se movía a la derecha ahora se moverá a la izquierda).

d)	La posición del cubo está en y > 0: el cubo mantendrá su altura inicial constante y se desplazará flotando por el aire.

e)	Intercambiar movimiento relativo al sistema de referencia local y el mundial: El sistema local toma en cuenta la rotación del propio objeto para determinar hacia dónde avanzar. El sistema mundial ignora la rotación del objeto y lo desplaza guiándose únicamente por los ejes fijos y globales de la escena.

*   **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion2/gifs/Ejercicio8.gif)

**Ejercicio 9: Control múltiple de entidades**
*   **Hito alcanzado:** Implementación de controles independientes en la misma escena: el cubo se mueve mediante las teclas de flecha direccional y la esfera mediante las teclas W, A, S y D.
*   **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion2/gifs/Ejercicio9.gif)

**Ejercicio 10: Independencia de fotogramas (Time.deltaTime)**
*   **Hito alcanzado:** Adaptación de las mecánicas de movimiento desarrolladas anteriormente utilizando el valor `Time.deltaTime` para escalar el espacio recorrido, garantizando que la velocidad sea independiente de los frames generados.
*   **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion2/gifs/Ejercicio10.gif)

**Ejercicio 11: Persecución de objetivos con vectores normalizados**
*   **Hito alcanzado:** Modificación del script para que el cubo avance hacia la posición de la esfera manteniendo su altura original en `y=0`. Se utilizó `Vector3.normalized` en el vector de dirección para asegurar un avance constante independiente de la distancia.
*   **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion2/gifs/Ejercicio11.gif)

**Ejercicio 12: Orientación y persecución (LookAt)**
*   **Hito alcanzado:** Uso de `Transform.LookAt()` para conseguir que el cubo siempre gire apuntando su eje Z positivo (hacia delante) a la esfera mientras avanza hacia ella, reaccionando dinámicamente a los movimientos de la esfera con AWSD.
*   **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion2/gifs/Ejercicio12.gif)

**Ejercicio 13: Avance frontal y giro con eje Horizontal**
*   **Hito alcanzado:** Configuración del movimiento para permitir que el objeto gire usando el eje "Horizontal" y avance siempre en la dirección hacia adelante definida por la propiedad `transform.forward`. Se integró `Debug.DrawRay` para la visualización y depuración del vector frontal.
*   **Prueba de ejecución:** (https://github.com/HectorMesonero16/Interfaces-Inteligentes/blob/main/Sesion2/gifs/Ejercicio%2013.gif)
