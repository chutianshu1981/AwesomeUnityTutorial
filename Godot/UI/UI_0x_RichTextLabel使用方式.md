# RichTextLabel 使用方式-UI系列0x

> 在 Godot 4 中，你可以使用 `RichTextLabel` 和 BBCode 来实现左侧显示图标、右侧显示文本的效果。以下是详细的操作步骤：

### 步骤 1：启用 BBCode

1. **添加 `RichTextLabel` 节点**：
   - 在场景树中选择你的根节点（例如 `Control`）。
   - 右键点击选择 "Add Child Node"，添加一个 `RichTextLabel`。

2. **启用 BBCode**：
   - 选择 `RichTextLabel` 节点。
   - 在 `Inspector` 面板中，勾选 `Bbcode Enabled`。

### 步骤 2：使用 BBCode 设置图标和文本

你可以使用 BBCode 标签在 `RichTextLabel` 中嵌入图标和文本。以下是一个使用 FontAwesome 图标库的示例。

#### 1. **下载和安装 FontAwesome 字体**

- 从 [FontAwesome 官方网站](https://fontawesome.com/) 下载字体文件（.ttf 格式）。
- 将字体文件添加到你的 Godot 项目中，例如 `res://fonts/fontawesome-webfont.ttf`。

#### 2. **创建 `DynamicFont` 资源**

- 在 Godot 编辑器中，右键点击资源管理器，选择 "New Resource"。
- 选择 `DynamicFont` 并创建一个新的资源，命名为 `FontAwesome.tres`。
- 打开 `FontAwesome.tres` 资源，在 `Inspector` 面板中设置 `Font` 属性为下载的 FontAwesome 字体文件。

#### 3. **设置 `RichTextLabel` 的 BBCode**

- 选择 `RichTextLabel` 节点，在 `Inspector` 面板中找到 `Custom Fonts`，添加 `FontAwesome.tres` 到 `Custom Fonts`。
- 在 `Bbcode Text` 属性中，设置图标和文本。

### 示例代码

#### 示例项目结构

```plaintext
MainScene (Control)
└── RichTextLabel (RichTextLabel)
```

#### 示例 BBCode 设置

1. **设置自定义字体**

```gdscript
extends Control

func _ready():
    var rich_text_label = $RichTextLabel
    var dynamic_font = DynamicFont.new()
    dynamic_font.font_data = load("res://fonts/fontawesome-webfont.ttf")
    dynamic_font.size = 24  # 设置字体大小

    rich_text_label.add_font_override("normal_font", dynamic_font)
    rich_text_label.bbcode_enabled = true
    rich_text_label.bbcode_text = "[font=normal_font][color=#000000][img=16x16]res://path_to_your_icon.png[/img][/color] Your text here[/font]"
```

在上面的代码中：
- `[img=16x16]res://path_to_your_icon.png[/img]` 用于在文本中嵌入图标，`res://path_to_your_icon.png` 是图标的路径。
- `Your text here` 是显示的文本内容。
- `font=normal_font` 确保文本使用我们定义的 `DynamicFont`。

### 注意事项

1. **图标路径**：
   - 确保图标路径正确，并且图标文件存在于项目中。

2. **字体大小**：
   - 根据需要调整 `DynamicFont` 的字体大小，以确保图标和文本在视觉上协调。

### 总结

通过使用 `RichTextLabel` 的 BBCode 功能，可以在 Godot 4 中轻松实现左侧显示图标、右侧显示文本的效果。以上步骤详细说明了如何启用 BBCode、下载和安装 FontAwesome 字体、创建 `DynamicFont` 资源以及设置 `RichTextLabel` 的 BBCode。希望这些步骤能够帮助你实现所需的界面设计。