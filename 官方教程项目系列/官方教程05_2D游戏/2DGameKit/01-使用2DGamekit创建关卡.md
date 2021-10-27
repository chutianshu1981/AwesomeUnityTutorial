# 使用 2D Game Kit 创建关卡

[2D 游戏套件演练-官方教程](https://learn.unity.com/tutorial/2d-you-xi-tao-jian-yan-lian?uv=2020.3&projectId=5facff3cedbc2a001f5338ab#)

## 1. 导入

> - [AssetStore 地址](https://assetstore.unity.com/packages/templates/tutorials/2d-game-kit-107098?_ga=2.162437502.331241089.1633678521-522971275.1624332126)
> - [Baidu 云盘](https://pan.baidu.com/s/12GoDAXrZd_PCiYDbZV_gpw) 提取码：6nha
> - [迅雷云盘](https://pan.xunlei.com/s/VMl_AAmxjqPxnJQWlfnxcQJpA1) 提取码：9i4x

## 2. 改初始 Bug

RuleTile 类冲突

在项目中，自定义了一个 RuleTile 类，和系统中的同名类冲突，会导致导入后第一时间提示出错

改错方法很简单：重命名项目中的 RuleTile 类

1. Assembly-CSharp\Assets\2DGameKit\Scripts\Utility\RuleTile.cs 重命名为 RuleTile2dgk.cs ，并且类名也要更改；
2. Assembly-CSharp-Editor\Assets\2DGamekit\Utilities\Editor\RuleTileEditor.cs 中所有原有的 RuleTile ，替换为 RuleTile2dgk ，推荐使用 visual studio 中“重命名”操作

[RuleTile 使用教程](https://learn.unity.com/tutorial/using-rule-tiles#)

[2D TileMap Extras](https://docs.unity3d.com/Packages/com.unity.2d.tilemap.extras@2.2/manual/index.html)

## 3. 按教程操作

<br>

<hr>
<br>

配套视频教程：
[https://space.bilibili.com/43644141/channel/seriesdetail?sid=299912](https://space.bilibili.com/43644141/channel/seriesdetail?sid=299912)

文章也同时同步微信公众号，喜欢使用手机观看文章的可以关注

![](../../imgs/微信公众号二维码.jpg)
