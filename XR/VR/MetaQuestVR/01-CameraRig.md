# CameraRig 预制件

> OVRCameraRig 是快速开发 Quest 应用时，必不可少的一个预制件，其中包含 Oculus VR 硬件所需的基本必要游戏对象

## 1. OVRCameraRig 预制件

OVRCameraRig 预制件包含 OVRCameraRig.cs 组件和 OVRManager.cs ，前者用来设定摄像头，后者用来驱动 VR 硬件

OVRCameraRig 作为整个预制件的父对象，其中还包含多个子对象，分别负责不同的功能

## 2. OVRCameraRig 组件

OVRCameraRig 组件是挂接在 OVRCameraRig 预制件父对象上的一个组件。

是一个控制立体渲染和头部跟踪的组件。

它在左眼和右眼的位置维护两个锚点，以及位于它们中间的虚拟中心眼，也是一个锚点。它是 Unity 与摄像机之间的主要接口

默认的三个眼睛锚点，都挂接有 Camera 对象，但只有中间的虚拟中心眼上的才是开启的。你也可以关闭中间的摄像头，让双眼用各自的摄像头，这需要开启 OVRCameraRig 组件上的 Use Per Eye Camera 设置。