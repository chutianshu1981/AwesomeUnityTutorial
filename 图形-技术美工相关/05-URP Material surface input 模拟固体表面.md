# URP Material surface input 材质表面输入 设置 -- 模拟固体表面

## 1. 光

当光与任何物体接触时，它可以做以下三件事之一：

- 反射：从物体反射回来，这称为反射；
- 透射：穿过它，如果物体是透明的或半透明的；
- 被吸收：光被物体吸收。

物体在人眼看来的方式取决于它以这些方式的某种组合对光的反应。

## 2. 镜面反射（Specular reflection）和漫反射（diffuse reflection）

光从物体反射有两种方式：镜面反射和漫反射。

### Specular reflection 镜面反射

镜面反射是指光直接的反射，射入和反射光的量相等，物体最明亮的部分通常都是镜面反射。

在下面的示例图像中，镜面反射是白色的，这表明光源是白色的。

![](../imgs/Specular_&_diffuse_reflection.png)

### Diffuse reflection 漫反射

但并非所有到达苹果的光都直接从它反射回来。其他光线穿透表面，穿过或在苹果的外层周围反射。这种光有的被吸收，有的被反射出去。逸出的光是漫反射。

上面的图中，红色部分的光就是漫反射的光线

物体的漫反射决定了它的可见颜色。在苹果上，非红光被吸收，红光反射到我们的眼睛。

总之，镜面反射和漫反射构成了表面的总反射率。所有反射光要么是镜面的，要么是漫反射的。

## 3. Diffuse reflectivity 漫反射率

漫反射率是指物体的可见颜色，即从其表面反射的颜色。

### Base Map：

在 Unity 的 URP/Lit Shader 中，使用 Base Map 来设定 漫反射率，即物体表面的颜色。  
在其他 Shader 中，也会将此属性称为 Albedo 或 Diffuse Map

### albedo

albedo 实际上就是 Diffuse reflectivity

![](../imgs/Urp_lit_shader_BaseMap.png)

> 参考资料：
>
> - [官方教程-模拟固体表面](https://learn.unity.com/tutorial/simulate-solid-surfaces)
> - [URP 官方文档-着色器和材质](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@12.1/manual/shaders-in-universalrp.html)、
> - [Material physics in context of PBR texturing](https://handlespixels.wordpress.com/2018/03/23/material-physics-in-context-of-texturing/)
