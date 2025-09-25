# Unity配置指南

## 文档信息
- **文档编号**: TECH-02-UNITY
- **文档名称**: Unity配置指南
- **版本**: v1.0
- **创建日期**: 2025-09-17
- **负责人**: 技术团队
- **审核状态**: 待审核

---

## 一、Unity版本和系统要求

### 1.1 Unity版本选择
- **推荐版本**: Unity 2022.3 LTS (长期支持版本)
- **最低要求**: Unity 2021.3 LTS
- **避免版本**: Unity 2023.x (非LTS版本)

### 1.2 开发环境要求
- **操作系统**: Windows 10/11 (64位)
- **内存**: 最低16GB，推荐32GB
- **处理器**: Intel Core i5 / AMD Ryzen 5 或更高
- **显卡**: 支持DirectX 11，4GB显存以上
- **存储**: SSD硬盘，至少50GB可用空间

### 1.3 附加工具
- **版本控制**: Git + Git LFS
- **代码编辑器**: Visual Studio 2022
- **2D素材工具**: Aseprite / Photoshop
- **音频工具**: Audacity / Reaper

---

## 二、项目创建和基础配置

### 2.1 新建项目
```
项目名称: SongDynastyARPG
模板: 2D (Core)
位置: 选择合适的开发目录
```

### 2.2 项目结构设置
```
Assets/
├── _Project/          # 项目配置
├── _Scenes/           # 场景文件
├── _Scripts/          # 脚本文件
├── _Art/             # 艺术资源
│   ├── Characters/    # 角色素材
│   ├── Environments/ # 环境素材
│   ├── UI/           # UI素材
│   └── Effects/      # 特效素材
├── _Audio/           # 音频资源
│   ├── Music/        # 音乐
│   ├── SFX/          # 音效
│   └── Voice/        # 语音
├── _Data/            # 数据文件
├── _Prefabs/         # 预制体
├── _Settings/        # 配置文件
└── _Plugins/         # 插件
```

### 2.3 项目设置 (Project Settings)

#### 2.3.1 Player设置
```csharp
// Player Settings
- Company Name: "YourStudioName"
- Product Name: "SongDynastyARPG"
- Default Orientation: Landscape Left
- Resolution: 1920x1080 (目标分辨率)
- Target Frame Rate: 30
- Run In Background: true
- Render Mode: GPU Skinning
```

#### 2.3.2 质量设置
```csharp
// Quality Settings
- Quality Level: Medium (中等质量)
- Pixel Light Count: 2
- Shadows: Hard Shadows
- Texture Quality: Full Res
- Anisotropic Textures: Enable
- Anti Aliasing: 2x
- VSync Count: Don't Sync
```

#### 2.3.3 输入设置
```csharp
// Input Settings
- 使用新的Input System包
- 创建输入动作资产 (Input Action Asset)
- 设置键盘和手柄控制方案
```

---

## 三、2D项目特定配置

### 3.1 2D设置
```csharp
// 2D Settings
- Default Behavior Mode: 2D
- Pixel Perfect Camera: 启用
- Pixel Per Unit: 16 (像素艺术标准)
- Max Texture Size: 2048
- Texture Compression: None (像素艺术需要清晰度)
```

### 3.2 图形设置
```csharp
// Graphics Settings
- Scriptable Render Pipeline: URP (Universal Render Pipeline)
- URP Asset: 创建2D像素艺术专用的URP配置
- Lighting: 2D Lighting
- Post Processing: 禁用 (保持像素艺术风格)
```

### 3.3 物理设置
```csharp
// Physics 2D Settings
- Gravity: (0, -9.81)
- Default Material: 无摩擦力材质
- Velocity Iterations: 8
- Position Iterations: 3
- Queries Hit Triggers: true
```

---

## 四、包管理器配置

### 4.1 必需包
```json
// manifest.json
{
  "dependencies": {
    "com.unity.collab-proxy": "2.0.4",
    "com.unity.feature.development": "1.0.1",
    "com.unity.ide.rider": "3.0.15",
    "com.unity.ide.visualstudio": "2.0.16",
    "com.unity.inputsystem": "1.5.0",
    "com.unity.test-framework": "1.1.31",
    "com.unity.textmeshpro": "3.0.6",
    "com.unity.timeline": "1.6.4",
    "com.unity.toolchain.win-x86_64-linux-x86_64": "2.0.4",
    "com.unity.ugui": "1.0.0",
    "com.unity.visualscripting": "1.8.0",
    "com.unity.modules.ai": "1.0.0",
    "com.unity.modules.androidjni": "1.0.0",
    "com.unity.modules.animation": "1.0.0",
    "com.unity.modules.assetbundle": "1.0.0",
    "com.unity.modules.audio": "1.0.0",
    "com.unity.modules.cloth": "1.0.0",
    "com.unity.modules.director": "1.0.0",
    "com.unity.modules.imageconversion": "1.0.0",
    "com.unity.modules.imgui": "1.0.0",
    "com.unity.modules.jsonserialize": "1.0.0",
    "com.unity.modules.particlesystem": "1.0.0",
    "com.unity.modules.physics": "1.0.0",
    "com.unity.modules.physics2d": "1.0.0",
    "com.unity.modules.screencapture": "1.0.0",
    "com.unity.modules.terrain": "1.0.0",
    "com.unity.modules.terrainphysics": "1.0.0",
    "com.unity.modules.tilemap": "1.0.0",
    "com.unity.modules.ui": "1.0.0",
    "com.unity.modules.uielements": "1.0.0",
    "com.unity.modules.unityanalytics": "1.0.0",
    "com.unity.modules.unitywebrequest": "1.0.0",
    "com.unity.modules.unitywebrequestassetbundle": "1.0.0",
    "com.unity.modules.unitywebrequestaudio": "1.0.0",
    "com.unity.modules.unitywebrequesttexture": "1.0.0",
    "com.unity.modules.unitywebrequestwww": "1.0.0",
    "com.unity.modules.vehicles": "1.0.0",
    "com.unity.modules.video": "1.0.0",
    "com.unity.modules.vr": "1.0.0",
    "com.unity.modules.wind": "1.0.0",
    "com.unity.modules.xr": "1.0.0",
    "com.unity.render-pipelines.universal": "12.1.7"
  }
}
```

### 4.2 推荐第三方包
- **Cinemachine**: 相机系统
- **DOTS**: 性能优化 (可选)
- **Addressables**: 资源管理
- **Odin Inspector**: 开发工具 (付费)
- **2D Pixel Perfect**: 像素完美相机

---

## 五、编译和构建设置

### 5.1 脚本运行时版本
```csharp
// Scripting Runtime Version
- 使用 .NET 4.x Equivalent
- Api Compatibility Level: .NET 4.x
- Allow 'unsafe' Code: false
```

### 5.2 优化设置
```csharp
// Optimization Settings
- Prebake Collision Meshes: true
- Preload Shaders: true
- Optimize Mesh Data: true
- GPU Skinning: true
- Texture MipMap Stripping: true
- Strip Engine Code: true
- Managed Stripping Level: Medium
```

### 5.3 构建设置
```csharp
// Build Settings
- 目标平台: Windows, macOS, Linux
- 构建配置: Release
- 脚本后端: IL2CPP
- 代码优化: Release
- 压缩: LZ4HC
```

---

## 六、版本控制和团队协作

### 6.1 .gitignore配置
```
# Unity
[Ll]ibrary/
[Tt]emp/
[Oo]bj/
[Bb]uild/
[Bb]uilds/
[Ll]ogs/
[Mm]emoryCaptures/
ProjectSettings/ProjectVersion.txt

# Visual Studio
*.csproj
*.sln
*.vs
*.vsconfig

# OSX
.DS_Store

# Windows
Thumbs.db
ehthumbs.db
Desktop.ini

# Package Manager
node_modules/
```

### 6.2 Git LFS配置
```
# Unity LFS Settings
*.png filter=lfs diff=lfs merge=lfs -text
*.jpg filter=lfs diff=lfs merge=lfs -text
*.mp3 filter=lfs diff=lfs merge=lfs -text
*.wav filter=lfs diff=lfs merge=lfs -text
*.ogg filter=lfs diff=lfs merge=lfs -text
*.asset filter=lfs diff=lfs merge=lfs -text
*.unity filter=lfs diff=lfs merge=lfs -text
*.prefab filter=lfs diff=lfs merge=lfs -text
*.mat filter=lfs diff=lfs merge=lfs -text
*.anim filter=lfs diff=lfs merge=lfs -text
*.controller filter=lfs diff=lfs merge=lfs -text
*.unitypackage filter=lfs diff=lfs merge=lfs -text
```

---

## 七、调试和开发工具配置

### 7.1 控制台配置
```csharp
// Console Settings
- Error Pause: true
- Collapse: true
- Clear On Play: true
- Log Level: Log
```

### 7.2 性能分析器
```csharp
// Profiler Settings
- 启用内存分析
- 启用CPU分析
- 启用GPU分析
- 启用音频分析
```

### 7.3 调试预制体
```
创建调试工具预制体:
- DebugManager: 调试信息显示
- PerformanceMonitor: 性能监控
- CheatConsole: 作弊控制台
- FlyCamera: 自由相机
```

---

## 八、测试框架配置

### 8.1 单元测试
```csharp
// Test Framework Settings
- 使用 NUnit 框架
- 创建 Edit Mode 和 Play Mode 测试
- 设置测试覆盖率
- 集成CI/CD流水线
```

### 8.2 集成测试
```csharp
// Integration Tests
- 创建测试场景
- 设置测试用例
- 自动化测试流程
- 性能基准测试
```

---

## 九、资源导入设置

### 9.1 纹理导入设置
```csharp
// Texture Import Settings
- Texture Type: Sprite (2D and UI)
- Sprite Mode: Single
- Pixels Per Unit: 16
- Filter Mode: Point (no filter)
- Compression: None
- Generate Mip Maps: false
- Wrap Mode: Clamp
```

### 9.2 音频导入设置
```csharp
// Audio Import Settings
- Load Type: Decompress On Load
- Compression Format: Vorbis
- Quality: 100%
- Sample Rate Setting: Preserve Sample Rate
```

### 9.3 字体导入设置
```csharp
// Font Import Settings
- 使用 TextMeshPro
- 字体大小: 0-72
- 字体渲染模式: SDF
- 字体材质: 创建像素风格材质
```

---

## 十、部署和发布配置

### 10.1 Steam集成
```csharp
// Steam Integration
- 导入Steamworks.NET
- 配置Steam App ID
- 设置成就和统计
- 云存档配置
```

### 10.2 平台特定设置
```csharp
// Platform Specific Settings
- Windows: 可执行文件图标、版本信息
- macOS: 应用程序图标、签名
- Linux: 可执行文件权限
```

### 10.3 本地化配置
```csharp
// Localization Setup
- 使用 Unity Localization 包
- 支持语言: 中文、英文
- 字体配置: 支持中文字符
- 文本导出导入流程
```

---

## 十一、最佳实践

### 11.1 文件组织
```
文件命名规范:
- 类名: PascalCase (GameManager, PlayerController)
- 方法名: PascalCase (CalculateDamage, MovePlayer)
- 变量名: camelCase (playerHealth, moveSpeed)
- 常量: SCREAMING_SNAKE_CASE (MAX_HEALTH)
- 文件夹: 使用下划线分割 (ui_elements, character_sprites)
```

### 11.2 代码组织
```csharp
// 代码架构原则
- 单一职责原则
- 依赖注入
- 事件驱动架构
- 状态机模式
- 对象池模式
```

### 11.3 资源管理
```csharp
// 资源管理最佳实践
- 使用 ScriptableObject 管理配置数据
- 实现资源异步加载
- 使用对象池管理频繁创建销毁的对象
- 定期清理未使用的资源
```

### 11.4 性能优化
```csharp
// 性能优化技巧
- 避免在Update中进行大量计算
- 使用对象池减少GC压力
- 优化Draw Calls
- 使用层级管理减少渲染开销
- 优化碰撞检测
```

---

## 十二、常见问题和解决方案

### 12.1 常见错误
```
问题: 像素艺术模糊
解决: 设置Filter Mode为Point，禁用Mip Maps

问题: 性能问题
解决: 检查Draw Calls，使用对象池，优化碰撞检测

问题: 内存泄漏
解决: 检查资源引用，使用弱引用，定期清理缓存

问题: 包体过大
解决: 压缩纹理，移除未使用资源，使用Addressables
```

### 12.2 调试技巧
```
- 使用Debug.Log输出调试信息
- 使用Unity Profiler分析性能
- 使用断点调试代码
- 使用Gizmos可视化调试信息
```

---

## 十三、检查清单

### 13.1 项目设置检查
- [ ] Unity版本正确
- [ ] 项目结构合理
- [ ] 包管理器配置完整
- [ ] 版本控制配置正确
- [ ] 性能设置优化

### 13.2 开发环境检查
- [ ] 所有开发人员使用相同Unity版本
- [ ] 第三方包安装完整
- [ ] 调试工具配置正确
- [ ] 测试框架设置完成
- [ ] 资源导入设置正确

### 13.3 构建发布检查
- [ ] 构建设置正确
- [ ] 平台特定配置完成
- [ ] 本地化配置正确
- [ ] 性能测试通过
- [ ] 质量保证检查完成

---

这个Unity配置指南提供了完整的项目设置和配置方案，确保开发团队能够快速搭建标准化的开发环境，提高开发效率和产品质量。