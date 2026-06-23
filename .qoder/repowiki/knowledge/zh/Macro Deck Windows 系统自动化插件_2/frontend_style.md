该项目采用 **Windows Forms** 作为唯一的 GUI 技术栈，深度依赖 Macro Deck 宿主程序提供的自定义控件库以实现视觉一致性。其前端风格并非通过 CSS 或现代样式表定义，而是通过代码生成的布局逻辑和硬编码的视觉属性（如颜色、字体）来实现。

### 1. 核心技术栈与架构
- **框架基础**：基于 `.NET` (C#) 的 `System.Windows.Forms`，项目文件中显式启用 `<UseWindowsForms>true</UseWindowsForms>`。
- **UI 组织模式**：采用经典的 **Code-Behind** 模式，每个界面由三个文件组成：
  - `.cs`：业务逻辑与事件处理。
  - `.Designer.cs`：由 Visual Studio 设计器自动生成的 UI 初始化代码（包含控件实例化、属性设置及布局定位）。
  - `.resx`：存储本地化字符串及图标资源。
- **布局策略**：使用绝对坐标（`Location`）和固定尺寸（`Size`）进行布局，辅以 `Controls.Add` 将控件挂载到父容器。未采用流式布局或响应式设计框架。

### 2. 视觉风格与设计令牌 (Design Tokens)
由于缺乏集中式的样式配置文件，视觉规范分散在各个 `.Designer.cs` 文件中，但表现出高度的一致性：
- **深色主题适配**：所有输入类控件（如 `RoundedTextBox`, `RoundedComboBox`）的背景色统一设置为 `Color.FromArgb(65, 65, 65)`，以融入 Macro Deck 的深色宿主环境。
- **字体规范**：全局优先使用 **“微软雅黑” (Microsoft YaHei)**，字号根据控件类型在 `9.75F` 至 `14F` 之间浮动。
- **交互反馈**：按钮控件（`ButtonPrimary`）定义了明确的悬停状态颜色（如 `HoverColor = Color.FromArgb(0, 89, 184)`）和进度条颜色，提供即时的视觉反馈。
- **圆角美学**：广泛使用宿主提供的 `RoundedTextBox` 和 `ButtonPrimary`，并通过 `BorderRadius` 属性（通常为 8px）实现柔和的圆角效果。

### 3. 关键组件与依赖
- **宿主控件复用**：项目严重依赖 `SuchByte.MacroDeck.GUI.CustomControls` 命名空间。核心控件包括：
  - `RoundedTextBox` / `RoundedComboBox`：用于数据输入，自带占位符（`PlaceHolderText`）和图标支持。
  - `ButtonPrimary`：主操作按钮，支持进度显示和 Windows 强调色集成。
- **配置视图目录**：
  - `GUI/`：存放简单动作的配置窗口（如快捷键、命令选择）。
  - `Views/`：存放复杂动作的配置视图（如多热键、应用启动器）。

### 4. 开发者规范与约束
- **严禁手动修改 Designer 文件**：`.Designer.cs` 中的代码由设计器维护，手动编辑极易导致设计器崩溃或布局丢失。所有 UI 调整应通过 Visual Studio 的窗体设计器完成。
- **保持宿主风格一致**：禁止使用标准的 `System.Windows.Forms.TextBox` 或 `Button`，必须使用宿主提供的自定义控件以确保插件在 Macro Deck 中看起来是“原生”的。
- **本地化优先**：界面中的所有静态文本（Label, Button Text）不得硬编码，必须通过 `Language/PluginStrings.cs` 或资源文件引用，以支持多语言切换。