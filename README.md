# 📜 Ninja Scroll Adventure - Code Repository
- This repository contains the source code and scripts for the [Ninja Scroll Adventure project](#) — a 2D top down action-adventure game.
- This is a remake from scratch of an old but very similar game i made.
- I remade it since I lost the original one i made.
- This repo focuses only on logic and systems — no assets or scene files included here.

# 🛠️ Features
- Modular AttackType system
- Enemy AI with simple state machines (chase, attack, patrol)
- Damage system with immunities by damage type
- Health system for units (player/enemy)
- Basic tutorial system with trigger zones
- Simple menu system (pause, win, game over)
- Particles and visual feedback on events (hit, death, spawn)

# 📈 Planned Improvements
(for future updates)

- Improve general code architecture
- Improve the Attack / AttackType system
- Add new AttackTypes
- Improve the modular enemy ai
- Knockback system
- Expand Interaction system (scrolls, signs, checkpoints)
- Checkpoint system for saving respawn points
- Add new enemies and more varied attacks
- Polish and UX improvements (screenshake, boss UI, etc.)

<!-- # 🧩 Project Structure -->

# 💾 Notes
- Built in Unity 2022.3.61, using the Built-in Render Pipeline.
- Uses Unity Input System.

# 🚀 Getting Started
- Clone this repository.
- Place scripts inside your Unity project's Assets/Scripts/ folder.
- Hook up systems and references(game manager, tutorial triggers, etc.) manually into your Unity scenes.
- Modify and extend systems to fit your own game expansions.
