# ProjectJ40
This project is an early-stage life simulation game where the player takes care of a baby character whose needs change over time.  
The main goal at this stage is to design and test **core gameplay systems** before adding polish, content, or final art.

---

# Project Overview

```mermaid
flowchart TD
    PlayerInput[Player_Input]
    ActivitySys[Activity_System]
    NeedsSys[Needs_System]
    QuestSys[Quest_System]
    GrowthSys[Growth_System_FSM]
    Threshold[Threshold_Effects]
    UI[UI_Feedback]

    PlayerInput --> ActivitySys
    ActivitySys --> NeedsSys
    ActivitySys --> QuestSys
    QuestSys --> GrowthSys
    NeedsSys --> Threshold
    Threshold --> UI


```
---
## Current Development Focus
- **Needs System**: Tracks hunger, sleep, happiness, and other metrics.
- **Character Growth**: Baby evolves visually and mechanically over time.
- **Player Interaction**: Feeding, playing, and attending the baby’s needs.
- **Modular Architecture**: Core systems designed to scale as the game grows.

---

## Media

<!---[![Needs System GIF](media/needs.gif)](https://www.youtube.com/watch?v=VIDEO_ID)--->
<!---Shows the placeholder UI to control de stats, currently developing the needs system.--->
Shows early system for hunger, energy, and happiness with a quest system<br>


<!---
### Screenshots
<!---<img src="media/screenshot_01.jpg" width="900">
<img src="media/screenshot_02.jpg" width="900">--->
![GameplayQuets-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/ac27f399-52fb-4086-9d82-9bb6b3730f41)

---
## Playable Build

A playable WebGL build is available on itch.io for testing and iteration purposes.

👉 Play it here: https://yourname.itch.io/project-name

---

## Platform & Controls

The project currently runs as a WebGL build on itch.io.  
It is primarily designed for mobile devices using touch-based interaction.

---

## Project Status

Early prototype / WIP focused on building and testing core gameplay systems.

> ⚠️ This build is an early prototype and may contain bugs or incomplete features.
## Technology
- Engine: Unity
- Language: C#
- Input: Unity Input System
- Target Platform: WebGL (itch.io)
- Primary Device: Mobile

<!---
## Assets & Credits
Some third-party assets used in this project are licensed under **Creative Commons CC0** (public domain).  
These assets are used for **prototyping purposes only**.--->

---

## License
All rights reserved.

This project and its contents are proprietary and may not be used, copied, modified, or distributed without explicit permission from the author.
