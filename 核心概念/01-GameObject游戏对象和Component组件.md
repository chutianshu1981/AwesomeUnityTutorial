# GameObject 游戏对象和 Component 组件

> - [官方教程-基本概念](https://learn.unity.com/tutorial/essential-unity-concepts?language=en&courseId=5d532306edbc2a1334dd9aa8)
>
> * [官方文档-游戏对象](https://docs.unity.cn/cn/2021.1/Manual/GameObjects.html)

场景 scene 包含 游戏对象 game object ， 游戏对象 gameobject 包含 组件 component

## 1. GameObject 游戏对象

在文档中，被称为“最重要的概念”，原因也很简单，即“万物皆对象”

Unity 中，游戏由场景组成，而场景中的任何元素，都是游戏对象

游戏对象是 Unity 中的基础对象，表示角色、道具和景物。它们本身并没有取得多大作为，但它们充当**组件**的容器，而组件可实现功能。

游戏对象始终附加一个变换组件（表示位置和方向），并且无法删除此组件。

## 2. Component 组件

组件定义了包含它们的游戏对象的行为，是每个**游戏对象**的功能单元。

## 3. Transform 变换组件

Transform 变换组件用于存储游戏对象的位置、旋转、缩放和父子化状态，因此非常重要。游戏对象始终附加一个变换组件，无法删除变换组件或创建没有变换组件的游戏对象。

变换组件的位置、旋转和缩放值是相对于变换组件的父项测量的。如果变换组件没有父项，则按照世界空间来测量属性。

Inspector 中任何子游戏对象的 Transform 值都是相对于父项 Transform 值显示的结果。这些值称为“局部坐标”

## 4. 静态游戏对象

如果游戏对象在运行时未移动，则被称为静态游戏对象。如果游戏对象在运行时移动，则被称为动态游戏对象。

Unity 中的许多系统都可以在 Editor 中预计算有关静态游戏对象的信息。由于静态游戏对象不会移动，因此这些计算的结果在运行时仍然有效。

所以，恰当地使用静态游戏对象可以节省运行时计算成本，并可能提高性能。

<br>
<hr>
<br>

配套视频教程：
[https://space.bilibili.com/43644141/channel/seriesdetail?sid=299912](https://space.bilibili.com/43644141/channel/seriesdetail?sid=299912)

文章也同时同步微信公众号，喜欢使用手机观看文章的可以关注

![](../imgs/微信公众号二维码.jpg)
