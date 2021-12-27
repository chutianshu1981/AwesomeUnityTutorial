# Shader Editor 简介

## 1. Shader Editor

Shader 着色过程，是整个渲染管线中的一个阶段。

Shader 着色器可视化编辑器，用来编辑各个 Node，组成着色流程逻辑，由 blender 最终转化成可以执行的 Shader 程序。

### 1.1 Object & slot & Material 关系

slot 中，存储的是 Material 到 对象上的 Link 关系。

一个对象，可以通过 不同的 Slot 把多个不同的 Material 挂接到对象表面的不同区域

一个 Material 也可以挂接到不同的对象上

一个对象，可以有多个不同的 Slot，Slot 属于具体的对象；而 Material 是独立的数据集，可以挂接到多个不同的对象，可以重复使用。

删除对象后，它所拥有的 Slot 就不再存在；而在一个对象上删除 Material ，只是删除关联， Material 本身还存在，可以继续使用，除非直接删除 Material 文件。

## 2. Shader Node

Shader Node 泛指 Shader Editor 中的任意节点 Node ，一个 Node 就是一个矩形面板，在其中可以根据其功能进行各种配置，相当于 Shader 编程中的一个逻辑单元

### 2.1 关键概念

- 着色器流程：指的是整个 Shader Editor 中编辑好的一整个着色逻辑，即选中物体的着色方案
- 输入、输出接口：也可以称为节点接口，即节点上的圆点，左侧为输入，右侧为输出，不同颜色代表不同类型，即接口传输的数据类型

### 2.2 节点分类

Shader Editor 中的节点有很多种类，分别承担不同的功能

![](../../imgs/shander_node_type.png)

## 3. Shader 基本操作流程

1. 选择图形对象，通过 slot 添加材质或挂接材质
2. 整个 Shader 操作的核心资源是 Material ，需要配置好材质，比如设置纹理、配置颜色等
3. 灵活使用各种节点，设计 Shader 流程，将设置好的材质最终输出给对象，用于渲染展示
