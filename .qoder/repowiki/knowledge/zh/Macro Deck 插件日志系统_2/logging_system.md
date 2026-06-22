## 1. 系统概述
本插件（Macro Deck Windows Utils）并未引入独立的第三方日志框架（如 NLog、Serilog 或 log4net），而是完全依赖宿主应用程序 **Macro Deck 2** 提供的核心日志服务 `SuchByte.MacroDeck.Logging.MacroDeckLogger`。这种设计确保了插件产生的日志能够无缝集成到 Macro Deck 主程序的日志流中，便于统一管理和排查问题。

## 2. 核心组件与文件
- **日志入口**：`SuchByte.MacroDeck.Logging.MacroDeckLogger`（通过引用 `libs/Macro Deck 2.dll` 获得）。
- **主要使用场景**：
  - **异常捕获**：在 `Actions/NotificationAction.cs`、`Actions/PowerOptionAction.cs` 等动作执行失败时记录错误信息。
  - **配置管理**：在 `ViewModels/MultiHotkeyActionConfigViewModel.cs` 中记录配置保存的成功或失败状态。
  - **业务逻辑追踪**：在 `Services/ApplicationLauncher.cs` 中记录进程操作（如关闭进程）的追踪信息（Trace）和警告（Warning）。

## 3. 架构与约定
- **静态工具类模式**：`MacroDeckLogger` 作为静态类被直接调用，无需实例化。
- **上下文关联**：所有日志调用均要求传入插件实例（通常为 `Main.Instance` 或 `PluginInstance.Main`），以便宿主程序识别日志来源。
- **日志级别策略**：
  - `Error`：用于捕获未预期的异常或无效的操作参数（如无效的电源选项）。
  - `Warning`：用于处理非致命但需要注意的情况，如文件路径为空或目标进程不存在。
  - `Info`：用于记录关键的业务状态变更，如配置成功保存。
  - `Trace`：用于记录详细的调试信息，如正在终止的进程 ID 和名称。

## 4. 开发者规范
- **统一接口**：严禁在插件中使用 `Console.WriteLine` 或 `Debug.WriteLine` 进行生产环境的日志输出，必须使用 `MacroDeckLogger`。
- **异常处理**：在 `try-catch` 块中捕获异常后，应通过 `MacroDeckLogger.Error` 记录异常消息及堆栈跟踪（`ex.StackTrace`）。
- **语言适配**：日志内容应根据上下文选择适当的语言（目前代码中存在中文和英文混用的情况，建议后续统一为英文或根据插件语言设置动态切换）。