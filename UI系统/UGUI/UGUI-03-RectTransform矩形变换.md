# Rect Transform 矩形变换
## 1. Rect Transform 矩形变换概念及基本属性

这里所说的 Rect 矩形，就是 UI 元素的所在位置。

矩形变换像常规变换一样具有位置，旋转和比例，但它还具有宽度和高度表示矩形的尺寸。

注意：因为UI是实际上是2D元素，所以进行变换是需要用矩形工具 

![](../../imgs/UI_RectTransform.png)

Rect Transform Inspector 中各属性值：

* Pos X ，Pos Y，Pos Z: anchor锚点靠在一起时，显示这些属性，表示 锚点 沿着X轴和Y轴、Z轴 到 pivot 轴心点的距离
*  Width、Height：UI空间所在矩形的宽和高
*  Left/Right,Top/Bottom:当锚点不靠在一起时，就没有PosX和PosY、Width、Height（比如 Button），而是用上下左右边距来定位，就是各个边和父对象的距离
*  Anchors Min：左下方锚点所在相对位置，取值百分比转换成的小数，相当于父元素位置的百分比
*  Anchors Max：右上方锚点所在相对位置，取值百分比转换成的小数，相当于父元素位置的百分比
*  Pivot ：轴心点所在的相对位置，取值百分比转换成的小数，相当于自身原点（矩形左下角）位置的百分比
*  Rotation ：旋转，一般只有以轴心，相对Z轴旋转的角度值
*  Scale ：缩放，一般不使用，会影响子对象设置时的计算。通常只用在动画或过场时。UI 元素实际大小等于 width/height * Scale 。 
*  BluePrint Mode ：蓝图模式，旋转和缩放对于当前矩形将失效（但对UI元素显示还是有效的，就是不再影响定位），同时会开启自动停靠
*  Raw Edit Mode：原始编辑模式，调整锚点和轴心点时，当前对象会跟通过改变自己的大小来进行适配当前中心点和对应锚点的位置。

## 2. Pivot 枢轴（轴心）

蓝色的甜甜圈按钮就是轴心

旋转、大小和缩放修改都是围绕轴心进行的，因此轴心的位置会影响旋转、大小调整或缩放的结果。

![](../../imgs/UI_PivotRotate.png)

如果想要调整轴心位置，可以直接在 Inspector 中更改值，或者先把 Scene 工具栏上的 Handle Rotation 的按钮，由 Center 改为 Pivot，就在场景中可以随意拖动 Pivot 了

## 3. Anchors 锚点

锚点在场景视图中显示为四个小三角形手柄（四叶花）。

每个叶子位置对应矩形的四个顶点（四个实心蓝色圆点 ）。当描点随父对象变换时，矩形的顶点与对应的锚点相对位置或绝对距离必须保持不变。

例如，子项可以锚定到父项的中心，或锚定到一个角。

注意：

* 锚点可操作范围是父对象的矩形，而非当前对象的矩形。因为锚点就是用于子对象相对于父对象定位用的
* 锚点在一起，就不会在该方向上随着父对象缩放而缩放；反之则会。
* 绝对距离：一般使用非Custom模式调整锚点时，都是当前对象的顶点和对应的锚点绝对距离保持不变；
* 相对位置：使用Custom模式调整锚点时（调整时，场景中会出现百分比数字），当前对象的顶点和对应的锚点的相对位置（对于父对象）不变


<br>
<hr>
<br>

>参考资料
>
> - [创建用户界面 UI（官方手册）](https://docs.unity3d.com/cn/2021.2/Manual/UIToolkits.html)
> - [UGUI 包文档](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/index.html)
> - [其他 UI 资料- UI 系统学习](https://pmlpml.github.io/unity3d-learning/09-ui.html)

<br>
<hr>
<br>

配套视频教程：
[https://space.bilibili.com/43644141/channel/seriesdetail?sid=299912](https://space.bilibili.com/43644141/channel/seriesdetail?sid=299912)

文章也同时同步微信公众号，喜欢使用手机观看文章的可以关注

![](../../imgs/微信公众号二维码.jpg)