# Blender 中渲染过程简介

## 1. 相关概念

### 1.1 着色 Shading

在 Blender 中，Shading 代表的是一个工作区域，通过其中包含的默认窗口区域在其中可以进行光影、纹理、材质、着色器等配置，通过 Shader Node 来实现

### 1.2 材质 Material

材质控制着网格，曲线，体积和其它物体的外观。它们定义了物体的组成物质，颜色，纹理，以及与光照的交互。

是管理模型外观显示的数据集。

### 1.3 Shader

着色器，是运行在 GPU 上的着色程序。

### 1.4 Shader Node

类似于 Unity 中的 Shader Graph，用图形化方式来编辑出 Shader 程序逻辑，由 Blender 处理后生成可执行的 Shader 程序用于最终渲染。

其中可视化编辑节点，就称为 Shader Node。编辑区域为 Shader Editor ，默认包含在 Shading 工作区域中。

### 1.5 纹理 Texture

贴在 3D 模型上的外皮，一般是 2D 位图，可以是单独的素材，也可以是用算法生成。

通过 Maping 贴图操作，映射到模型 3D 网格上

### 1.6 渲染 render

渲染是将三维场景转换为二维图像的过程。通过渲染得到最终要显示的结果

Blender 内置三个各具优势的渲染引擎:

- Eevee 是基于物理的实时渲染器。
- Cycles 是基于物理的光线追踪渲染器。
- 工作台 专为布局，建模和预览而设计的。

> 参考资料：
>
> - [Blender 官方文档](https://docs.blender.org/manual/zh-hans/3.0/render/introduction.html)
> - [知乎讨论](https://www.zhihu.com/question/25745472)

<br>
<hr>
<br>

配套视频教程：
[https://space.bilibili.com/43644141/channel/seriesdetail?sid=299912](https://space.bilibili.com/43644141/channel/seriesdetail?sid=299912)

文章也同时同步微信公众号，喜欢使用手机观看文章的可以关注

![](../../imgs/微信公众号二维码.jpg)
