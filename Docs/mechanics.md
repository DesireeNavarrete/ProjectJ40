# Mechanics Overview

This document explains the gameplay mechanics in ProjectJ40.

ProjectJ40 is a mobile-first virtual pet prototype. The player takes care of Javi by managing stats, completing quests, moving between rooms, and unlocking growth phases.

---

## Core Gameplay Loop

| Step | Result |
| --- | --- |
| Player taps an action | A room action is executed |
| Stats update | Hunger, Sleep, or Play/Fun is restored or changed |
| Needs counters update | Bathroom or shower alerts may appear |
| Quest step checks the action | A matching quest step can complete |
| Experience increases | The current growth phase moves closer to completion |
| Growth phase unlocks | Javi can advance to the next phase |
| New actions appear | More room actions become available |

The player is encouraged to make quick decisions and keep Javi stable while also completing objectives.

---

## Main Stats

Javi has three main stats:

| Stat | Purpose | Example actions |
| --- | --- | --- |
| Hunger | Represents food/energy needs | Food, protein, coffee |
| Sleep | Represents rest | Sleep |
| Play/Fun | Represents activity and entertainment | Computer, basketball, DIY, crossfit, biology |

Each stat starts at `100` and decays over time. Player actions restore related stats back to `100`.

The UI shows these values with sliders. Warning colors help communicate when a stat is low.

---

## Actions and Cooldown

Actions are triggered through large UI buttons. This supports mobile play and avoids complex input.

When an action is used, a shared cooldown starts. During this cooldown, most action buttons are temporarily disabled. This prevents the player from spamming actions too quickly.

Examples of actions:

- Eat
- Use computer
- Sleep
- Shower
- Go to the bathroom
- Weld
- Play basketball
- Go out with friends
- Drink coffee
- Drink protein
- Do DIY
- Go to crossfit

---

## Rooms

The game is divided into rooms. Each room shows different actions and a different background color.

| Room | Role |
| --- | --- |
| Kitchen | Food, coffee, protein, growth/birthday action |
| Lab | Computer, welding, DIY |
| Bath | Bathroom and shower actions |
| Dorm | Sleep action |
| Entrance | Social and sport actions |

The player can move between rooms using the room navigation UI.

---

## Growth Phases

Javi grows through three phases:

```text
Baby -> Teen -> Adult
```

Progression is linked to quest completion. When the phase progress bar is filled, the game shows a message and enables the birthday/growth button.

Phase behavior:

| Phase | Gameplay role |
| --- | --- |
| Baby | Starts with the basic care loop and first quests |
| Teen | Unlocks new actions like welding, basketball, going out, and biology |
| Adult | Unlocks actions like protein, coffee, DIY, and crossfit |

---

## Quest Progression

Quests are grouped by level/block. Each quest is completed by doing a specific player action or responding to a need.

### Baby Quests - Level 0

| Quest | Player action |
| --- | --- |
| Alimenta a Javi | Use food |
| Juega con Javi | Use computer |
| Duerme a Javi | Use sleep |
| Lleva a Javi al baño cuando lo necesite | Respond to bathroom need |
| Lleva a Javi a la ducha cuando lo necesite | Respond to shower need |

### Teen Quests - Level 1

These quests require the Baby quest block to be completed first.

| Quest | Player action |
| --- | --- |
| Observa como suelda Javi | Use welding |
| Juega a baloncesto con Javi | Use basketball |
| Sal con Javi y sus amigos | Use going out action |
| Ves a limpiar playas | Use biology/clean beach action |

### Adult Quests - Level 2

These quests require the Teen quest block to be completed first.

| Quest | Player action |
| --- | --- |
| Mira como diseña Javi | Use computer/design action |
| Un batido de proteinas | Use protein |
| Lleva a Javi a crossfit | Use crossfit |
| Un café para Javi | Use coffee |
| Vamos a hacer un mueble | Use DIY |

---

## Needs Alerts

Some actions increase hidden need counters. When a counter reaches its threshold, Javi shows a care alert.

Current alerts:

- Bathroom need
- Shower need

These alerts appear as icons. The player clears them by using the matching action in the Bath room.

---

## Player Experience Goals

- Keep actions fast and easy to understand.
- Make the player feel responsible for Javi.
- Combine short-term care with long-term progression.
- Use quests to guide the player through the available content.
- Keep the UI simple enough for mobile WebGL.

---

## Current Prototype Notes

- The project is focused on systems and gameplay structure.
- Balance values are still prototype values.
- Most actions give immediate feedback.
- The final game ending is not fully expanded yet.
