# Godot 引擎介绍

## 1. Godot 引擎特点

### 1.1 简介

### 1.2 优点

### 1.3 缺点

### 1.4 什么项目适合选择Godot作为开发引擎

## 2. Godot 两种语言对比

## 3. Godot C# 版本底层架构

### 3.1 现行版本架构简介

### 3.2 godot 4 的 C# 版本中，同时采用了 mono 和 .net 6 的库，他们之间的关系是怎样的？

Godot 4 的 C# 版本中同时采用了 Mono 和 .NET 6 的库，这可能会让一些开发者感到困惑。以下解释一下它们之间的关系：

1. Godot 4 的核心仍然使用 Mono:

Godot 4 的核心引擎仍然使用 Mono 运行时。这意味着引擎的基本功能和数据结构都是基于 Mono 实现的。这与 Godot 3 使用 Mono 相同。

2. .NET 6 库用于 C# 语言支持:

Godot 4 在 C# 语言支持方面引入了一些重大变化。主要变化之一是使用了 .NET 6 的 BCL（Base Class Library）和 API。这意味着 C# 开发人员可以使用 .NET 6 中的大量标准库和 API 来编写 Godot 游戏。

3. Mono 和 .NET 6 的兼容性:

.NET 6 在设计时考虑到了与 Mono 的兼容性。这意味着大多数 Mono 库都可以与 .NET 6 一起使用。Godot 团队利用了这一点，并在 Godot 4 中包含了一些额外的 Mono 库。

4. 混合使用 Mono 和 .NET 6 库的好处:

这种混合使用 Mono 和 .NET 6 库的方式具有一些优点：

* 它允许 Godot 利用 Mono 的成熟性和稳定性，同时又可以使用 .NET 6 的最新功能和 API。
* 它为 C# 开发人员提供了更广泛的选择，使他们可以选择最适合他们需求的库。
* 它有助于确保 Godot 在多个平台上的一致性，包括那些已经使用 Mono 的平台。

5. 需要注意的事项:

并非所有 Mono 库都与 .NET 6 完全兼容。在使用 Mono 库时，开发人员需要谨慎测试并注意潜在的兼容性问题。

Godot 4 的 C# API 仍然主要基于 Mono。这意味着开发人员在使用 .NET 6 API 时需要注意一些差异。

总而言之，Godot 4 中 C# 版本的 Mono 和 .NET 6 库是相互补充的。

Mono 提供了核心引擎功能和稳定性，而 .NET 6 提供了最新的 C# 语言支持和丰富的标准库。

这种混合使用方式使 Godot 能够为 C# 开发人员提供更强大、更灵活的开发平台。


> 参考资料：
>
> 关于 Godot 4 中 C# 开发的信息：https://docs.godotengine.org/en/stable/tutorials/scripting/c_sharp/index.html