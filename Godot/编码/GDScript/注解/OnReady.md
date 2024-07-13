# OnReady 注解

## 1. 概念

@onready() 

标记后续属性会在 Node 就绪时赋值。节点初始化（Object._init）时不会立即对这些属性赋值，而是会在即将调用 Node._ready 之前进行计算与储存。
```gdscript
@onready var character_name: Label = $Label
```
在 Godot 4 中，`@onready` 关键字用于声明一个变量，该变量将在节点进入场景树时进行初始化。这意味着变量的初始化将推迟到 `_ready()` 函数调用之前，但在节点及其子节点已经被添加到场景树之后。

### `@onready` 的原理

当节点添加到场景树并准备好后，Godot 会调用该节点的 `_ready()` 方法。在此之前，`@onready` 关键字标记的变量会被初始化。这确保了在变量初始化时，所有的子节点都已存在并且可以被访问。

### 使用 `@onready` 的好处

1. **简洁和易读**：使用 `@onready` 可以减少代码量，使代码更简洁。例如，无需在 `_ready()` 函数中查找节点并赋值。
2. **避免空指针错误**：因为 `@onready` 确保变量在节点准备好之后才初始化，所以可以避免在 `_ready()` 之前访问未初始化的节点。
3. **方便调试**：通过将节点查找逻辑和变量声明放在一起，可以更容易地理解代码的结构和逻辑。

### 如何使用 `@onready`

以下是一些示例代码，展示了如何在 Godot 4 中使用 `@onready` 关键字：

#### 示例 1：基本用法

```gdscript
extends Node2D

# 使用 @onready 初始化变量
@onready var player = $Player
@onready var enemy = $Enemy

func _ready() -> void:
    # 在 _ready() 中可以安全地使用这些变量
    player.start()
    enemy.start()
```

#### 示例 2：与其他属性一起使用

```gdscript
extends Node2D

@export var health: int = 100
@onready var health_bar = $HealthBar

func _ready() -> void:
    # 使用 @onready 变量和导出变量
    health_bar.value = health
```

#### 示例 3：在更复杂的场景中使用

```gdscript
extends Control

@onready var start_button = $StartButton
@onready var settings_button = $SettingsButton
@onready var quit_button = $QuitButton

func _ready() -> void:
    # 连接按钮的信号
    start_button.connect("pressed", self, "_on_start_button_pressed")
    settings_button.connect("pressed", self, "_on_settings_button_pressed")
    quit_button.connect("pressed", self, "_on_quit_button_pressed")

func _on_start_button_pressed() -> void:
    print("Start button pressed")

func _on_settings_button_pressed() -> void:
    print("Settings button pressed")

func _on_quit_button_pressed() -> void:
    get_tree().quit()
```

### `@onready` 变量的初始化顺序

`@onready` 变量的初始化在 `_ready()` 方法调用之前，但在节点及其所有子节点已加入场景树之后。这样确保了在 `@onready` 变量初始化时，可以访问这些节点。

### 总结

- `@onready` 关键字用于在节点准备好后初始化变量，确保所有子节点已经存在。
- 它简化了代码，避免了空指针错误，并提高了代码可读性。
- 使用方法是将 `@onready` 关键字放在变量声明前。

通过使用 `@onready` 关键字，您可以更高效地管理节点和子节点的初始化，使代码更简洁和健壮。