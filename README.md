# BackInTimeMVC 🎮

[![Unity](https://img.shields.io/badge/Unity-2021.3.0f1-black.svg)](https://unity.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](http://makeapullrequest.com)

A Unity-based educational project demonstrating the Model-View-Controller (MVC) architectural pattern through an interactive board game implementation.

## 📋 Table of Contents

- [About](#-about)
- [Features](#-features)
- [Architecture](#-architecture)
- [Prerequisites](#-prerequisites)
- [Installation](#-installation)
- [Usage](#-usage)
- [Game Mechanics](#-game-mechanics)
- [Project Structure](#-project-structure)
- [Contributing](#-contributing)
- [License](#-license)
- [Contact](#-contact)

## 📖 About

BackInTimeMVC is an educational Unity project that implements a turn-based board game while strictly adhering to the Model-View-Controller (MVC) architectural pattern. The game features players navigating through a mathematically-generated spiral tile system, encountering various special rules that affect gameplay progression.

This project serves as a practical example of software architecture principles in game development, showcasing clean code organization and separation of concerns.

## ✨ Features

- **🏗️ MVC Architecture**: Complete implementation of Model-View-Controller pattern
- **🔄 Spiral Board Generation**: Mathematical algorithm for dynamic tile placement
- **👥 Multiplayer Support**: 1-6 player simultaneous gameplay
- **🎲 Turn-Based Mechanics**: Sequential player turns with dice-based movement
- **⚙️ Dynamic Rule System**: Real-time tile rule modification
- **🎨 Visual Feedback**: Color-coded players and interactive UI
- **📝 Rule Editor**: In-game tile behavior customization

## 🏗️ Architecture

The project demonstrates proper MVC separation of concerns:

### Model Layer
Handles data and business logic:
- `Model.cs` - Main game state management
- `PlayerModel.cs` - Player data and behavior
- `TileModel.cs` - Tile system and board structure
- `TileClasses.cs` - Core geometry and tile classes

### View Layer
Manages presentation and user interface:
- `View.cs` - Main UI coordination
- `PlayerView.cs` - Player visual representation
- `TileView.cs` - Tile rendering and spiral visualization

### Controller Layer
Orchestrates interaction between Model and View:
- `Controller.cs` - Game flow coordination
- `PlayerController.cs` - Player movement logic
- `TileController.cs` - Tile creation and management

## 📋 Prerequisites

- **Unity Editor**: Version 2021.3.0f1 or later
- **TextMesh Pro**: Included in project dependencies
- **Operating System**: Windows, macOS, or Linux

## 🚀 Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/sfragkiadakhs/BackInTimeMVC.git
   cd BackInTimeMVC
   ```

2. **Open in Unity**:
   - Launch Unity Hub
   - Add the project folder
   - Open with Unity 2021.3.0f1 or later

3. **Load the Scene**:
   - Navigate to `Assets/Scenes/`
   - Open `SampleScene.unity`

4. **Run the Game**:
   - Press the Play button in Unity Editor
   - Or build for your target platform

## 🎯 Usage

### Starting a Game
1. Launch the application
2. Click "Start Game" from the main menu
3. The game initializes with default settings (6 players, 20 tiles)

### Gameplay Controls
- **SPACEBAR**: Roll dice and move current player
- **Mouse**: Interact with UI elements and tiles
- **Rule Panel**: Modify tile behaviors during gameplay

### Rule System
Tiles can have special effects:
- **Numeric Values**: Move player forward/backward by specified tiles
- **"stop"**: Player loses their next turn
- **"extra"**: Player gains an immediate extra turn
- **No Rule**: Standard tile with no special effect

## 🎮 Game Mechanics

### Movement System
- Players roll virtual dice (1-6) each turn
- Movement follows the spiral tile progression
- Position validation prevents board overshooting

### Player Management
- Support for 1-6 simultaneous players
- Unique color coding for visual distinction
- Automatic turn queue cycling

### Win Condition
- First player to reach the final tile wins
- Position tracking throughout gameplay

## 📁 Project Structure

```
BackInTimeMVC/
├── Assets/
│   ├── Scripts/
│   │   ├── Application.cs          # Main application entry point
│   │   ├── Model.cs               # Game state model
│   │   ├── View.cs                # UI view management
│   │   ├── Controller.cs          # Game logic controller
│   │   ├── PlayerModel.cs         # Player data model
│   │   ├── PlayerView.cs          # Player visualization
│   │   ├── PlayerController.cs    # Player movement logic
│   │   ├── TileModel.cs           # Tile data model
│   │   ├── TileView.cs            # Tile rendering
│   │   ├── TileController.cs      # Tile creation logic
│   │   ├── TileClasses.cs         # Core tile geometry
│   │   ├── ApplyForm.cs           # Rule editing system
│   │   ├── ClickTile.cs           # Tile interaction
│   │   └── OptionsSelected.cs     # UI option handling
│   ├── Scenes/
│   │   └── SampleScene.unity      # Main game scene
│   ├── Materials/                 # Game materials
│   └── TextMesh Pro/              # UI text assets
├── Packages/                      # Unity package dependencies
├── ProjectSettings/               # Unity project configuration
└── README.md                      # Project documentation
```

## 🤝 Contributing

We welcome contributions that enhance the educational value or improve the architecture! This project serves as a learning resource for MVC implementation in Unity.

### Development Guidelines

1. **MVC Separation**: Maintain clear separation between Model, View, and Controller layers
2. **Code Quality**: Follow Unity best practices and C# conventions
3. **Documentation**: Add comments for complex algorithms and architectural decisions
4. **Testing**: Thoroughly test gameplay mechanics and UI interactions

### How to Contribute

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 📞 Contact

**Sfragkiadakhs**
- GitHub: [@sfragkiadakhs](https://github.com/sfragkiadakhs)
- Project Repository: [BackInTimeMVC](https://github.com/sfragkiadakhs/BackInTimeMVC)

---

**Educational Note**: This project is designed primarily as a learning resource for software architecture patterns in game development. The gameplay mechanics demonstrate MVC principles rather than providing a complete commercial gaming experience.