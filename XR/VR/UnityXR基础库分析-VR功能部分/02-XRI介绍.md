# Unity XR Interaction Toolkit 交互工具包

## 1. 概念

XR Interaction Toolkit包是一个基于组件的高级交互系统，用于创建VR和AR体验。

它提供了一个框架，通过Unity输入事件使3D和UI交互可用。

该系统的核心是一组基本的 Interactor 和 Interactable 组件，以及将这两种类型的组件联系在一起的 Interaction Manager。

它还包含一些用于移动和绘制视觉效果的组件。

### XR Interaction Toolkit包含一组支持以下交互任务的组件：

* 跨平台XR控制器输入：Meta Quest（Oculus）、OpenXR、Windows Mixed Reality等。
* 基本的对象悬停、选择和抓取
* 通过XR控制器提供触觉反馈
* 通过视觉反馈（着色/线条渲染）指示可能和活动的交互
* 使用XR控制器进行基本画布UI交互
* 与XR Origin进行交互的实用工具，用于处理固定和房间尺度的VR体验的VR相机设置

### 要在包中使用AR交互组件，您必须在项目中安装AR Foundation包。XR Interaction Toolkit提供的AR功能包括：

* AR手势系统将屏幕触摸映射到手势事件
* AR可交互组件可以在现实世界中放置虚拟对象
* AR手势交互器和可交互组件将手势（例如放置、选择、平移、旋转和缩放）转换为对象操作
* AR注释用于向用户提供有关放置在现实世界中的AR对象的信息

最后，如果您没有适用于您当前项目的硬件，或者只想在不戴头盔的情况下测试交互，您可以使用XR设备模拟器模拟所有交互。有关更多信息，请参阅XR设备模拟器概述。