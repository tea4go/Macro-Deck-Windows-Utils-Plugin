该项目采用标准的 .NET SDK 风格进行依赖管理，结合了 NuGet 包管理器和本地 DLL 引用（Vendoring）两种策略。

### 1. 依赖声明与版本控制
- **NuGet 包管理**：在 `Windows Utils.csproj` 中通过 `<PackageReference>` 声明第三方库，包括：
  - `H.InputSimulator` (v1.4.0)：用于模拟键盘和鼠标输入。
  - `Newtonsoft.Json` (v13.0.3)：用于 JSON 序列化/反序列化。
  - `System.Drawing.Common` (v7.0.0)：用于图像处理。
- **版本锁定**：依赖版本在 `.csproj` 文件中硬编码。项目未包含显式的 `packages.lock.json` 文件，但 CI 流程通过 `dotnet restore` 确保依赖的一致性。

### 2. 核心插件依赖（Macro Deck 2.dll）
- **本地 Vendoring**：项目在 `libs/` 目录下维护了 `Macro Deck 2.dll` 的副本，作为开发环境的备用引用源。
- **条件引用逻辑**：`.csproj` 中配置了智能引用路径：
  - 优先尝试引用系统安装路径：`C:\Program Files\Macro Deck\Macro Deck 2.dll`。
  - 若不存在，则回退到本地 `libs\Macro Deck 2.dll`。
- **非私有化部署**：该引用设置了 `<Private>false</Private>`，意味着编译后的插件输出目录不会包含主程序 DLL，避免运行时冲突并减小插件体积。

### 3. 构建与自动化
- **CI/CD 集成**：`.github/workflows/build.yml` 定义了基于 GitHub Actions 的构建流程，使用 `actions/setup-dotnet@v4` 和 `dotnet restore/build` 命令。
- **目标框架**：项目针对 `net10.0-windows7.0`，表明其依赖较新的 .NET 运行时环境。
- **后处理脚本**：本地构建包含 PostBuild 事件，自动将生成的 DLL 复制到 Macro Deck 的插件目录并重启应用，提升了开发迭代效率。

### 4. 开发者规范
- **依赖更新**：更新 NuGet 包时需同步修改 `.csproj` 中的版本号，并确保与目标 .NET 框架兼容。
- **主程序接口同步**：若 Macro Deck 主程序 API 发生变更，需手动更新 `libs/Macro Deck 2.dll` 或确保本地安装的主程序版本匹配，否则可能导致编译失败或运行时错误。