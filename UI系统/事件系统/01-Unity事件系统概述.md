# Unity 事件系统概述

如果要 UI 系统能够相应用户操作，或及时给用户相应的动态信息，就要使用到事件系统。

Unity  的事件系统，基于 UnityEvent，该类是 Unity 引擎对 .net中 C#  Event 的封装版。

为什么不说 “增强版” 或 “改良版”，是因为在易用性上，UnityEvent 更适合做游戏开发；但 C# Event 在很多情况下，执行效率更高。

## 一句话，Unity事件系统就是加了 Editor UI 的C#事件

