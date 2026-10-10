# Cosmic Dash: 3D Endless Runner

A 3D endless runner built in Unity. The player runs through a space themed track, switches between three lanes, jumps over obstacles, and tries to beat their high score as the speed keeps increasing.

## Demo
[Watch the gameplay video](cosmic_dash_gameplay.mp4)

## Features
- Three lane movement with smooth lane switching
- Jumping with Rigidbody physics
- Endless track built from tiles that spawn ahead of the player and are removed behind
- Randomly placed obstacles with at least one safe lane on every tile
- Speed that increases over time up to a maximum
- Score based on distance and speed, with a high score saved between sessions
- Main menu and game over screens built with TextMeshPro
- Smooth follow camera

## Controls
- A / D or Left / Right arrow: switch lane
- Space or Up arrow: jump

## Project Structure
- `Assets/Scripts/PlayerController.cs`: forward movement, lane switching, jumping, and collisions
- `Assets/Scripts/TrackGenerator.cs`: spawns and removes track tiles and obstacles
- `Assets/Scripts/GameManager.cs`: speed, score, high score, and menu screens
- `Assets/Scripts/CameraFollow.cs`: smooth camera that follows the player
- `Packages/manifest.json`: Unity packages used by the project

## Built With
Unity 2022.3 LTS, C#, TextMeshPro

## Note
This repository contains the scripts and a gameplay video. The full Unity project is not included because of file size limits.
