# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is an educational project demonstrating AI-driven game development for a 2D pixel-style ARPG game set in a multi-universe universe combining Song Dynasty history, martial arts, and mythology. The project documents the complete process of using AI tools to create a game from concept to implementation.

## Project Structure

### Main Documentation Files
- `README.md` - Project overview and B站 course reference
- `ep-总体需求文档.md` - Overall requirements document defining what the game should be (high-level needs)
- `ep07-游戏总体概要设计文档.md` - Complete Game Design Document with detailed integrated content and AI tools guide (how to implement)
- `ep06-1-游戏开发文档创建.md` - AI-driven game development documentation process
- `ep06-AI辅助游戏开发--实例规划.md` - Instance planning for AI-assisted game development
- `ep08-素材AI设计概述.md` - AI-generated game assets and materials overview
- `开场故事.md` - Opening story and world background narrative
- `GEMINI.md` - Gemini-specific documentation and prompts
- `AI生成内容质量评估标准.md` - Comprehensive quality assessment standards for AI-generated content

### Detailed Design Documents (`ep07-总体概要设计文档拆分/`)
- `ep07-1-游戏机制设计.md` - Core game mechanics design
- `ep07-2-战斗系统设计.md` - Combat system detailed design
- `ep07-3-角色成长系统.md` - Character progression system
- `ep07-4-世界观和剧情设计.md` - World building and storyline
- `ep07-5-游戏节奏设计.md` - Game pacing and experience design
- `ep07-6-关卡设计原则.md` - Level design principles
- `ep07-7-GDD文档模板.md` - Game Design Document template
- `ep07-8-其他设定集.md` - Additional settings and configurations

### Asset Design (`ASD/`)
- `00-总设计规则文档.md` - Overall design rules
- `01-宣传画设计文档.md` - Promotional art design
- `02-1-主角设计文档.md` - Main character design documentation
- `02-2-怪物阵营设计文档.md` - Monster faction design documentation
- `02-3-NPC设计文档.md` - NPC design documentation
- `02-角色设计文档.md` - General character design documentation
- `03-场景设计文档.md` - Scene design documentation
- `04-UI设计文档.md` - UI design documentation
- `05-AI图像生成提示词标准.md` - AI image generation prompt standards
- `05-特效设计文档.md` - Special effects design
- `06-Metal Slug风格2D像素素材设计要求.md` - Metal Slug style 2D pixel art requirements
- `06-音效设计文档.md` - Audio design documentation
- `艺术风格总体设计文档-asid.md` - Overall art style design document
- `id/prompts-id.md` - ID-based prompt documentation

### Educational Content
- `ep02-LLM 工具的基础知识.md` - LLM tools basics
- `ep03-自定义本地LLM和智能体.md` - Custom local LLM and agents
- `ep04-智能工作流(AI Workflow).md` - AI workflow implementation
- `ep05-AI辅助编码环境搭建.md` - AI-assisted coding environment setup

### Development Task Documents (`dtd/`)
- `dt-00-计划任务总纲.md` - Comprehensive project planning with 1,000+ tasks across 36-month development cycle
- `dt-01-素材设计开发.md` - Asset design and development tasks with integrated AI workflow guidance
- `dt-02-世界观设计开发.md` - World view design and development tasks
- `dt-03-剧情设计开发.md` - Story design and development tasks
- `dt-04-核心玩法设计与实现.md` - Core gameplay design and implementation with AI-assisted development workflows
- `dt-05-战斗系统设计与实现.md` - Combat system design and implementation
- `dt-06-角色成长系统设计与实现.md` - Character progression system design and implementation
- `dt-07-关卡设计与实现.md` - Level design and implementation
- `dt-08-UIUX系统设计与实现.md` - UI/UX system design and implementation
- `dt-09-音效系统设计与实现.md` - Audio system design and implementation
- `dt-10-技术架构与引擎配置.md` - Technical architecture and engine configuration

## Key Game Design Concepts

### Core Game Features
- **Genre**: 2D pixel-style ARPG
- **Setting**: Multi-universe with Song Dynasty history, martial arts, and mythology
- **Player Role**: "Outsider" from modern world,不受天命、因果、信仰束缚
- **Core Mechanics**: Companion system, army management, faith-based power system
- **Art Style**: 16-bit pixel art with top-down view
- **Story Title**: "凡界回响" (Echoes from the Mortal Realm)

### Updated World Design
- **Multi-universe Structure**: Multiple material realms with the "大宋界" as main setting
- **Dual Realms**: Material realm and spiritual realm that influence each other
- **Faith Power System**: Spiritual beings draw power from mortal faith (quantity and quality)
- **Historical Context**: Late Northern Song/Southern Song period with Jin invasion
- **Faction System**: Dynamic alignment system affecting NPC reactions and world state

### AI Tool Integration
The project demonstrates comprehensive and systematic AI tool integration throughout the entire development lifecycle:

**Enhanced AI Integration Features:**
- **Comprehensive AI Tools Guide**: Complete guide in main GDD covering design, development, asset creation, and project management
- **AI Workflow Integration**: Each development module (dt-01, dt-04, etc.) includes specialized AI-assisted workflows
- **Quality Assurance Framework**: Dedicated quality assessment standards for AI-generated content
- **Structured Prompt Engineering**: Systematic approach to AI prompt design with role definitions and output specifications

**AI Tool Categories:**
- **Design & Planning**: Claude Code for game design and documentation, MCP Tools for specialized analysis
- **Development**: Claude Code for code assistance and optimization
- **Asset Creation**: ComfyUI for pixel art, Google nano/banana/Veo3 for visual content, Google Audio Generation for audio
- **Quality Control**: Claude Code for testing, code review, and quality assessment
- **Project Management**: MCP Tools for task management, automated reporting, and progress tracking

## Development Workflow

### Phase-Based Development
1. **Game Design & Planning** - AI-assisted game mechanics and GDD creation
2. **Asset Preparation** - AI-generated pixel art, characters, environments
3. **Project Setup** - Unity configuration with AI assistance
4. **Core Systems** - Character, combat, and progression systems
5. **Level Design** - Procedural generation with AI-driven content
6. **Game Polish** - Audio, UI, effects, and balance
7. **Testing & Optimization** - AI-assisted testing and performance tuning
8. **Release Preparation** - Build, documentation, and marketing materials

### AI Tool Usage Patterns
- **Documentation Generation**: Use structured prompts with role definitions
- **Asset Creation**: Combine concept generation with pixel art processing
- **Code Development**: Leverage AI coding assistants with Unity integration
- **Quality Control**: AI-assisted review and optimization workflows

## Working with This Project

### When Adding New Content
1. Follow the established naming convention: `ep##-[description].md`
2. Use the AI prompt templates found in existing documentation
3. Maintain consistency with the multi-universe, Song Dynasty theme
4. Include practical AI tool usage examples

### When Modifying Game Design
1. Reference the overall requirements document (`ep-总体需求文档.md`) for high-level needs
2. Reference the master GDD (`ep07-游戏总体概要设计文档.md`) for implementation details
3. Update corresponding detailed design documents in `ep07-总体概要设计文档拆分/`
4. Ensure consistency across all related systems
5. Document AI tool usage for any new features

### When Creating Assets
1. Follow the asset structure in `ASD/` directory
2. Use the pixel art generation prompts and templates
3. Maintain 16-bit style consistency with Metal Slug influences
4. Include AI tool usage documentation

### When Managing Development Tasks
1. Reference the task framework in `dtd/dt-00-计划任务总纲.md`
2. Follow the 4-level task hierarchy system
3. Use the dt-01 through dt-10 modules for specific development areas
4. Maintain clear task dependencies and time estimates

## File Naming Conventions
- Episodes: `ep##-[description].md`
- Overall requirements: `ep-总体需求文档.md`
- Game design docs: `ep07-游戏总体概要设计文档.md`
- Detailed design docs: `ep07-总体概要设计文档拆分/ep07-[number]-[topic].md`
- Assets: `ASD/[number]-[type]设计文档.md`
- Development tasks: `dtd/dt-[number]-[topic].md`
- Specialized asset docs: `ASD/[number]-[number]-[specific-type].md`

## AI Prompt Engineering
The project uses structured prompts with:
- **Role Definition**: Clear professional role specification
- **Background Context**: Project type, scale, and constraints
- **Output Requirements**: Format, depth, and quality standards
- **Iterative Process**: Multi-stage generation and refinement

## Recent Project Optimizations (September 2025)

### Completed Enhancements

**1. Documentation Structure Optimization**
- Implemented proper software engineering document hierarchy:
  - **Requirements Document** (`ep-总体需求文档.md`): Defines "what" to build (high-level needs)
  - **Design Document** (`ep07-游戏总体概要设计文档.md`): Defines "how" to implement (technical details)
  - **Planning Document** (`dtd/dt-00-计划任务总纲.md`): Defines "when" to execute (project management)
- Created comprehensive overall requirements document with 11 chapters covering all aspects of game development
- Extracted and refined requirements content from existing design documents
- Renamed and reorganized design documents to reflect their proper role in development process

**2. GDD Document Integration**
- Replaced placeholder content with detailed game mechanics and combat system designs
- Added comprehensive AI tools usage guide with structured prompts and workflows
- Integrated content from detailed design documents into master GDD

**3. AI Workflow Integration**
- Added AI-assisted workflows to key development modules (dt-01, dt-04)
- Created specialized prompt templates for different development phases
- Established quality control processes for AI-generated content

**4. Quality Assessment Framework**
- Created comprehensive quality assessment standards document
- Established multi-dimensional evaluation criteria for AI-generated content
- Implemented automated and manual quality control processes

**5. Enhanced Project Structure**
- Improved documentation organization and accessibility
- Added cross-references between related documents
- Enhanced AI tool usage guidelines throughout the project

**6. AI Tool Configuration Correction**
- Corrected AI tool configurations across all project documents
- Standardized toolchain to use only actual development tools:
  - **Development**: Claude Code for coding and documentation
  - **Extensions**: MCP Tools for specialized functionality
  - **Asset Generation**: ComfyUI for pixel art, Google nano/banana/Veo3 for visual content
  - **Audio**: Google Audio Generation for sound and music
- Removed references to unused tools (ChatGPT, GitHub Copilot, Cline, AudioCraft, Stable Diffusion, Midjourney, etc.)

### Current Project Status
- **Documentation Quality**: Professional-grade with complete integration
- **AI Integration**: Systematic implementation across all development phases
- **Quality Control**: Comprehensive framework with clear standards
- **Educational Value**: Enhanced with practical examples and workflows
- **Production Readiness**: Documentation ready for actual development implementation
- **Tool Chain Accuracy**: All AI tool configurations now reflect actual development environment

## Important Notes
- This is a documentation-focused project, not a codebase
- All content is in Chinese language
- Focus is on educational demonstration of AI tools in game development
- No actual Unity game code or assets are currently present
- Project includes comprehensive development task framework with 1,000+ tasks over 36-month cycle
- Features detailed world-building with multi-universe and faith power mechanics
- Includes specialized AI prompt standards for pixel art generation
- Comprehensive task management system with clear dependencies and timelines
- **Enhanced Feature**: Complete AI integration with quality assurance frameworks
- **Ready for Implementation**: Documentation now supports actual game development production