# Systems Overview

This document explains the main technical systems in ProjectJ40 and how they work together.

ProjectJ40 is a Unity WebGL prototype. The architecture is built around small gameplay systems connected through UI actions, events, and ScriptableObject data.

---

## Main Runtime Flow

| Source | Sends to | Purpose |
| --- | --- | --- |
| UI Buttons | `StatsManager` | Restore or update the main care stats |
| UI Buttons | `NeedsSystem` | Advance hidden need counters |
| UI Buttons | `RoomsManager` | Change the active room UI |
| `NeedsSystem` | `Notifications` | Show bathroom and shower alerts |
| `QuestPoint` | `GameEventsManager / QuestEvents` | Request quest start or finish events |
| `GameEventsManager / QuestEvents` | `QuestManager` | Route quest events without direct UI coupling |
| `QuestManager` | `GrowthController` FSM | Trigger growth progression after quest completion |
| `QuestManager` | `Notifications` | Show quest completion and progression messages |

The project uses a simple scene setup where managers reference shared UI elements through `CanvasComponent`.

---

## Growth System

The growth system controls Javi's life phase.

Main classes:

- `GrowthController`
- `StateMachine`
- `IState`
- `BabyPhase`
- `TeenPhase`
- `AdultPhase`
- `GrowthStage`

The game starts in `BabyPhase`. When enough quests are completed, the player can trigger a birthday/growth action. This advances the FSM to the next phase:

```text
Baby -> Teen -> Adult
```

Each phase can unlock different actions. For example, Teen unlocks actions like welding, basketball, going out with friends, and biology. Adult unlocks actions like protein, coffee, DIY, and crossfit.

The FSM keeps the progression logic clear and makes new phases easier to add later.

---

## Stats System

The stats system manages the three main care values:

- Hunger
- Sleep
- Play/Fun

Main classes:

- `StatsManager`
- `Stat`
- `StatsView`

`StatsManager` creates the stats at runtime and updates them every frame. Each stat starts at `100` and decays over time. Room actions reset related stats back to `100`.

Examples:

- Food restores Hunger.
- Sleeping restores Sleep.
- Computer, basketball, DIY, crossfit, and similar activities restore Play/Fun.

`StatsView` connects each stat to its UI slider and warning color.

---

## Needs System

The needs system handles extra care alerts that are not part of the three main bars.

Main classes and assets:

- `NeedsSystem`
- `NeedsSO`
- `NeedsNotificatonBath`
- `caca.asset`
- `ducha.asset`

Current needs include:

- Bathroom need (`caca`)
- Shower need (`ducha`)

These alerts are triggered after repeated actions and are shown as icons in the UI. They are removed when the player uses the correct room action.

---

## Quest System

The quest system drives progression.

Main classes:

- `QuestManager`
- `Quest`
- `QuestInfoSO`
- `QuestStep`
- `QuestPoint`
- `QuestState`
- `QuestEvents`
- `GameEventsManager`

Quest data is stored as `QuestInfoSO` assets inside:

```text
Assets/Resources/Quests
```

Each quest can define:

- `id`
- `displayName`
- `levelRequirement`
- `questPrerequisites`
- `questStepPrefabs`

At runtime, `QuestManager` loads all quests with:

```csharp
Resources.LoadAll<QuestInfoSO>("Quests")
```

Quest flow:

1. `QuestManager` loads quest assets into a dictionary.
2. `QuestPoint` listens for quest state changes.
3. When requirements are met, a quest becomes available.
4. The player starts the quest through the UI.
5. A quest step prefab is instantiated.
6. The quest step waits for the required action.
7. When the action is done, the quest advances.
8. Completed quests add experience toward the current growth phase.

This makes quest content mostly data-driven while keeping each objective simple.

---

## Room System

Rooms define where actions are available.

Main classes:

- `RoomsManager`
- `Rooms`

Current rooms:

- Kitchen
- Lab
- Bath
- Dorm
- Entrance

`RoomsManager` changes the active room panel, background color, and room label. It also supports adding room names at runtime when a phase unlocks more content.

---

## UI System

The UI is managed mainly through:

- `UIManager`
- `CanvasComponent`
- `ButtonControl`
- `StatsView`

`CanvasComponent` works as a central reference holder for buttons, panels, sliders, room objects, and quest UI elements.

`UIManager` handles:

- Initial UI visibility.
- Quest panel open/close.
- Global pause toggle.
- Birthday/growth button.
- Removing need alerts after the player responds.
- Global action cooldown interaction state.

`ButtonControl` handles pointer down/up state and a shared action cooldown.

---

## Notification System

Main class:

- `Notifications`

There are two notification types:

- UI text notifications, stored in a `Queue<string>`.
- Need notifications, stored in a list and shown as icons.

Text notifications are used for general events, such as quest completion or growth messages. Need notifications are used for care alerts like bathroom and shower.

---

## Current Limitations

- There is no documented save/load system yet.
- Some systems rely on direct scene references and `GameObject.Find`.
- The global cooldown is shared by all action buttons.
- Quest steps are simple and action-specific.
- The project is focused on prototype architecture, not final production polish.
