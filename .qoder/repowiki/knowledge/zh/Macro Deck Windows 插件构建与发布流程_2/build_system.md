## 1. 构建系统概览
该项目是一个基于 .NET 10.0 (Windows Forms) 的 Macro Deck 2 插件。其构建体系高度依赖 Microsoft 的官方工具链，通过 GitHub Actions 实现自动化持续集成（CI），并通过本地脚本辅助开发调试。

### 核心技术栈
- **框架**: .NET 10.0-windows7.0
- **构建工具**: MSBuild / dotnet CLI
- **包管理**: NuGet (Newtonsoft.Json, H.InputSimulator 等)
- **CI/CD**: GitHub Actions

## 2. 关键配置文件
- **`.github/workflows/build.yml`**: 定义了 CI 流水线。在 `windows-latest` 环境下运行，执行 `dotnet restore` 和 `dotnet build`，并将生成的 `Windows Utils.dll` 作为 Artifact 上传。若检测到版本标签（如 `v1.6.0`），会自动打包包含 `ExtensionManifest.json` 的 ZIP 文件并发布到 GitHub Releases。
- **`Windows Utils.csproj`**: 项目核心配置。指定了目标框架、版本号、平台（x64）以及特殊的引用逻辑。
- **`ExtensionManifest.json`**: 插件元数据文件，定义了插件 ID (`SuchByte.WindowsUtils`)、版本及入口 DLL，是 Macro Deck 识别插件的关键。
- **`autorun.bat`**: 本地开发辅助脚本，用于快速重启 Macro Deck 并加载最新编译的插件。

## 3. 架构与约定
### 依赖管理策略
项目采用“条件引用”策略处理宿主程序依赖：
- 优先从 `C:\Program Files\Macro Deck\` 查找 `Macro Deck 2.dll`。
- 若不存在，则回退到本地 `libs/` 目录。
- 设置 `<Private>false</Private>` 确保该 DLL 不会被复制到输出目录，避免与宿主程序冲突。

### 版本控制
- **代码版本**: 在 `.csproj` 中通过 `<Version>`, `<AssemblyVersion>`, `<FileVersion>` 统一管理。
- **清单版本**: `ExtensionManifest.json` 中的版本需手动同步，目前存在轻微不一致（csproj 为 1.6.0，manifest 为 1.6.0）。

### 自动化部署逻辑
- **CI 环境**: 仅负责编译和产物归档，不执行安装。
- **本地环境**: `.csproj` 中包含一个 `PostBuild` 目标，在非 CI 环境下自动将生成的 DLL 复制到用户的 Macro Deck 插件目录，并尝试重启宿主进程以实现热更新。

## 4. 开发者规范
1. **构建命令**: 使用 `dotnet build "Windows Utils.sln" -c Release` 进行正式构建。
2. **资源嵌入**: 语言文件（`Resources/Languages/*.xml`）被配置为嵌入式资源，修改后需重新编译才能生效。
3. **平台限制**: 项目明确针对 `win-x64` 运行时，不支持跨平台编译。
4. **安全块**: 仅在 Release 配置下允许不安全代码块（`AllowUnsafeBlocks`），通常用于底层 Windows API 调用。