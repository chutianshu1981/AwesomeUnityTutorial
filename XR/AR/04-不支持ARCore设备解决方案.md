# 不支持ARCore的 Android 设备解决方案

## 1. 测试是否支持 ArCore

要测试您的设备是否支持ARCore，有两种方案：

* 可以从Google Play商店下载ARCore应用程序并在设备上运行它。该应用程序将告诉您您的设备是否与ARCore兼容。
  下载页面：[https://developers.google.com/ar/develop/downloads?hl=zh-cn](https://developers.google.com/ar/develop/downloads?hl=zh-cn)

  不能下载的小伙伴可以到我的网盘:https://pan.xunlei.com/s/VNWtb9_-frEIUtHkEdpmV72BA1?pwd=2d3a# 提取码：2d3a

* 也可以在ARCore网站上检查支持ARCore的设备列表。[https://developers.google.com/ar/devices?hl=zh-cn](https://developers.google.com/ar/devices?hl=zh-cn)

## 2. 使用替代库

可以使用的跨平台（Android/iOS 通用）替代库有很多，这里只列举出几个较为常用的作为示例

### 2.1 OpenAR

这个 SDK 不同于其他 SDK ，它是朝着行业规则的方向去的。类似于协议，比如 HTTP，ECMA Script (Javascript 的标准)

出现较早，本意是想最第三方标准组织一统江湖，但大公司并不买账

* 优点：支持的硬件厂商多，而且，只要是 OpenAR 中有的功能，基本上所有硬件都可以实现
* 缺点：因为要成为整个AR行业标准，兼容性为首选，所以发展较慢。特别是比如地理位置支持等，新特性收录较慢

### 2.1 Vuforia

据说是世界上企业用户量最高的 AR 技术服务商，公司最大，母公司PTC，技术体系架构最先进，商用工业化 AR SDK 首选（TO B）。

在跟踪功能上，世界顶尖，比如物体识别和扩展跟踪

### 2.2 HUAWEI AR Engine

官方文档：AR Engine是一款用于在HarmonyOS/Android上构建增强现实应用的引擎。包含AR Engine服务、AR Cloud服务与XRKit服务，其中XRKit是基于AR Engine提供场景化、组件化的极简AR解决方案，二者均可实现虚拟世界与现实世界的融合，带来全新的交互体验。

华为 AR Engine 虽然还未冲到世界前几位，不过根据最近的发展态势，未来可期

缺点：只支持华为和荣耀的硬件，其他品牌暂不支持

### 2.2 EasyAR

国内的 AR SDK ，部分开源，由最开始的全部开源到现在的部分开源 + 商业化云服务，发展势头很猛。也在和国内一些 AR 硬件厂商合作，作为Ardroid 设备上的 ARCore 替代方案，以免到时跟华为手机一样被Google ban 了。


### 2.3 Wikitude

高通的 AR 库，主要面向的是娱乐和用户应用（TO C），更专注于消费者用例

相较于 Vuforia，Wikitude 更注重图像识别和基于地理位置的 AR 服务


