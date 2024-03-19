# 如何使用 Unity 不包含的类库

## 具体步骤：

### 1. 使用 Rider 在现有 Unity 项目文件夹旁边创建一个新的 .NET Framework 类库（.Net Framework v4.8）项目。

### 2. 使用 Nuget 工具安装你所需的类库到当前项目中，记住要安装依赖库

### 3. 卸载当前项目 Unload Projects 后，双击项目名，打开项目的 .csproj 文件，在最后的 </project> 之前，添加如下代码：

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




> 参考资料：
> 1. [use Nuget packages with Unity](https://medium.com/@alexandredemersroberge/use-nuget-packages-with-unity-25b8525f628)