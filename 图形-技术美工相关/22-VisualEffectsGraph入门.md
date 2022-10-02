# Visual effect Graph 入门

## 1. 什么是 Visual effect Graph

Visual effect Graph 是 Unity 推出的新型特效系统，通过可视化编程来创建，通过 Gpu 来进行运算，可以实现百万级粒子的特效。

新旧两种特效系统区别：

![](../imgs/vfx_diff.png)

## 2. 核心概念

### 系统 System

每个系统实际上就是一个子特效。由虚线轮廓保围，并包含一系列上下文子系统

### Context 上下文

上下文是系统中定义处理阶段的部分。上下文连接在一起以定义一个系统。是用来确定粒子如何产生和模拟的核心功能模块。

视觉效果图中最常见的四个上下文是：

1. spawn 生成：如果激活，Unity 会在每一帧调用它，并计算要生成的粒子数量。
2. initialize 初始化： Unity 在每个粒子的“诞生”时称其为，这定义了粒子的初始状态。
3. update 更新：Unity 对所有粒子的每一帧都调用它，并使用它来执行模拟，例如力和碰撞。
4. output 输出：Unity 对每个粒子的每一帧都调用它。这决定了粒子的形状，并执行预渲染转换。

* 注意：某些上下文（例如输出网格 Mesh Output System）不连接到任何其他上下文，因为它们与其他系统无关。

![](../imgs/SystemVisual.png)

### Block 块

块是可以堆叠到上下文中的节点。每个 Block 负责一个操作。例如，它可以对速度施加力、与球体碰撞或设置随机颜色。

当你创建一个块时，你可以在它当前的上下文中重新排序它，或者将它移动到另一个兼容的上下文中。

## 3. Context 上下文

上下文可以：

* 计算效果产生的粒子数
* 创建新粒子
* 更新所有活粒子
* 输出并绘制粒子

上下文具体有下面几种：

### Event 事件上下文

事件定义了视觉效果图处理工作流的输入，事件上下文只显示它们的名称，它是一个字符串。

要触发事件上下文并从中激活工作流，需要在脚本中用组件 API 代码，调用用事件上下文的名称。

简单说来，就是用代码控制特效的入口，通过字符串作为事件名称来匹配

通过事件，VFX Graph 可以：

* 开始和停止生成粒子。
* 读取从 C# 脚本发送的事件属性值。

![](../imgs/EventContexts.png)

两个默认事件：

* OnPlay：启用粒子的生成
* OnStop：禁用粒子的生成

### Spawn 生成上下文

和它的名称意义相同，就是用来生成粒子的，其中可以添加不同的块 block ，来实现不同的生成方式

### GPU Event  Gpu 事件上下文

GPU 事件上下文是实验性上下文，它将输入连接到来自其他系统的输出 GPU 事件。

它们允许您基于其他粒子生成粒子。

要启用此选项，请启用Visual Effect Preferences中的Experimental Operators/Blocks复选框。

![](../imgs/GPUEvent.png)

其实就是用来链接前一个子特效中的 GPU 事件，作为当前子特效激活条件。例如，前一个特效中的粒子死亡时，激活当前特效系统

以下更新块可以发送 GPU 事件数据：

* 死亡触发事件：当一个粒子死亡时，在另一个系统上生成 N 个粒子。
* 触发事件率：每秒（或每行进距离）产生 N 个粒子，基于来自系统的粒子。
* 始终触发事件：每帧生成 N 个粒子。

### Initialize 初始化上下文

Initialize Contexts 根据SpawnEvent数据生成新粒子，Unity 从 Event、Spawn Contexts 或 GPU Event Contexts 计算这些数据。

例如：如果 Spawn Context 声明效果应该创建 200 个新粒子，则 Initialize Context 会为所有 200 个新粒子处理其块。

### Update 更新上下文

更新上下文根据粒子数据更新系统中的所有有效粒子，粒子数据由 Unity 从初始化和更新上下文计算。

Unity 执行更新上下文，从而更新每个粒子、每个帧。

粒子更新上下文还自动处理粒子的一些计算，以简化常见的编辑任务。

更新上下文常见功能块：

* 更新位置：指定 Unity 是否将速度积分应用于粒子。启用后，Unity 将简单的欧拉速度积分应用于每帧每个粒子的位置。禁用时，Unity 不会应用任何速度积分。
* 更新旋转： 指定 Unity 是否对粒子应用角度积分。启用后，Unity 将简单的欧拉积分应用于每个粒子的每帧旋转。禁用时，Unity 不会应用任何角度积分。
* Age Particles：如果 Context 使用 Age 属性，这将控制 Update Context 是否使粒子随时间老化。
* Reap Particles：如果 Context 使用 Age 和 Lifetime 属性，这将控制 Update Context 在粒子的年龄大于其生命周期时是否移除粒子。


### Output 输出上下文

输出上下文渲染系统中的粒子。它们根据来自同一系统中初始化和更新上下文的粒子数据，以不同的模式和设置渲染粒子。然后它将配置呈现为特定的形状。

实际上就是控制最终粒子外观，如何被渲染的功能模块

> 参考资料：
>
> Vfx Graph 官方文档：https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@15.0/manual/sample-content.html  
>
> Unity VFX Graph Sample: https://github.com/Unity-Technologies/VisualEffectGraph-Samples ， 配套文章 ：https://blog.unity.com/technology/visual-effect-graph-samples
> 
> Unity HDRP VFX Graph 示例：https://github.com/Unity-Technologies/SpaceshipDemo
> 
> VFX Graph youtube 教程：
> * https://www.youtube.com/watch?v=7bMOhNUA1bI&list=PLpPd_BKEUoYhN8CiOoNLTSVh-7U5yjg3n

