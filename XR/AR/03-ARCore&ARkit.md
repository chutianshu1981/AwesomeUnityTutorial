# ARCore & ARKit

在上一篇中我们介绍过，虽然 Untiy 的 AR Foundation 对 Untiy 中 AR 应用的开发，做了封装，提供了统一的接口、界面和统一的开发方式，但还是要底层 AR SDK 以及硬件本身支持这些功能才行

而 AR 还处在一个高速发展阶段，技术并不统一，不同的厂商提供的方案差距较大。

其中最大两个巨头，分别是 Google Android 设备所支持的 ARcore SDK，和 Apple iOS 设备所支持的 ARKit

这篇中，我们就来详细扒一扒二者的优劣和差异

## 1. ARKit

ARKit 是 Apple 用于基于 AR 的 iOS 应用程序的开发工具包。它首次出现于 2017 年，到现在已经发展到到第六个版本 ：**ARkit 6**

主页地址：[https://developer.apple.com/augmented-reality/](https://developer.apple.com/cn/augmented-reality/)

### 1.1 ARKit 优点

* 完全集成到 Apple 的硬件中。ARKit 旨在与 Apple 的操作系统和 iPhone 硬件配合使用，无需担心不同的处理器或相机。这简化了开发工作，使编码人员能够专注于创造尽可能最好的产品。
* 使用Reality Composer轻松进行 AR 开发– Apple 的 Reality Composer 工具可以轻松将 usdz 3D 模型转换为完全可操作的 AR 对象。
* 改进的跟踪。ARKit 在图像跟踪和识别方面往往比 ARCore 表现更好。如果您打算创建 AR 应用程序来跟踪用户手势来操纵屏幕上的图像，ARKit 通常是更高效的选择。它比谷歌的替代品更快地将运动转化为数据。
* 从支持的功能上看，ARKit 要比 ARCore 更多

### 1.2 ARKit 缺点

* 仅兼容 iOS平台。IOS 占全球智能手机使用量的很大一部分，但其市场份额仍低于 Android，而 ARCore 也可以与 iOS 配合使用。在尝试最大化用户数量时，这是一个重要因素。
* 一些需要借助云服务的高级功能，如地理信息相关的，没有Google的做的好，毕竟有谁会放弃Google地图，而去使用苹果的地图呢？

## 2. ARCore

ARCore 于 2018 年首次亮相，尽管它是基于 Tango 构建的——Tango 是一种自 2014 年以来一直在使用的增强现实开发工具包。ARCore 最初是通过Google Play提供的纯 Android SDK 。然而，这已经有所改变，该工具包的最新迭代现在也适用于 iOS。

与 ARKit 一样，ARCore 旨在为开发人员提供创建基于 AR 的沉浸式智能手机体验所需的工具。强项包括光线和距离估计，以及地理跟踪——这三个功能可以以一些非常令人兴奋的方式加以利用。

官方文档：[https://developers.google.com/ar/develop?hl=zh-cn](https://developers.google.com/ar/develop?hl=zh-cn)

### 2.1 ARCore 优点

* 适合游戏。Android 用户约占全球智能手机游戏玩家的 78%，略高于该操作系统的市场份额。再加上强大的Unity3D功能，这意味着专注于 ARCore 对于有志于集成 AR 功能的小型游戏开发者来说是有意义的。
* 卓越的图形功能。ARCore 在颜色强度和温度方面与 ARKit 相匹配，但增加了一些有助于打造身临其境的增强现实体验的额外功能。借助 ARCore，编码人员可以使用着色器并管理像素强度——为虚拟对象开辟新的视觉可能性。
* 光估计和深度 - ARCore 还能够处理光估计。这会根据您的相机图像应用环境照明，使虚拟物品看起来更加逼真。ARCore深度 API还擅长将虚拟对象与现实世界空间相匹配。
* 运动追踪 ：
* 增强映射。正如您对谷歌地图背后的人创建的工具所期望的那样，ARCore 在位置检测和地图绘制方面处于领先地位。它使用更大的映射数据集来表示物理世界（尽管 ARKit 在这方面有所改进）因此对于特定位置的 AR 体验应该稍微好一些。
* 适用于 Android 和 iOS。如果您想跨移动设备平台处理增强现实，ARCore 可能是最佳选择。

### 2.2 ARCore 缺点

* 中国大陆区域，大多数 Android 设备并不支持 ARCore ，注意看清楚 ARCore 支持的设备列表，有个大坑。上面列出的，并不是国内大陆的列表，下面的才是。比如小米，上面的列出的都是海外版的，基本上大多数型号都支持了，但实际上，国内的 miUI 是不支持的，只有你在自己的 小米app商店中，能搜到 google play 服务 for ar，才说明，你这款机型支持 ARCore.
* 对于 iOS 来说不太好——ARKit 在开发增强现实和虚拟现实 iOS 应用程序方面仍然具有优势。兼容性更好，正如我们所见，ARKit 非常擅长利用 Apple 产品的动作捕捉功能。

## 3. 如何选择

其实也很简单，主要依据设备的支持性

* 如果要兼容不支持 ARCore 的 Andorid 设备，那就首选第三方兼容 Ar SDK
* 如果目标设备是支持 ARCore 的Android 设备，自然首选 AR Core
* 苹果产品，默认就选择 ARKit，除非是要用到 Google 地理服务的相关应用，那样的话，就选 ARCore ，ARCore 也支持 iOS设备
* 国内如果使用不了 Google 相关服务，还想使用地理信息服务的，可以看下一篇，选择其他第三方 AR SDK
* 还有一些特殊设备，比如微软的 AR 眼镜 HoloLens ，则会使用自己公司专用的 AR SDK