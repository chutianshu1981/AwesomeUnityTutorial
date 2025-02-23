# ep05 - AI辅助编码环境搭建

## 1. 编译器选择

### 首推： Visual Studio Code

- 开源免费
- 跨平台
- 插件丰富
- 支持多种编程语言
- 社区活跃

### 其他

- [Jetbrains 系列](https://www.jetbrains.com/)
- [Cursor](https://www.cursor.com/)
- [MarsCode](https://www.marscode.com/)
- [Windsurf](https://codeium.com/windsurf)

## 2. AI IDE 插件

- [Cline](https://github.com/cline/cline)
- Cline 的变体：Roo Code 、Cool Cline ......
- [Codeium](https://codeium.com/)
- 国产的，比如 通译灵码、腾讯与 AI 代码助手...

> 建议：  
> 推荐首选 Cool Cline 插件，国人做的，汉化较好（可以认为是 Roo code 的汉化版）。用熟练后，可以尝试迁移到任意别的 Cline 本体或变体。 

## 3. AI API

任何 AI 公司的 API 都可以，但建议使用集合版的 API 服务器，这样方便管理，方便使用。

- [openrouter](https://openrouter.ai/)
  模型最全，包括大量免费模型，国内也能用（速度稍慢，建议科学上网）
  无需科学上网；开通 api key，可以使用免费模型
  但要开通付费模型，需用国外地址注册；但可以使用visa 卡进行支付

- [硅基流动](https://cloud.siliconflow.cn/i/6zud9cYt)
  国内公司，可以看作是 openrouter 的国内版，可以通过一个 api key, 使用各种模型，也包括一些免费模型。
  对于国内用户，虽然没有 openRouter 那么强大，但优点是 速度快，方便
  我的邀请注册链接：https://cloud.siliconflow.cn/i/6zud9cYt ，你可以获得免费2000万token，我也可以同时获得2000万token
  如果不想使用邀请链接，可以直接用：https://cloud.siliconflow.cn 注册。

## 4. 使用流程

1. 安装 Visual Studio Code
2. 安装插件：Cool Cline
3. 点开 Cool Cline 插件，设置：
   - 语言：中文
   - LLM Provider 设置：这里可以设置多个不同来源配置，可以自行命名，快速切换，我们先将第一个命名为 **硅基流动**
     - LLM Provider ：OpenAI 兼容
     - Base URL：https://api.siliconflow.cn/v1
     - api key：你的 api key
     - Model：Qwen/Qwen2.5-Coder-7B-Instruct
4. Prompt 配置：
   - 语言：中文
   - 通用 prompt 指令：用中文交流 （这里是所有的角色都会遵守的设置，所以不要把一些具体设定写在这里）
   - 角色模式 prompt 配置：具体的交互角色设定，可以方便的套用在不同的情境下，也可以自行添加，比如 python 高级程序员，vue3 高级前端开发 等等...
     - 角色定义：定义角色的最基本特性
     - LLM Provider 配置：选择对应的 LLM Provider
     - 模式专属指令：模式下具体行为的特定说明
     - 预览系统 prompt：预览系统 prompt 完整内容
   - 辅助功能 Prompt 配置：
     独立设置每个快捷功能的 prompt 配置
     - LLM Provider 配置：单独为 辅助功能选择指定的 LLM Provider 配置 ，可以和 前面的  角色模式 prompt 配置 中的 相同，也可以不同

## 5. AI 编程引擎——LLM 模型对比和选择

  | 模型名称                  | 代码生成能力 (1-10) | 价格 ( ￥/M token)                      | AI 代码代理能力 (1-10) |
  | ------------------------- | ------------------- | -------------------------------------- | ---------------------- |
  | Claude-3.5-Sonnet         | 10                  | 输入：22，输出：105 写缓存：25 读缓存2 | 10                     |
  | GPT-o1                    | 10                  | 输入：105，输出：430 写缓存：52        | 9                      |
  | DeepSeek R1               | 8                   | 输入：4，输出：16 命中缓存：1          | 8                      |
  | Llama 3.3                 | 7                   | 免费（需计算资源）                     | 7                      |
  | Qwen 2.5                  | 6                   | 免费（需计算资源）                     | 6                      |
  | Google Gemini 2.0 Pro pre | 7.8                 | 暂时免费                               | 8                      |

  **注意**：  
  > - 模型价格在持续变动中，请根据实际情况自行复核
  > - 模型代码能力，是我根据据自己的使用情况结合网上模型跑分的结果进行打分，仅供参考
  
  Claude-3.5-Sonnet 模型，是目前最好的 AI 编码用模型，特别是在 AI Coding Agent 模式，它有专门的优化，可以顺利指导编程插件执行各种操作步骤：  
  - 文件,目录 操作
  - 命令行操作 
  - 上下文检索
  - 图像支持（根据设计图像生成代码）
  - 识别错误并修复等等
  
  其次是 GTP-o1 ，虽然有很强的代码生成能力，但 AI 代码代理能力却相对较弱，不能很好的指导编程插件执行各种操作步骤。

  这两个是第一梯队，第二梯队是 DeepSeek R1 和 Google Gemini 2.0 Pro pre ，基于他们强力的推理能力，可以勉强支持 AI 代码代理能力，但 AI 代码代理能力仍然相对较弱。

  第三梯队是 Llama 3.3 和 Qwen 2.5 ，这两个模型虽然代码生成能力很强，但 AI 代码代理能力却不行，无法很好的指导编程插件执行各种操作步骤；他们是很强的 LLM 模型，但却没有对 Agent 能力进行优化，这方面远不如  Claude-3.5-Sonnet。如果对这两个模型进行 Agent 方面的微调后，应该可以弥补这方面不足
  