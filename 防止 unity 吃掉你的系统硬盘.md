# 防止 unity 吃掉你的系统硬盘

## 1. 原因

默认 Asset Store 的下载路径在系统盘（通常为 C 盘），unity 资源一般较大，比较吃硬盘，系统盘存量不足会影响运行速度，影响一些软件的升级和安装，所以最好将其迁移到别的硬盘

## 2. 默认路径

1. unity 编译器路径

editor 编译器指的是 unity 软件本身，可以在 unity hub 中下载安装 unity 不同版本时，手动指定，也可以在 unity hub 中查看

2. unity 数据及资源路径

unity 数据、资源路径，指的是 unity 运行时，用到的一些数据信息、资源等的存放位置

默认数据路径位置：
C:\Users\用户名\AppData\Roaming\Unity

3. unity hub 资源路径

unity hub 资源路径，默认为：C:\Users\用户名\AppData\Roaming\UnityHub

不同版本可能稍有区别，这个也不是是 unity hub 软件的路径（安装时自行指定），而是 unity hub 运行时，生成的数据、资源的存储位置

## 3. unity 数据资源路径更改方式

1. 关闭 unity
2. 剪切 C:\Users\用户名\AppData\Roaming\Unity 文件夹到剩余空间较大的硬盘，比如 E：；也可以先复制粘贴，然后重命名系统盘中的 Unity 文件夹，更加保险一些，等全部操作成功后，再删除
3. 用管理员方式打开命令行，输入如下命令

```shell
mklink /j "C:\Users\用户名\AppData\Roaming\Unity" "E:\Unity"
```

这个 mklink 命令是建立 E:\Unity 文件夹的一个超链接到 C:\Users\用户名\AppData\Roaming\Unity ，类似于 linux/mac os 中的 link 命令

unity 在运行时，会去寻找原来的 "C:\Users\用户名\AppData\Roaming\Unity" 文件夹，但实际上，这个文件夹已经没有了，被我们改成了一个链接；

但 unity 并不在乎，只要通过这个链接能够找到他所需要的那些文件即可，他会通过这个链接，找到我们放到 E:\Unity 中的数据，这个就是迁移后还能够正常运行的原理

![](/imgs/unity_创建链接.png))

> 注意：  
> 上图中命令和文档中的路径不同，请以文档为准

4. 分别右键点击 E:\Unity 和 C:\Users\用户名\AppData\Roaming\Unity ，查看其属性，取消 “只读” 属性

![](/imgs/unity_文件夹属性更改.png) 5. 打开 unity ，测试，如果能正常开启，说明设置成功，否则会有错误提示

> 注意：
>
> 1. 上面举例用的路径，其中的用户名要替换成你自己的，千万别直接复制粘贴
> 2. 我用的 win10 ，win7 的路径可能有所不同，需要自己更改
> 3. unity hub 的数据资源路径，也可以用同样的方式进行更改

## 4. 总结

区分 Unity 三种不同路径

1. 软件路径

- unity hub 软件路径：unity hub 软件本身的路径
- unity 软件路径：不同版本 unity editor 编辑器软件路径

2. 数据及资源路径

unity hub 和 unity 运行时，产生的数据及资源路径，通常默认在系统盘，且不能通过软件配置更改

3. 项目路径

unity 中，我们创建的游戏项目的存放位置，可以在第一次保存项目时，进行设定，也可以使用“另存为”进行更改

这三种路径不需要放在一起，可以根据系统需求，自行选择合适的位置放置

> 参考资料：
> [[Unity]技巧分享：更改 Unity Asset Store 默认下载资源位置的方法](https://errui.blog.csdn.net/article/details/112059936?utm_medium=distribute.pc_relevant.none-task-blog-2%7Edefault%7ECTRLIST%7Edefault-1.no_search_link&depth_1-utm_source=distribute.pc_relevant.none-task-blog-2%7Edefault%7ECTRLIST%7Edefault-1.no_search_link)

配套视频教程：[https://space.bilibili.com/43644141/channel/seriesdetail?sid=299912](https://space.bilibili.com/43644141/channel/seriesdetail?sid=299912)

文章也同时同步微信公众号，喜欢使用手机观看文章的可以关注

![](/imgs/微信公众号二维码.jpg)
