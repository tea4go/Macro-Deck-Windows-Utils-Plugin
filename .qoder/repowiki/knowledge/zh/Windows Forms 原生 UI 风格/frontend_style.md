该项目是一个基于 .NET (C#) 和 Windows Forms 技术的 Macro Deck 插件，主要用于提供 Windows 系统级的自动化操作。其前端界面（UI）完全依赖于 Windows Forms 的原生控件体系，未采用任何现代 Web 前端技术栈（如 CSS、SCSS、Tailwind 等）或第三方 .NET UI 框架（如 WPF、Avalonia、MAUI）。

### 1. 技术栈与实现方式
- **框架**：使用 `System.Windows.Forms` 进行 GUI 开发。
- **布局方式**：采用代码生成的绝对坐标或锚点布局（在 `.Designer.cs` 文件中定义），通过手动设置控件的 `Location`、`Size` 和 `Controls.Add` 来构建界面。
- **样式定制**：通过继承或封装 Macro Deck 宿主程序提供的自定义控件（如 `SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox` 和 `ButtonPrimary`）来实现统一的视觉风格（如圆角、特定背景色 `Color.FromArgb(65, 65, 65)`）。

### 2. 关键文件与结构
- **GUI/ 目录**：包含各种动作配置窗口的实现，例如 `CommandSelector.cs`、`HotkeyConfigurator.cs` 等。每个窗口由 `.cs`（逻辑）、`.Designer.cs`（UI 初始化）和 `.resx`（资源）组成。
- **Views/ 目录**：包含更复杂的配置视图，如 `StartApplicationActionConfigView.cs`。
- **Windows Utils.csproj**：项目文件中明确声明 `<UseWindowsForms>true</UseWindowsForms>`，确认了技术选型。

### 3. 视觉风格特征
- **深色主题适配**：控件背景色通常设置为深灰色（RGB: 65, 65, 65），以适配 Macro Deck 的深色宿主环境。
- **字体统一**：广泛使用“微软雅黑”（Microsoft YaHei）作为界面字体，字号通常在 9.75F 到 14F 之间。
- **交互反馈**：使用 `ButtonPrimary` 等自定义控件提供悬停颜色变化（如 `HoverColor`）和进度条显示。

### 4. 开发者规范
- **禁止修改 Designer 文件**：UI 布局代码由 Visual Studio 设计器自动生成，严禁手动编辑 `.Designer.cs` 文件，应通过设计器或重构逻辑代码来调整界面。
- **复用宿主控件**：为保持与 Macro Deck 主程序风格一致，应优先使用 `SuchByte.MacroDeck.GUI.CustomControls` 命名空间下的控件，而非标准的 `System.Windows.Forms` 基础控件。
- **本地化处理**：界面字符串应通过 `Language/PluginStrings.cs` 或资源文件进行管理，支持多语言切换。