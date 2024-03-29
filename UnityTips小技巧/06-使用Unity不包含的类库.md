# 如何使用 Unity 不包含的类库

## 1. 三种建议的方式

 1. 使用 [Nuget For Unity](https://github.com/GlitchEnzo/NuGetForUnity);
 2. 使用 rider 制作类库项目，使用 nuget 安装后，编译，并加载到 Unity 项目中；
 3. 类似上面的操作，只不过把 rider 换成 vs
 4. 听说使用一些特殊的包安装工具（比如 openupm）也能实现操作，再研究...

## 2. rider 具体步骤：

  1. 使用 Rider 在现有 Unity 项目文件夹旁边创建一个新的 .NET Framework 类库（.Net Framework v4.8）项目。

  2. 使用 Nuget 工具安装你所需的类库到当前项目中，记住要安装依赖库

  3. 卸载当前项目 Unload Projects 后，双击项目名，打开项目的 .csproj 文件，在最后的 </project> 之前，添加如下代码：

``` xml
<!--这段配置代码的作用，就是将编译好的类库，以及依赖的包，自动拷贝到指定的路径下-->
<Target Name="AfterBuild">
    <!-- Move the DLL to the Unity project. -->
    <PropertyGroup>
        <!--这里的路径就是你的Unity游戏项目相对路径，Assets\ 之后的路径，你可以随意命名，编译当前项目时，会自动创建-->
        <TargetDir>..\..\..\MyGameProject\Assets\MyOutUtils\Shared\Resources</TargetDir>
    </PropertyGroup>
    <ItemGroup>
        <SourceDir Include="bin\Debug\**\*.*"/>
    </ItemGroup>
    <Copy SourceFiles="@(SourceDir)" DestinationFolder="$(TargetDir)" SkipUnchangedFiles="true"/>
</Target>
```

## 3. 使用 Nuget for Unity

  1. 直接打开 Unity 的 PM，通过 git 链接：https://github.com/GlitchEnzo/NuGetForUnity.git?path=/src/NuGetForUnity ，  安装 Nuget for Unity

![](../../AwesomeUnityTutorial/imgs/NugetForUnity_1.png)

  2. 打开 菜单：NuGet → Manage NuGet Packages
  3. 搜索需要的 Nuget 包，安装即可

![](../../AwesomeUnityTutorial/imgs/NugetForUnity_2.png)


<br>
<hr>
<br>

> 参考资料：
> 
> 1. [use Nuget packages with Unity](https://medium.com/@alexandredemersroberge/use-nuget-packages-with-unity-25b8525f628)
> 2. [https://github.com/GlitchEnzo/NuGetForUnity](https://github.com/GlitchEnzo/NuGetForUnity)
> 3. [使用 vs 安装第三方包](https://www.youtube.com/watch?v=G4XlZC2S07Y)