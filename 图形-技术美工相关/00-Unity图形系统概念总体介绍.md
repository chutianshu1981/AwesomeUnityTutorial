# Unity 图形系统相关概念总体介绍

> 资源网站：
> [https://ambientcg.com/](https://ambientcg.com/)

> 参考资料：

> - [一文看懂材质/纹理 Material, Texture, Shading, Shader 的区别](https://www.uegeek.com/190608-material-texture-shaders.html)
> - [Mesh 简介](https://www.cnblogs.com/DevMi/p/mesh.html)

材质（Material）包含贴图（Map），贴图包含纹理（Texture）

纹理是最基本的数据输入单位，游戏领域基本上都用的是位图，此外还有程序化生成的纹理（Procedural Texture）
贴图（Map）其实包含了另一层含义：映射，其功能是把纹理通过 UV 坐标映射到 3D 物体表面。贴图包含了除了纹理以外其他很多信息，比如说：UV 坐标，贴图输入输出控制等。

材质是一个数据集，主要功能就是给渲染器提供数据和光照算法，贴图就是其中数据的一部分，根据用途不同，贴图也会被分成不同的类型，比如：Diffuse，Map，Specular Map，Normal Map，Gloss Map 等，另一个重要部分就是光照模型 shader，用于实现不同的效果。
