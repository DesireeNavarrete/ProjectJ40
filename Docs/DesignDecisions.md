# 🧠 Design Decisions – Tamagotchi Project

---

## 📌 1. Contexto del proyecto

**Nombre del proyecto:**  
J4vi - Pon un javi en tu vida

**Tipo de juego:**  
Simulador de mascota virtualº

**Duración del desarrollo:**  
9 meses

**Rol en el proyecto:**  
Programadora de gameplay y sistemas

**Objetivo del documento:**  
Este documento describe las decisiones tomadas sobre el diseño de las mecánicas y sistemas.

---

## 🎯 2. Pilares de diseño

- Pilar 1: Simplicidad en las interacciones
- Pilar 2: Feedback claro del estado del personaje
- Pilar 3: Relación emocional jugador–personaje
- Pilar 4: Diversión del jugador

---

## 🧩 3. Decisiones de diseño

Estos son los principales sistemas del proyecto:

- FSM de etapas de crecimiento
- Sistema de misiones
- Sistema de stats de personaje
- Sistema de notificaciones de UI
- Sistema de notificaciones de necesidades

---

### 🔹 Decisión: FSM de etapas de crecimiento

**Problema**  
> Necesitaba definir cómo gestionar las diferentes etapas de crecimiento del personaje, asegurando que cada una tuviera comportamientos, interacciones y mecánicas propias sin generar dependencias complejas.

---

**Opciones consideradas**

- Opción 1: máquina de estados(FSM)
- Opción 2: clases independientes sin estructura común
- Opción 3: Uso de condicionales simples para controlar la lógica por etapa

---

**Decisión tomada**

> Se decidió implementar la máquina de estados para gestionar las etapas de crecimiento.

---

**Por qué**

- Permite encapsular el comportamiento de cada etapa de forma independiente
- Facilita la transición controlada entre estados (crecimiento del personaje)
- Mejora la escalabilidad si se añaden nuevas etapas en el futuro
- Refuerza la sensación de progresión del jugador al diferenciar claramente cada fase

---

**Trade-offs (consecuencias negativas)**

- Mayor complejidad inicial frente a soluciones más simples
- Overhead estructural para un número limitado de estados
- Requiere una arquitectura más planificada

---

**Resultado**

> El sistema permitió implementar tres etapas diferenciadas con comportamientos propios, mejorando la claridad del código y la percepción de progreso en el gameplay.

---

**Si tuviera más tiempo...*

> Mejoraría este sistema añadiendo Añadiría variaciones dentro de cada estado (subestados o comportamiento dinámico) para aumentar la profundidad sin necesidad de añadir más etapas.

---

### 🔹 Decisión: Sistema de misiones

**Problema**  
> Necesitaba diseñar un sistema de misiones que permitiera estructurar la progresión del jugador y controlar el avance entre etapas de crecimiento del personaje de forma clara y escalable.

---

**Opciones consideradas**

- Opción 1: sistema de misiones sencillo, basado en condiciones directas
- Opción 2: sistemas de misiones modular y escalable, basado en objetivos reutilizables

---

**Decisión tomada**

> Se decidió implementar el sistema de misiones escalable y modular

---

**Por qué**

- Permite estructurar la progresión del jugador mediante objetivos claros y alcanzables
- Facilita añadir nuevo contenido sin modificar sistemas existentes
- Refuerza el bucle de juego al dar al jugador metas constantes
- Permite reutilizar lógica de misiones entre distintas etapas de crecimiento


---

**Trade-offs (consecuencias negativas)**

- Mayor complejidad inicial frente a un sistema simple
- Requiere más planificación para definir la estructura de misiones
- Puede ser excesivo para proyectos pequeños si no se reutiliza lo suficiente
---

**Resultado**

> El sistema permitió guiar al jugador a través de objetivos claros, mejorando la sensación de progresión y facilitando la transición entre etapas de crecimiento del personaje.

---

**Si tuviera más tiempo...*

> Añadiría herramientas internas (editor tools) para crear y configurar misiones de forma más rápida, reduciendo el tiempo de iteración y facilitando el diseño de nuevo contenido.

---


### 🔹 Decisión: Sistema de stats de personaje

**Problema**  
> Necesitaba diseñar un sistema de necesidades (hambre, sueño y diversión) que evolucionara en tiempo real y obligara al jugador a gestionar múltiples variables simultáneamente, generando decisiones constantes.

---

**Opciones consideradas**

- Opción 1: Uso de una máquina de estados (FSM) para representar estados globales
- Opción 2: Sistema basado en variables independientes gestionadas mediante clases

---

**Decisión tomada**

> Se decidió implementar un sistema basado en stats independientes gestionadas mediante clases, permitiendo que todas las necesidades evolucionen en paralelo.

---

**Por qué**

- Permite que múltiples necesidades se degraden simultáneamente, generando presión constante sobre el jugador
- Refuerza la toma de decisiones al obligar a priorizar qué necesidad atender primero
- Se adapta mejor a sistemas en tiempo real frente a una FSM, que limita el comportamiento a un único estado activo
- Facilita ajustar individualmente el comportamiento de cada stat (ritmo de degradación, efectos, etc.)

---

**Trade-offs (consecuencias negativas)**

- Mayor complejidad en el balanceo de los valores de cada stat
- Riesgo de sobrecargar al jugador si varias necesidades caen al mismo tiempo
- Requiere una buena comunicación visual para evitar confusión
---

**Resultado**

> El sistema permitió generar un bucle de gameplay basado en la gestión de necesidades, donde el jugador debe priorizar acciones constantemente, aumentando la interacción y la sensación de responsabilidad sobre el personaje.

---

**Si tuviera más tiempo...*

> Añadiría interacciones entre stats (por ejemplo, que el sueño afecte a la diversión) para generar mayor profundidad sistémica y decisiones más complejas.

---


### 🔹 Decisión: Sistema de notificaciones de UI

**Problema**  
> Necesitaba diseñar un sistema que comunicara al jugador los cambios importantes del estado del personaje (necesidades, eventos, acciones) sin saturarlo de información ni interrumpir el flujo de juego.
---

**Opciones consideradas**

- Opción 1: sistema simple sin control de orden (mostrar notificaciones según ocurren)
- Opción 2: sistema personalizado con gestión manual de prioridades
- Opción 3: sistema basado en cola FIFO (Queue)

---

**Decisión tomada**

> Se decidió implementar un sistema de notificaciones basado en una cola FIFO (Queue), donde las notificaciones se muestran en el orden en el que ocurren.

---

**Por qué**

- Permite mantener un orden claro y predecible en la comunicación al jugador
- Ayuda a controlar el ritmo de aparición de las notificaciones, evitando sobrecarga de información
- Reduce la complejidad del sistema frente a soluciones con prioridades dinámicas
- Se adapta bien a un juego con eventos frecuentes pero de baja complejidad

---

**Trade-offs (consecuencias negativas)**

- No permite priorizar eventos críticos sobre otros menos importantes
- Puede generar retraso en la comunicación de eventos urgentes
- Menor flexibilidad frente a sistemas más avanzados basados en prioridades

---

**Resultado**

> El sistema permitió comunicar los eventos del juego de forma ordenada y constante, mejorando la legibilidad de la información y evitando saturar al jugador, lo que contribuye a un flujo de juego más estable.

---

**Si tuviera más tiempo...*

> Mejoraría este sistema añadiendo [idea].

---
### 🔹 Decisión: notificaciones de necesidades

**Problema**  
> Necesitaba diseñar un sistema que alertara al jugador cuando las necesidades del personaje (hambre, sueño, limpieza, etc.) alcanzaran niveles críticos, asegurando una respuesta rápida sin saturar la interfaz.

---

**Opciones consideradas**

- Opción 1: uso del sistema general de notificaciones FIFO
- Opción 2: sistema específico mediante clases personalizadas para cada necesidad

---

**Decisión tomada**

> Se decidió implementar un sistema específico basado en clases personalizadas para gestionar las notificaciones de necesidades de forma independiente.

---

**Por qué**

- Permite adaptar el comportamiento de cada necesidad (frecuencia, urgencia, tipo de aviso)
- Facilita comunicar eventos críticos de forma más directa que un sistema FIFO general
- Refuerza la sensación de urgencia al priorizar estados importantes del personaje
- Permite diferenciar visualmente cada tipo de necesidad para mejorar la legibilidad

---

**Trade-offs (consecuencias negativas)**

- Mayor complejidad al mantener un sistema paralelo al de notificaciones general
- Riesgo de redundancia si no se coordinan bien ambos sistemas
- Necesidad de equilibrar la frecuencia de avisos para evitar saturación

---

**Resultado**

> El sistema permitió comunicar de forma más efectiva las necesidades críticas del personaje, aumentando la capacidad de reacción del jugador y reforzando el bucle de cuidado.

---

**Si tuviera más tiempo...*

> Integraría este sistema con el de notificaciones general mediante un modelo híbrido con prioridades, unificando la gestión del feedback sin perder control sobre los eventos críticos.

---

---

## 📊 4. Aprendizajes

*(Reflexión honesta del proyecto)*

- Aprendí que sistemas simples bien conectados generan más impacto que sistemas complejos aislados
- Descubrí que el feedback constante es clave para mantener la interacción en juegos tipo tamagotchi
- Subestimé la importancia del balanceo de los timers en las necesidades

---

## 🔮 5. Posibles mejoras futuras

- Expandir el sistema de necesidades añadiendo nuevas variables y relaciones entre ellas (por ejemplo, que el sueño afecte a la diversión), aumentando la profundidad del sistema.

- Añadir nuevas acciones y espacios (habitaciones) que amplíen las opciones del jugador y refuercen el bucle de cuidado.

- Implementar minijuegos ligados a necesidades concretas, integrándolos como parte del core loop en lugar de contenido aislado.

- Mejorar el sistema de notificaciones hacia un modelo híbrido con prioridades, unificando la comunicación sin perder control sobre eventos críticos.

- Desarrollar herramientas internas (editor tools) para facilitar la creación y balanceo de misiones y eventos.
---

## 🧭 6. Resumen de diseño (opcional)

## 🧭 6. Resumen de diseño

> Este proyecto se centró en diseñar un sistema de cuidado basado en la gestión de necesidades en tiempo real y la progresión del personaje.  
> Las decisiones principales se enfocaron en crear un bucle de juego claro, apoyado en feedback constante y toma de decisiones por parte del jugador.  
> El resultado es una experiencia donde el jugador debe priorizar acciones de forma continua, respondiendo al estado del personaje y reforzando la sensación de responsabilidad.
