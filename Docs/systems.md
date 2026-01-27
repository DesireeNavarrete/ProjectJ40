# Systems Overview

This document describes the core gameplay systems of the project and how data flows between them.
The focus at this stage is on defining responsibilities, interactions, and scalability before full implementation.

---
## Needs System

### Purpose
Manages continuous character needs using numeric values rather than discrete states.

### Core Needs
- Hunger
- Sleep
- Play

### Architecture
Each need is implemented as an independent stat with:
- Clamped values (0–100)
- Configurable decay or regeneration rates
- Modifiers applied by player actions

Needs are updated continuously and evaluated through thresholds rather than state transitions.

### Design 
Using continuous values allows multiple needs to evolve simultaneously,
providing smoother gameplay and more flexible balancing compared to a state-based approach.

---

## Player Interaction System

### Purpose
Handles player input and translates it into gameplay actions.

### Core Responsibilities
- Capture player input (touch-based)
- Validate player actions
- Trigger interactions with gameplay systems

<!--### Main Components
- `PlayerInputHandler`
- `InteractionController`-->

### Data Flow
1. Input is received through touch.
2. Input is validated based on current game state.
3. Corresponding interaction is triggered.
4. Gameplay systems (Needs, Character State) are updated accordingly.

---
<!--## Character State System

### Purpose
Maintains the current state of the character and ensures consistency between systems.

### Core Responsibilities
- Store character state (idle, sleeping, interacting, etc.)
- React to needs changes
- Coordinate animations and visual feedback

### Main Components
- `CharacterStateController`
- `CharacterStateData`

### Data Flow
1. Needs System triggers state-related events.
2. Character State System updates the current state.
3. Visual and animation systems are notified.
4. State changes may restrict or enable interactions.

---
-->

## Character Growth System

### Purpose
Controls long-term character progression using a finite state machine (FSM),
ensuring clear transitions and scalable growth stages.

### Core Responsibilities
- Define and manage character growth stages
- Control transitions between stages
- React to long-term needs evaluation
- Persist current growth state

### Architecture
The system is implemented as a **finite state machine**, where each growth stage
represents a distinct state with its own rules and behavior.

### Main Components
- `GrowthStateMachine`
  - Manages current growth state and transitions
- `GrowthIState`
  - Base class/interface for growth stages
<!--- `GrowthStageData`
  - Configuration data for each stage (thresholds, conditions)-->

### Data Flow
1. The Needs System periodically provides aggregated data.
2. Growth conditions are evaluated by the state machine.
3. If conditions are met, a state transition is triggered.
4. The current growth state is updated.
5. Character visuals and available interactions are refreshed.

### Benefits
- Clear separation between growth stages
- Easy to add or modify stages without affecting existing logic
- Predictable and controlled state transitions


---
## UI System

### Purpose
Provides feedback to the player about character status and interactions.

### Core Responsibilities
- Display current needs values
- Show visual feedback for state changes
- Reflect player actions immediately

<!--### Main Components
- `NeedsUI`
- `FeedbackUI`-->

### Data Flow
1. UI subscribes to events from Needs and Character State systems.
2. UI elements update when values or states change.
3. Player feedback is displayed in real time.

---
<!--## Save System (Planned)

### Purpose
Persist core gameplay data between sessions.

### Core Responsibilities
- Save needs values
- Save growth stage and character state
- Load data at startup

### Status
Planned for future iteration once core systems stabilize.

---
-->
## System Relationships Summary

- **Needs System** is the central driver of gameplay.
- **Player Interaction System** modifies needs and states.
<!--- **Character State System** ensures consistency and control flow.-->
- **Growth System** evaluates long-term progression.
- **UI System** reflects system state to the player.

---
Future iterations may explore hierarchical states if growth complexity increases.


## Notes

This document represents the current design during pre-production.
System responsibilities and data flow may evolve as gameplay is tested and iterated.
