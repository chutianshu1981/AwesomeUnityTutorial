# 不支持ARCore的 Android 设备解决方案

## 1. 测试是否支持 ArCore

要测试您的设备是否支持ARCore，有两种方案：

* 可以从Google Play商店下载ARCore应用程序并在设备上运行它。该应用程序将告诉您您的设备是否与ARCore兼容。
  下载页面：[https://developers.google.com/ar/develop/downloads?hl=zh-cn](https://developers.google.com/ar/develop/downloads?hl=zh-cn)

  不能下载的小伙伴可以到我的网盘:https://pan.xunlei.com/s/VNWtb9_-frEIUtHkEdpmV72BA1?pwd=2d3a# 提取码：2d3a

* 也可以在ARCore网站上检查支持ARCore的设备列表。[https://developers.google.com/ar/devices?hl=zh-cn](https://developers.google.com/ar/devices?hl=zh-cn)

## 2. 使用替代库

可以使用的跨平台（Android/iOS 通用）替代库有很多，这里只列举出几个较为常用的作为示例，排在前面的用户量更高

### 2.1 Vuforia

据说是世界上企业用户量最高的 AR 技术服务商，公司最大，母公司PTC，技术体系架构最先进，商用工业化 AR SDK 首选（TO B）。

在跟踪功能上，世界顶尖，比如物体识别和扩展跟踪

### 2.2 EasyAR

国内的 AR SDK ，部分开源，由最开始的全部开源到现在的部分开源 + 商业化云服务，发展势头很猛。也在和国内一些 AR 硬件厂商合作，作为Ardroid 设备上的 ARCore 替代方案，以免到时跟华为手机一样被Google ban 了。


### 2.3 Wikitude

高通的 AR 库，主要面向的是娱乐和用户应用（TO C），更专注于消费者用例

相较于 Vuforia，Wikitude 更注重图像识别和基于地理位置的 AR 服务


