# @export 注解

## 1. 概述

GDScript 中，也存在类似于 java 中的 @ 注解相关功能

@export 专门用于将 GDScript 代码中的字段暴露在检查器中

## 2. 常用导出注解

### 2.1 视觉分组用

### @export_category(name: String) 

在 **检查器** 中新增一个根分类，这种根分类不可折叠，也不能放入别的分类中

通常他就是其他 @export 的容器，除了分组，提供类别名称等视觉上的功能外，没有任何实际功能，它本身并不能暴露任何字段

### @export_group(name: String)

在 **检查器** 中新增一个可折叠的组别，需要放入别的 根分类中，

一般写在 @export_category 之后，作为该根分类的一个分组

### @export_subgroup(name: String)

在 **检查器** 中新增一个可折叠的子组别，需要放入别的 组别中，

一般写在 @export_group 之后，作为该组别的一个子组

### 2.2 @export 导出字段

导出代码中的指定字段到 **检查器** 


### 代码示例

```gdscript
extends Control

@export_category("CustomeFields")
@export_group("RootPanel")
@export var rootPanelHeight:int = 200
@export var rootPanelWidth:int = 150
@export_group("Header")
@export var title: String = "Default Title"
@export var icon: Texture
@export var titleHeight:int = 180
@export var titleWidth:int = 20

@export_group("Content")
@export var contentHeight:int = 180
@export var contentWidth:int = 120
@export var content: String = "Default Content"
```

### 2.3 @export_color_no_alpha() 

导出 Color、Array[Color] 或 PackedColorArray 属性，不允许编辑透明度（Color.a）

### 2.4 @export_custom(hint: PropertyHint, hint_string: String, usage: BitField[PropertyUsageFlags] = 6)

为导出的属性设置自定义提示、提示字符串和使用标志。请注意，GDScript 中没有进行验证，它只是将参数传递给编辑器。

### 2.5 @export_dir() 

导出 String、Array[String] 或 PackedStringArray 属性，用作指向目录的路径。

该路径会被限制在项目文件夹及其子文件夹中。要允许在整个文件系统中选取，见 @export_global_dir。

### 2.6 @export_enum(names: String, ...) vararg 

导出 int、String、Array[int]、Array[String]、PackedByteArray、PackedInt32Array、PackedInt64Array 或 PackedStringArray 属性，用作枚举选项列表（或选项的数组）。如果属性为 int，则存储的是值的索引，与值的顺序相同。你可以使用冒号来显式添加枚举项的取值。如果属性为 String，则存储的是值。

<br>
<hr>
<br>

> 参考资料：
>
> [官方文档](https://docs.godotengine.org/zh-cn/4.x/classes/class_%40gdscript.html)
