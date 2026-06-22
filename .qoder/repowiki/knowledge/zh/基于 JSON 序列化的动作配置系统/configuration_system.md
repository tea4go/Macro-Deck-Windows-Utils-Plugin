## 1. 系统概述
该插件采用**基于 JSON 的序列化配置模式**，将每个动作（Action）的配置数据存储在 `PluginAction.Configuration` 字符串属性中。这种设计遵循 Macro Deck 宿主框架的规范，实现了配置的轻量级存储与跨会话持久化。

## 2. 核心架构与组件
- **配置模型层 (`Models/ISerializableConfiguration.cs`)**：定义了统一的序列化接口，利用 `System.Text.Json` 进行对象与 JSON 字符串的双向转换。所有具体的配置模型（如 `StartApplicationActionConfigModel`）均实现此接口。
- **视图模型层 (`ViewModels/ISerializableConfigViewModel.cs`)**：作为 UI 与底层配置模型的桥梁，负责在用户交互时同步更新配置并触发保存逻辑。
- **UI 配置控件 (`GUI/*.cs`)**：提供可视化的配置界面。部分旧式或简单配置（如 `HotkeyConfigurator`）直接使用 `Newtonsoft.Json.Linq.JObject` 进行手动解析与组装，而复杂配置则通过 ViewModel 绑定到强类型模型。

## 3. 关键设计决策
- **向后兼容性**：在配置模型中使用 `[JsonPropertyName]` 属性（例如在 `StartApplicationActionConfigModel` 中），确保在字段重命名或结构调整时，旧版本的配置文件仍能正确加载。
- **配置摘要 (`ConfigurationSummary`)**：在每个动作保存配置时，会生成一个简短的文本摘要（如快捷键组合字符串或应用路径），用于在 Macro Deck 的主界面按钮上直观显示当前配置状态。
- **混合序列化策略**：虽然引入了 `System.Text.Json` 作为标准，但部分代码仍保留了对 `Newtonsoft.Json` 的依赖，主要用于处理动态键值对（如快捷键的各个修饰键状态）。

## 4. 开发者规范
- **新增动作配置**：必须创建对应的 `ConfigModel` 类并实现 `ISerializableConfiguration` 接口。
- **UI 交互逻辑**：在 `ActionConfigControl` 的 `OnActionSave` 方法中，务必调用模型的 `Serialize()` 方法并将结果赋值给 `pluginAction.Configuration`。
- **空值处理**：在 `Trigger` 执行逻辑前，必须先检查 `Configuration` 是否为空，并使用 `Deserialize` 方法安全地还原配置对象，防止因配置缺失导致插件崩溃。