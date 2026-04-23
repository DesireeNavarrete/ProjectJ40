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
[Explica en 2-3 líneas que este documento describe decisiones de diseño y por qué se tomaron]

---

## 🎯 2. Pilares de diseño

*(Define 2–4 ideas clave que guían TODO el diseño del juego)*

- Pilar 1: Simplicidad en las interacciones
- Pilar 2: Feedback claro del estado del personaje
- Pilar 3: Relación emocional jugador–personaje
- Pilar 4: Diversión del jugador

👉 **Cómo rellenarlo:**  
Piensa: “¿Qué era lo más importante que el jugador sintiera o hiciera?”

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
> Necesitaba diseñar un sistema que permitiera tener diferentes comportamientos para cada etapa de crecimiento, ya que cada etapa desbloquea nuevas interacciones con el jugador.

---

**Opciones consideradas**

- Opción 1: máquina de estados
- Opción 2: clases personalizadas

---

**Decisión tomada**

> Se decidió implementar la máquina de estados.

---

**Por qué**

- Porque permite tener diferentes estados e ir cambiando entre ellos.
- Porque quería aprender a implementarla.

---

**Trade-offs (consecuencias negativas)**

- Pierdes [algo]
- Complica [algo]
- Limita [algo]

---

**Resultado**

> El sistema permitió tener 3 etapas de crecimiento que se pueden controlar desde donde sea.

---

**Si tuviera más tiempo...*

> Mejoraría este sistema añadiendo [idea].

---

### 🔹 Decisión: Sistema de misiones

**Problema**  
> Necesitaba diseñar un sistema de misiones para que al completarlas cambiara de etapa de crecimiento (creciera el personaje).

---

**Opciones consideradas**

- Opción 1: sistema de misiones sencillo
- Opción 2: sistemas de misiones escalable y modular

---

**Decisión tomada**

> Se decidió implementar el sistema de misiones escalable y modular

---

**Por qué**

- Porque permite escalarlo mas fácil entre estados, ya que tenemos 3.
- Porque es fácil implementar más misiones


---

**Trade-offs (consecuencias negativas)**

- Pierdes [algo]
- Complica [algo]
- Limita [algo]

---

**Resultado**

> El sistema permitió que el jugador pudiera completar misiones, haciendo el gameplay mas fluido y con unas metas claras.

---

**Si tuviera más tiempo...*

> Mejoraría este sistema añadiendo [idea].

---


### 🔹 Decisión: Sistema de stats de personaje

**Problema**  
> Necesitaba diseñar un sistema de estados de personaje, 3 niveles, hambre, sueño y diversión que bajara por tiempo.

---

**Opciones consideradas**

- Opción 1: FSM
- Opción 2: clases personalizadas

---

**Decisión tomada**

> Se decidió implementar el sistema por clases personalizadas con creación de instancias.

---

**Por qué**

- Porque la maquina de estados no funcionaba con 3 estados a la vez que se actualiza en tiempo real.

---

**Trade-offs (consecuencias negativas)**

- Pierdes [algo]
- Complica [algo]
- Limita [algo]

---

**Resultado**

> El sistema permitió tener 3 stats a la vez en ejecución, haciendo más claras las necesidades el personaje.

---

**Si tuviera más tiempo...*

> Mejoraría este sistema añadiendo [idea].

---


### 🔹 Decisión: Sistema de notificaciones de UI

**Problema**  
> Necesitaba diseñar un sistema de notificaciones para comunicar ciertas cosas al jugador, como un feed.

---

**Opciones consideradas**

- Opción 1: Queue
- Opción 2: sistema propio

---

**Decisión tomada**

> Se decidió implementar el sistema FIFO con Queue.

---

**Por qué**

- Porque la primera notificación que entra es la primera que sale.
- Porque así aprendo un sistema nuevo.

---

**Trade-offs (consecuencias negativas)**

- Pierdes [algo]
- Complica [algo]
- Limita [algo]

---

**Resultado**

> El sistema permitió un feed de notificaciones de comunicación con el jugador, ayudando a la Flow del gameplay.

---

**Si tuviera más tiempo...*

> Mejoraría este sistema añadiendo [idea].

---
### 🔹 Decisión: notificaciones de necesidades

**Problema**  
> Necesitaba diseñar un sistema de necesidades del personaje.

---

**Opciones consideradas**

- Opción 1: FIFO
- Opción 2: clase personalizada

---

**Decisión tomada**

> Se decidió implementar el sistema por clase personalizada.

---

**Por qué**

- Porque permite personalizar la notificación, ya que no se comporta como un sistema FIFO.

---

**Trade-offs (consecuencias negativas)**

- Pierdes [algo]
- Complica [algo]
- Limita [algo]

---

**Resultado**

> El sistema permitió mejorar el gameplay implementando un sistema de limpieza e ir al baño del jugador, avisándolo por UI.

---

**Si tuviera más tiempo...*

> Mejoraría este sistema añadiendo más necesidades y mas complejidad.

---

---

## 📊 4. Aprendizajes

*(Reflexión honesta del proyecto)*

- Aprendí que a usar ciertos sistemas en los momentos correctos.
- Descubrí que [algo no funcionó como esperabas]
- Me di cuenta de que [comportamiento del jugador o sistema]
- La próxima vez haría [mejora clara]

---

## 🔮 5. Posibles mejoras futuras

*(Ideas claras, no humo)*

- Añadir más habitaciones con más acciones
- Mejorar el gameplay añadiendo minijuegos

- Explorar [idea de diseño]
- Cambiar [decisión que no funcionó del todo]

---

## 🧭 6. Resumen de diseño (opcional)

> Este proyecto se centró en [1 línea resumen].  
> Las decisiones principales se enfocaron en [2–3 ideas clave].  
> El resultado fue [impacto final en el gameplay].
