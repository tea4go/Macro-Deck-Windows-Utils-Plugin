该仓库采用基于 `try-catch` 的防御性编程模式进行错误处理，主要依赖宿主框架（Macro Deck）提供的日志工具 `MacroDeckLogger` 进行错误记录和状态反馈。

### 1. 核心策略
- **静默失败与日志记录**：在大多数 `Action`（如 `CommandlineAction`, `NotificationAction`, `PowerOptionAction`）的 `Trigger` 方法中，使用 `try-catch (Exception e)` 包裹核心逻辑。捕获异常后，通常调用 `MacroDeckLogger.Error` 或 `Debug.WriteLine` 记录错误信息，防止插件崩溃导致宿主程序不稳定。
- **前置校验**：在 `ApplicationLauncher` 等服务类中，通过检查参数有效性（如 `string.IsNullOrWhiteSpace`）和进程存在性，提前返回并记录 `Warning` 日志，避免执行无效操作。
- **资源清理**：在涉及非托管资源（如 P/Invoke 调用 `OpenProcess`）时，使用 `finally` 块确保 `CloseHandle` 被调用，防止资源泄漏。

### 2. 关键组件
- **MacroDeckLogger**：作为统一的日志入口，用于记录 `Error`、`Warning` 和 `Trace` 级别的信息。例如在 `NotificationAction.cs` 中捕获解析配置异常时记录错误。
- **ApplicationLauncher.cs**：展示了更细致的错误处理流程，包括对空路径的检查、进程查找失败的警告以及 API 调用失败的空值处理。

### 3. 开发规范
- **禁止抛出未处理异常**：所有公开的动作触发点（`Trigger`）必须包含顶层异常捕获。
- **使用框架日志**：优先使用 `MacroDeckLogger` 而非 `Console.WriteLine`，以确保错误信息能正确集成到 Macro Deck 的日志系统中。
- **防御性解析**：在解析 JSON 配置或枚举时，应假设输入可能损坏，并做好异常准备。