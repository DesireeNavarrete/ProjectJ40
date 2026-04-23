# Systems Overview

This document describes the **technical architecture** of the project and how systems interact.

---

## 🧠 Design Philosophy

The project is built with:

- Modularity
- Scalability
- Mobile-first constraints

Systems are designed to be lightweight and decoupled, suitable for **WebGL performance on mobile devices**.

---

## 📊 Needs System

### Purpose

Manages character needs that evolve over time.

### Implementation

- Float values (0–100)
- Frame-based updates using decay rates
- Immediate response to player actions

### Design Notes

- Decoupled from UI
- Optimized for continuous updates without heavy computation

---

## 🔄 Growth System (FSM)

### Purpose

Controls progression through character life stages.

### Implementation

- Custom FSM
- States implemented via `IState`

```csharp
public interface IState
{
    void Enter();
    void Execute();
    void Exit();
}
```

- Transitions triggered by quest completion

### Benefits

- Predictable behavior
- Easy to extend with new stages
- Clean separation of logic

---

## 🎯 Quest System

### Purpose

Drives progression through player actions.

### Structure

- ScriptableObject-based `Quest`
- Modular `QuestStep` logic

### Behavior

- Action-based completion
- UI-driven feedback
- Stage progression trigger

### Benefits

- Data-driven design
- Easy content expansion
- Minimal code changes for new quests

---

## 🔔 Notification System

### Purpose

Provides structured feedback to the player.

### Implementation

- FIFO queue system
- Sequential message handling

### Behavior

- Prevents UI spam
- Ensures readability on small screens
- Supports mobile UX constraints

---

## 🎮 Player Interaction System

### Purpose

Handles touch input and translates it into gameplay.

### Flow

1. Capture touch input
2. Validate interaction
3. Trigger activity
4. Notify systems

### Mobile Considerations

- Designed for **tap-based interaction**
- Avoids complex gestures
- Optimized for responsiveness

---

## 🧩 System Communication

- Activity → modifies Needs
- Quest → triggers FSM transitions
- Needs → sends notifications
- Notification → updates UI

Systems are loosely coupled to maintain flexibility.

---

## 📈 Scalability

Supports:

- Adding new stats easily
- Creating new activities with minimal effort
- Expanding rooms modularly
- Extending quest logic through ScriptableObjects

---

## ⚡ Performance Considerations

- Lightweight update loops
- Minimal dependencies between systems
- Designed to run smoothly in WebGL on mobile browsers

---

## 📝 Notes

- Focus is on systems, not final polish
- Architecture supports future expansion
