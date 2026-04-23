# 🧠 Design Decisions – Tamagotchi Project

---

## 📌 1. Project Context

**Project Name:**  
J4vi - Put a Javi in your life

**Game Type:**  
Virtual pet simulator

**Development Time:**  
9 months

**Role in the project:**  
Gameplay and Systems Programmer

**Document Goal:**  
This document describes the design decisions made for gameplay mechanics and systems.

---

## 🎯 2. Design Pillars

- Pillar 1: simple interactions  
- Pillar 2: clear feedback of the character state  
- Pillar 3: emotional connection between player and character  
- Pillar 4: player enjoyment  

---

## 🧩 3. Design Decisions

Main systems in the project:

- Growth stages FSM  
- Mission system  
- Character stats system  
- UI notification system  
- Needs notification system  

---

### 🔹 Decision: Growth Stages FSM

**Problem**  
> I needed to define how to manage different growth stages of the character, making sure each stage had its own behaviors, interactions, and mechanics without creating complex dependencies.

---

**Options considered**

- Finite State Machine (FSM)  
- Iindependent classes without shared structure  
- Simple condition-based logic  

---

**Decision made**

> I decided to use a Finite State Machine (FSM) to manage growth stages.

---

**Why**

- It allows each stage to have independent behavior  
- Makes transitions between stages easier to control  
- Improves scalability if more stages are added  
- Reinforces the feeling of progression for the player  

---

**Trade-offs**

- Higher initial complexity  
- Extra structure for a small number of states  
- Requires more planning  

---

**Result**

> The system allowed three different growth stages with unique behaviors, improving code clarity and the player’s sense of progression.

---

**If I had more time…**

> I would add variations inside each state (substates or dynamic behavior) to increase depth without adding more stages.

---

### 🔹 Decision: Mission System

**Problem**  
> I needed a mission system to structure player progression and control the transition between growth stages in a clear and scalable way.

---

**Options considered**

- Simple mission system based on direct conditions  
- Modular and scalable mission system based on reusable objectives  

---

**Decision made**

> I decided to implement a modular and scalable mission system.

---

**Why**

- Provides clear goals for the player  
- Makes it easier to add new content  
- Reinforces the core gameplay loop  
- Allows reuse of mission logic across different stages  

---

**Trade-offs**

- More complex than a simple system  
- Requires more planning  
- May be too much for small projects if not reused  

---

**Result**

> The system guided the player through clear objectives, improving progression and helping transitions between growth stages.

---

**If I had more time…**

> I would create editor tools to make mission creation faster and easier to iterate.

---

### 🔹 Decision: Character Stats System

**Problem**  
> I needed a system for character needs (hunger, sleep, fun) that changes over time and forces the player to manage multiple variables at once.

---

**Options considered**

- FSM with global states  
- Independent variables managed with classes  

---

**Decision made**

> I implemented independent stats using classes, allowing all needs to update at the same time.

---

**Why**

- Allows multiple needs to decrease at the same time  
- Creates constant pressure on the player  
- Encourages decision-making and prioritization  
- Works better for real-time systems than an FSM  
- Makes it easier to adjust each stat individually  

---

**Trade-offs**

- Harder to balance  
- Risk of overwhelming the player  
- Needs clear UI feedback  

---

**Result**

> The system created a gameplay loop based on managing needs, where the player constantly prioritizes actions and feels responsible for the character.

---

**If I had more time…**

> I would add interactions between stats (e.g., sleep affecting fun) to create more depth.

---

### 🔹 Decision: UI Notification System

**Problem**  
> I needed a system to inform the player about important events without overwhelming them or interrupting gameplay.

---

**Options considered**

- No order control (show notifications as they happen)  
- Custom system with priorities  
- FIFO queue system  

---

**Decision made**

> I used a FIFO queue system where notifications are shown in order.

---

**Why**

- Keeps communication clear and predictable  
- Controls the flow of information  
- Avoids overwhelming the player  
- Simpler than priority-based systems  
- Works well for frequent but simple events  

---

**Trade-offs**

- No priority for urgent events  
- Possible delay for important notifications  
- Less flexible than advanced systems  

---

**Result**

> The system communicates events in a clear and steady way, improving readability and maintaining a smooth gameplay flow.

---

**If I had more time…**

> I would upgrade it to a hybrid system with priorities for critical events.

---

### 🔹 Decision: Needs Notification System

**Problem**  
> I needed a system to alert the player when character needs reach critical levels, ensuring quick response without UI overload.

---

**Options considered**

- Using the general FIFO notification system  
- Custom system with dedicated classes per need  

---

**Decision made**

> I implemented a custom system using classes for each need.

---

**Why**

- Allows different behavior per need (frequency, urgency, type)  
- Communicates critical events more directly  
- Reinforces urgency  
- Improves visual clarity  

---

**Trade-offs**

- More complex than a single system  
- Possible redundancy with the main notification system  
- Needs careful balance to avoid spam  

---

**Result**

> The system improved how critical needs are communicated, increasing player reaction and reinforcing the care loop.

---

**If I had more time…**

> I would merge both notification systems into a hybrid priority-based system.

---

## 📊 4. Learnings

- Simple systems connected together create more impact than complex isolated ones  
- Constant feedback is key in tamagotchi-style games  
- I underestimated the importance of balancing timers  

---

## 🔮 5. Future Improvements

- Expand the needs system with more variables and relationships  
- Add new actions and rooms to increase player options  
- Add minigames connected to specific needs  
- Improve notifications with a hybrid priority system  
- Create editor tools for missions and events  

---

## 🧭 6. Design Summary

> This project focused on designing a care system based on real-time needs and character progression.  
> The main decisions were focused on creating a clear gameplay loop with constant feedback and player decision-making.  
> The result is an experience where the player must constantly prioritize actions and respond to the character’s state.
