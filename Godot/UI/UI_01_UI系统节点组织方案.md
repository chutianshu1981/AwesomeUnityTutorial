# UI系统节点组织方案-UI系列01

## 1. 基本原则

1. 使用 Control 节点作为根节点：
   
   所有 UI 元素应该放在 Control 节点的子节点中。Control 节点是 Godot 中所有 UI 元素的基类，提供了布局和对齐功能。

2. 分层次组织：
   
   根据 UI 元素的功能和用途，将它们分层次组织。例如，将所有主菜单元素放在一个容器中，将所有游戏内 HUD 元素放在另一个容器中。

3. 使用 Container 节点进行布局：
   
   Godot 提供了多种容器节点（如 VBoxContainer、HBoxContainer、GridContainer 等），用于自动排列和管理子节点。使用容器节点可以简化布局管理。

4. 使用 CanvasLayer 节点管理不同的 UI 层：
   
   例如，HUD 和菜单可以放在不同的 CanvasLayer 中，这样可以确保它们在不同的渲染层次，不会相互影响。

5. 模块化设计：
   
   将复杂的 UI 组件拆分为多个独立的场景，使用实例化的方式在主场景中组合。这有助于管理和复用 UI 组件。

## 2. 示例项目结构

MainUI (Control)
├── CanvasLayer (CanvasLayer)
│   ├── MainMenu (VBoxContainer)
│   │   ├── Title (Label)
│   │   ├── StartButton (Button)
│   │   ├── OptionsButton (Button)
│   │   └── QuitButton (Button)
│   ├── OptionsMenu (VBoxContainer)
│   │   ├── VolumeLabel (Label)
│   │   ├── VolumeSlider (HSlider)
│   │   ├── BackButton (Button)
│   ├── HUD (Control)
│   │   ├── ScoreLabel (Label)
│   │   ├── HealthBar (TextureProgress)
│   └── Dialogs (Control)
│       ├── PauseMenu (VBoxContainer)
│       │   ├── ResumeButton (Button)
│       │   ├── SettingsButton (Button)
│       │   ├── MainMenuButton (Button)
│       └── ConfirmDialog (AcceptDialog)
