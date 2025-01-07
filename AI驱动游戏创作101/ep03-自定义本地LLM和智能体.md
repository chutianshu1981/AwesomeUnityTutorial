# ep03-自定义本地LLM和智能体

## 1. 安装配置 LM Studio

### 1.1 介绍：


LM Studio 是一个用于训练和部署语言模型的强大工具。它提供了图形化界面，简化了模型管理流程。

### 1.2 安装步骤：

* 下载并安装最新版本的 LM Studio：[下载地址](https://lmstudio.ai/download)。
* 选择开发者模式，并开启服务

## 2. LM Studio 选择并导入开源模型

注意点：

* 先修改模型的存储路径，然后再下载
* 国内直接使用 [魔搭社区](https://www.modelscope.cn/) 下载模型
* 尽可能选择 GGUF 格式的模型
* 如需手动导入，需要建立两层文件夹，才能正确导入模型

## 3. 安装配置 AnythingLLM

下载页：[AnythingLLM官网](https://anythingllm.com/desktop)

## 4. 使用 AnythingLLM 创建自定义智能体

### 4.1 配置注意点

* 安装时，不能科学上网肯定会卡死一段时间，并弹出“下载 LLM 驱动库”的错误，无需理会，直接继续即可
* 使用 LM Studio 作为模型 引擎，必须让 LM Studio 开启 Server 服务
* 使用 LM Studio 作为 LLM 模型引擎 (用作生成文本推理)
* 使用 LM Studio 作为 embedded 模型引擎（用作内置Rag功能，上传资料到向量数据库时，切分Token）
* 使用 LM Studio 作为 Agent 模型引擎（用作Agent模式下的智能体推理）
* Agent 推理模型必须选取通用LLM模型，或者专门为 Agent 功能训练的模型，一些专用模型不能正确提供 Agent 推理功能

### 4.2 使用 @agent 进入智能体模式

**重要**：AnythingLLM 问答流程中，只有 @agent 才支持 Agent 模式下的智能体推理，如果不开启 @agent 模式，则只能使用 LLM 推理模式

一旦进入 @agent 模式，不需要再敲入任何子命令，agent 推理将自动生效，将 会根据上下文，自动判断该使用哪种 agent 功能

可以通过观察 AnythingLLM 的 log 输出，观察 agent 是否正确选取你所需要的工具

退出 @agent 模式：\exit

## 5. 安装配置 AutoGPT

**Auto GPT 关键特性**：

* 无缝集成和低代码工作流：无需广泛编码知识即可快速创建复杂工作流。
* 自主操作与持续代理：部署无限运行的基于云的助手，在相关触发器上激活。
* 智能自动化与最高效率：通过自动化重复性流程简化工作流程。
* 可靠的性能和可预测的执行：享受一致且可靠的长时间运行过程。

**AutoGPT 构成**：

* AutoGPT Server：Agent 核心逻辑，并支持扩展插件
* AutoGPT Frontend：用户界面，负责代理构建器和工作流管理

**AutoGPT 核心功能**：

* 数据处理与分析
* 任务调度与管理
* 通信和通知系统
* 不同软件工具之间的集成
* 人工智能驱动的决策和内容生成

### 5.1 安装配置 AutoGPT Server

>[官方youtube安装教程](https://www.youtube.com/watch?v=4Bycr6_YAMI)
>[官方文档安装教程](https://docs.agpt.co/platform/getting-started/)

**简介：**
AutoGPT Server 是平台的核心组件，负责处理代理的逻辑和自动化流程。

**安装步骤：**

1. **环境要求：**
   - 确保系统已安装以下工具：
     - [Node.js](https://nodejs.org/en/)
     - [Docker](https://www.docker.com/get-started/)
     - [Git](https://git-scm.com/downloads)

    > docker 国内镜像服务器:[最新docker镜像服务器地址](https://www.coderjia.cn/archives/dba3f94c-a021-468a-8ac6-e840f85867ea)

2. **检查 Node.js 和 npm：**
   - 在终端中运行以下命令，确保已安装 Node.js 和 npm：
     ```bash
     node -v
     npm -v
     ```
   - 如果未安装，请从 [Node.js 官方网站](https://nodejs.org/en/download/) 下载并安装。

3. **检查 Docker：**
   - 在终端中运行以下命令，确保已安装 Docker：
     ```bash
     docker -v
     docker compose -v
     ```
   - 如果未安装，请从 [Docker 官方网站](https://docs.docker.com/desktop/) 下载并安装。

4. **克隆仓库：**
   - 打开终端，执行以下命令克隆 AutoGPT 仓库：
     ```bash
     git clone https://github.com/Significant-Gravitas/AutoGPT.git
     ```
   - 进入AutoGPT 仓库目录, 克隆子模块：
     ```bash
     git submodule update --init --recursive
     cd autogpt_platform
     ```
5. **配置环境变量：**
   - autogpt_platform目录下，复制 supabase/docker 下的`.env.example` 文件并重命名为 `.env`：
     ```bash
      cp supabase/docker/.env.example .env
     ```
   - 使用文本编辑器打开 `.env` 文件，根据需要修改配置，例如设置 API 密钥等。

6. **启动服务：**
   - 在项目根目录下，使用 Docker Compose 启动服务：
     ```bash
     docker compose up -d --build
     ```
   - 服务启动后，默认在 `http://localhost:8001` 提供后端服务。
   
   > 如果docker下载太慢，可以配置国内镜像

``` json
   "registry-mirrors": [
    "https://docker-0.unsee.tech",
    "https://docker-cf.registry.cyou",
    "https://docker.1panel.live",
    "https://registry.dockermirror.com",
    "https://docker.imgdb.de",
    "https://docker.m.daocloud.io",
    "https://hub.firefly.store",
    "https://hub.fast360.xyz",
    "https://cjie.eu.org"
  ]
```

   > 可能出现的错误及解决方案：https://github.com/Significant-Gravitas/AutoGPT/issues/8988

### 5.2 安装配置 AutoGPT Frontend

**简介：**
AutoGPT Frontend 是用户与平台交互的界面，提供代理构建器、工作流管理等功能。

**安装步骤：**

1. **进入前端目录：**
   - 在终端中，在autogpt_platform文件夹下，导航到前端目录，并将.env.example 拷贝到 .env 文件（相当于新建并克隆到 .env ）：
     ```bash
     cd frontend
     cp .env.example .env
     ```

2. **安装依赖：**
   - 在前端目录中，运行以下命令安装所需的 npm 包：
     ```bash
     npm install
     ```
   
   **注意** ： 如果下载安装速度慢，可以提前配置 npm 国内镜像：npm config set registry https://registry.npmmirror.com/



3. **启动前端开发服务器：**
   - 运行以下命令启动前端开发服务器：
     ```bash
     npm run dev
     ```
   - 前端界面将默认在 `http://localhost:3000` 提供。

4. **配置前端与后端通信：**
   - 确保前端能够与后端服务器通信，必要时在 `.env` 文件中配置 API 端点。


通过上述步骤，您将成功安装并配置 AutoGPT 的 Server 和 Frontend 组件，为创建自定义智能体和 AI 工作流奠定基础。 

## 6. AutoGPT 创建自定义智能体

## 7. AutoGPT 创建AI工作流

---

>**参考资料**：
>
> * [LM Studio 官方文档](https://lmstudio.ai/docs)
> * [AnythingLLM 官方文档](https://docs.anythingllm.com/)
> * [AutoGPT 官方文档](https://docs.agpt.co/)
> * [AutoGPT 本地部署指南](https://docs.agpt.co/platform/getting-started/)
