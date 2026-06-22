该项目采用 **Windows Forms** 作为唯一的 GUI 技术栈，完全依赖原生控件体系，未引入任何现代 Web 前端技术（如 CSS/SCSS）或第三方 .NET UI 框架（如 WPF/Avalonia）。其视觉风格的核心在于通过继承和封装宿主程序（Macro Deck）提供的自定义控件，实现与宿主环境高度一致的**深色主题**体验。

### 1. 技术架构与布局策略
- **框架选型**：基于 `System.Windows.Forms`，在项目文件 `Windows Utils.csproj` 中通过 `<UseWindowsForms>true</UseWindowsForms>` 显式启用。
- **布局方式**：采用代码生成的绝对坐标布局。所有界面的位置、尺寸及层级关系均在 `.Designer.cs` 文件中通过 `Location`、`Size` 和 `Controls.Add` 定义。
- **开发模式**：遵循标准的 WinForms 分部类（Partial Class）模式，逻辑代码位于 `.cs`，UI 初始化位于 `.Designer.cs`，资源管理位于 `.resx`。

### 2. 视觉风格与设计规范
- **深色主题适配**：为融入 Macro Deck 的深色宿主环境，所有输入型控件（如 `RoundedTextBox`、`RoundedComboBox`）的背景色统一设置为深灰色 `Color.FromArgb(65, 65, 65)`。
- **字体规范**：界面广泛使用“微软雅黑”（Microsoft YaHei），字号根据控件功能在 `9.75F` 至 `14F` 之间调整，确保中文显示的清晰度。
- **交互反馈**：利用宿主提供的 `ButtonPrimary` 等控件实现现代化的交互效果，包括圆角边框（`BorderRadius`）、悬停变色（`HoverColor`）以及进度条显示（`Progress`）。

### 3. 关键组件与复用
- **宿主控件集成**：项目深度依赖 `SuchByte.MacroDeck.GUI.CustomControls` 命名空间。核心控件包括：
  - `RoundedTextBox` / `RoundedComboBox`：提供圆角外观的统一输入控件。
  - `ButtonPrimary`：提供主操作按钮样式，支持 Windows 强调色（`UseWindowsAccentColor`）。
- **目录结构**：
  - `GUI/`：存放基础动作配置窗口（如快捷键配置、文件选择器）。
  - `Views/`：存放更复杂的复合配置视图（如多热键动作配置）。

### 4. 开发者约束
- **禁止手动修改 Designer 文件**：`.Designer.cs` 由 Visual Studio 设计器自动生成和维护，手动修改极易导致设计器崩溃或布局错乱。
- **优先使用宿主控件**：为保证插件与 Macro Deck 主程序的视觉一致性，严禁直接使用标准的 `System.Windows.Forms.TextBox` 等基础控件，必须替换为宿主提供的圆角变体。
- **本地化支持**：所有界面硬编码字符串应通过 `Language/PluginStrings.cs` 或 XML 资源文件进行管理，以支持多语言切换。