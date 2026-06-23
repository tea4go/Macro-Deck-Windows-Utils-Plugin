namespace SuchByte.WindowsUtils.Language;

/// <summary>
/// 插件居所字符串容器类，存储所有可本地化的文本字符串。
/// 字段默认値为英文，将在居所文件加载时被覆盖
/// </summary>
public class PluginStrings
{
    // 语言元信息
    /// <summary>居所语言名称，用于区分语言包</summary>
    public string __Language__ = "English";
    /// <summary>居所语言编码（如 "en"、"zh"）</summary>
    public string __LanguageCode__ = "en";
    /// <summary>语言包作者</summary>
    public string __Author__ = "Macro Deck";

    // 动作名称与描述
    /// <summary>降低音量动作的显示名称</summary>
    public string ActionDecreaseVolume = "Decrease volume";
    /// <summary>降低音量动作的详细描述</summary>
    public string ActionDecreaseVolumeDescription = "Decrease the volume of the current playback device";
    /// <summary>增加音量动作的显示名称</summary>
    public string ActionIncreaseVolume = "Increase volume";
    /// <summary>增加音量动作的详细描述</summary>
    public string ActionIncreaseVolumeDescription = "Increase the volume of the current playback device";
    /// <summary>静音动作的显示名称</summary>
    public string ActionMuteVolume = "Mute volume";
    /// <summary>静音动作的详细描述</summary>
    public string ActionMuteVolumeDescription = "Mute the current playback device";
    /// <summary>快捷键动作的显示名称</summary>
    public string ActionHotkey = "Hotkey";
    /// <summary>快捷键动作的详细描述</summary>
    public string ActionHotkeyDescription = "Single hotkey";
    /// <summary>打开文件动作的显示名称</summary>
    public string ActionOpenFile = "Open file";
    /// <summary>打开文件动作的详细描述</summary>
    public string ActionOpenFileDescription = "Open any file";
    /// <summary>打开文件夹动作的显示名称</summary>
    public string ActionOpenFolder = "Open folder";
    /// <summary>打开文件夹动作的详细描述</summary>
    public string ActionOpenFolderDescription = "Open a folder";
    /// <summary>启动应用程序动作的显示名称</summary>
    public string ActionStartApplication = "Start application";
    /// <summary>启动应用程序动作的详细描述</summary>
    public string ActionStartApplicationDescription = "Start a application with and without start arguments";
    /// <summary>资源管理器控制动作的显示名称</summary>
    public string ActionExplorerControl = "Explorer control";
    /// <summary>资源管理器控制动作的详细描述</summary>
    public string ActionExplorerControlDescription = "Explorer/browser (back/forward/home/refresh)";
    /// <summary>发送通知动作的显示名称</summary>
    public string ActionNotification = "Send notification";
    /// <summary>发送通知动作的详细描述</summary>
    public string ActionNotificationDescription = "Send a notification with a custom title and message";
    /// <summary>静音麦克风动作的显示名称</summary>
    public string ActionMuteMicrophone = "Mute microphone";
    /// <summary>静音麦克风动作的详细描述</summary>
    public string ActionMuteMicrophoneDescription = "Mute the default microphone";
    /// <summary>电源选项动作的显示名称</summary>
    public string ActionPowerOption = "Power option";
    /// <summary>电源选项动作的详细描述</summary>
    public string ActionPowerOptionDescription = "Turn off your computer based on the power option";
    /// <summary>窗口切换动作的显示名称</summary>
    public string ActionWindowSwitch = "Switch window";
    /// <summary>窗口切换动作的详细描述</summary>
    public string ActionWindowSwitchDescription = "Switch to a window based on its title";

    // UI 通用标签
    /// <summary>应用路径标签文本</summary>
    public string Path = "Path";
    /// <summary>启动参数标签文本</summary>
    public string Arguments = "Arguments";
    /// <summary>文件输入框占位文本：提示用户选择或拖放文件</summary>
    public string ChooseAFileOrDragAndDrop = "Choose a file or drag and drop it here";
    /// <summary>文件夹输入框占位文本：提示用户选择或拖放文件夹</summary>
    public string ChooseAFolderOrDragAndDrop = "Choose a folder or drag and drop it here";
    /// <summary>提问是否导入文件图标的对话框文本</summary>
    public string QuestionImportFilesIcon = "Do you want to import the file's icon?";
    /// <summary>提问是否导入文件类型图标的对话框文本</summary>
    public string QuestionImportFileTypesIcon = "Do you want to import icon of the file type?";
    /// <summary>图标导入对话框标题</summary>
    public string ImportIcon = "Import icon";
    /// <summary>动作标签文本</summary>
    public string Action = "Action";
    /// <summary>后退按键文本</summary>
    public string Back = "Back";
    /// <summary>前进按键文本</summary>
    public string Forward = "Forward";
    /// <summary>主页按键文本</summary>
    public string Home = "Home";
    /// <summary>刷新按键文本</summary>
    public string Refresh = "Refresh";
    /// <summary>选中路径不是文件的错误提示</summary>
    public string SelectedPathNotAFile = "The selected path is not a valid file";
    /// <summary>选中路径不是文件夹的错误提示</summary>
    public string SelectedPathNotAFolder = "The selected path is not a valid folder";
    /// <summary>命令行动作的显示名称</summary>
    public string ActionCommandline = "Command line command";
    /// <summary>命令行动作的详细描述</summary>
    public string ActionCommandlineDescription = "Run a commandline command";
    /// <summary>命令输入标签文本</summary>
    public string Command = "Command";
    /// <summary>工作目录标签文本</summary>
    public string WorkingDirectory = "Working directory";
    /// <summary>保存输出到变量的复选框文本</summary>
    public string SaveOutputToVariable = "Save output to variable";
    /// <summary>变量名输入标签文本</summary>
    public string VariableName = "Variable name";
    /// <summary>图标导入失败的提示文本</summary>
    public string FailedToImportIcon = "Failed to import the icon";
    /// <summary>图标导入成功的提示文本（含图标包名占位符 {0}）</summary>
    public string IconSuccessfullyImportedToX = "Icon successfully imported to {0}";
    /// <summary>写入文本动作的显示名称</summary>
    public string ActionWriteText = "Write text";
    /// <summary>写入文本动作的详细描述</summary>
    public string ActionWriteTextDescription = "Write the configured text onto a selected text input";
    /// <summary>添加变量按键文本</summary>
    public string AddVariable = "Add variable";
    /// <summary>文本输入框占位文本：提示用户在此输入文本</summary>
    public string TypeTextHere = "Type text here";
    /// <summary>操作方式标签文本（启动/停止/显示/隐藏）</summary>
    public string Method = "Method";
    /// <summary>启动操作显示文本</summary>
    public string MethodStart = "Start";
    /// <summary>显示操作显示文本</summary>
    public string MethodShow = "Show";
    /// <summary>隐藏操作显示文本</summary>
    public string MethodHide = "Hide";
    /// <summary>停止操作显示文本</summary>
    public string MethodStop = "Stop";
    /// <summary>通知标题输入标签文本</summary>
    public string Message = "Message";
    /// <summary>通知内容输入标签文本</summary>
    public string Title = "Title";
    /// <summary>窗口标题匹配模式输入标签文本</summary>
    public string Pattern = "Pattern";
    /// <summary>匹配模式下拉标签文本</summary>
    public string MatchMode = "Match mode";
    /// <summary>大小写敏感性复选框文本</summary>
    public string CaseSensitive = "Case sensitive";
}
