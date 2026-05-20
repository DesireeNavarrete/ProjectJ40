# Design Decisions - ProjectJ40 / J4vi

This document explains the main design and technical decisions behind ProjectJ40.

ProjectJ40 is a virtual pet prototype made in Unity. The player takes care of Javi, completes quests, and unlocks new growth phases.

---

## Project Context

| Item | Description |
| --- | --- |
| Project name | ProjectJ40 / J4vi |
| Game type | Virtual pet simulator |
| Platform target | Mobile WebGL |
| Engine | Unity `2022.3.20f1` |
| Main role | Gameplay and systems programming |
| Main focus | Systems architecture, progression, and mobile-friendly interaction |

---

## Design Pillars

- **Simple interaction:** the player should understand each action quickly.
- **Clear feedback:** Javi's state should be visible through stats, icons, and messages.
- **Care loop:** the player should feel responsible for Javi.
- **Progression:** quests and growth phases should give long-term goals.
- **Mobile-first UI:** actions should work well on small screens with touch input.

---

## Decision: Custom Growth FSM

### Problem

Javi needed different life phases with different available actions and progression rules.

### Options Considered

- Simple condition checks.
- Independent scripts for each phase.
- A small finite state machine.

### Decision

Use a custom finite state machine with separate state classes:

- `BabyPhase`
- `TeenPhase`
- `AdultPhase`

### Why

The FSM keeps phase transitions explicit and easy to understand. Each phase can own its behavior without mixing all progression logic into one script.

### Trade-Offs

- More structure than a simple prototype usually needs.
- Requires clear transition points.
- Some phase behavior still lives in `Player`, so there is room to move more logic into phase classes later.

### Result

The system supports a clear growth path:

```text
Baby -> Teen -> Adult
```

It also makes the project easier to explain as a technical portfolio piece.

---

## Decision: ScriptableObject Quest System

### Problem

The game needed a way to guide the player, unlock progression, and define different objectives without hardcoding every quest directly into the manager.

### Options Considered

- Hardcoded quest list.
- One script per quest only.
- ScriptableObject quest data with reusable quest logic.

### Decision

Use `QuestInfoSO` assets for quest data, combined with `QuestStep` prefabs for quest behavior.

### Why

ScriptableObjects make the quest list easier to edit in Unity. The manager can load all quests from `Resources/Quests`, check requirements, and update quest states through events.

### Trade-Offs

- Quest steps are still action-specific scripts.
- Content setup depends on correct Unity asset references.
- There is no custom editor tool yet for creating quests faster.

### Result

The project has three blocks of quests linked to growth levels:

- Baby quests at level 0.
- Teen quests at level 1.
- Adult quests at level 2.

This creates a clear progression path for the player.

---

## Decision: Decaying Stats Instead of Global Pet State

### Problem

Javi needed several needs that could change at the same time.

### Options Considered

- One global mood state.
- A state machine for all needs.
- Independent stat values.

### Decision

Use independent `Stat` values managed by `StatsManager`.

Current main stats:

- Hunger
- Sleep
- Play/Fun

### Why

Independent stats are simple and flexible. They let the player prioritize different needs and create constant light pressure.

### Trade-Offs

- Balance can become harder as more actions are added.
- Stats need clear UI feedback.
- Some action effects are currently simple resets to `100`, which is good for prototype clarity but can be expanded later.

### Result

The care loop is easy to understand: stats decay over time, and player actions restore them.

---

## Decision: Room-Based Action UI

### Problem

The game needed several actions without overcrowding the screen.

### Options Considered

- Show all actions at once.
- Use menus and submenus.
- Split actions by rooms.

### Decision

Use rooms to group actions:

- Kitchen
- Lab
- Bath
- Dorm
- Entrance

### Why

Rooms make the UI easier to scan. They also give a simple world structure without needing a large map or complex navigation.

### Trade-Offs

- Room logic needs to manage many object references.
- Adding a new room requires UI setup.
- Current room changes are mostly UI-based, not a full scene/world system.

### Result

The player can move between clear spaces, and new phase actions can appear in the correct room.

---

## Decision: Two Notification Channels

### Problem

The player needed feedback for both general events and urgent care needs.

### Options Considered

- Only text messages.
- Only icon alerts.
- Separate channels for text and needs.

### Decision

Use two notification flows:

- Text UI notifications for events like quest completion or growth messages.
- Need icons for bathroom and shower alerts.

### Why

Text messages are useful for explaining progress. Icons are better for quick care alerts on a small mobile screen.

### Trade-Offs

- There is some overlap between notification systems.
- Need notifications use a list instead of the same queue model as text notifications.
- A future version could merge both into a priority-based notification system.

### Result

The prototype communicates both progression and immediate needs without relying on only one feedback style.

---

## What Worked Well

- The quest system gives structure to the prototype.
- The FSM makes growth progression easy to understand.
- ScriptableObjects make quest content visible in the Unity editor.
- Rooms help organize actions for a mobile UI.
- The project has a strong base for a portfolio explanation.

---

## Future Improvements

- Add save/load for player progress.
- Move more phase-specific logic out of `Player` and into phase classes.
- Create editor tools for faster quest creation.
- Add more varied stat effects instead of only resetting values.
- Improve notification priority and timing.
- Add stronger final-game feedback for the Adult phase.
- Reduce direct `GameObject.Find` and scene reference coupling.

---

## Design Summary

ProjectJ40 focuses on a clear virtual pet care loop supported by modular systems. The main design goal was not to build a large game, but to create a playable prototype where stats, quests, rooms, growth phases, and feedback work together.

The result is a small mobile-first WebGL project that demonstrates gameplay architecture, Unity UI flow, ScriptableObject content, and state-based progression.
