using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Actions;
using SuchByte.WindowsUtils.Language;
using System.Collections.Generic;
using System.Linq;
using WindowsInput;

namespace SuchByte.WindowsUtils;

/// <summary>
/// 插件全局单例访问器，提供在整个插件任意位置访问主实例的静态入口点
/// </summary>
public static class PluginInstance
{
    /// <summary>插件主实例的静态引用</summary>
    public static Main Main;
}

/// <summary>
/// Windows Utils 插件主类，负责插件初始化、动作注册和全局定时器管理
/// 继承自 MacroDeckPlugin，由 Macro Deck 主程序在插件启用时调用
/// </summary>
public class Main : MacroDeckPlugin
{
    /// <summary>插件主实例的静态单例引用，供其他类直接访问</summary>
    public static Main Instance;

    /// <summary>用于模拟键盘输入的全局 InputSimulator 实例，所有热键相关动作共享此实例</summary>
    public InputSimulator InputSimulator = new();

    /// <summary>全局节拍定时器，每 2 秒触发一次，用于驱动需要定期检查的动作（如同步按键状态）</summary>
    public System.Timers.Timer TickTimer;

    /// <summary>
    /// 构造函数：设置静态单例引用，供全局访问
    /// </summary>
    public Main()
    {
        Instance = this;
        PluginInstance.Main = this;
    }

    /// <summary>
    /// 插件启用入口：由 Macro Deck 在加载插件时调用
    /// 负责初始化语言包、注册所有支持的动作并启动全局定时器
    /// </summary>
    public override void Enable()
    {
        // 初始化语言包，并注册语言切换监听器
        PluginLanguageManager.Initialize();
        // 注册本插件提供的所有动作（注释部分为尚未完成的 TODO 功能）
        this.Actions = new List<PluginAction>
        {
            new WriteTextAction(),
            new CommandlineAction(),
            new OpenFileAction(),
            new OpenFolderAction(),
            new StartApplicationAction(),
            new IncreaseVolumeAction(),
            new DecreaseVolumeAction(),
            new MuteVolumeAction(),
            new WindowsExplorerControlAction(),
            //new WebrequestAction(), // TODO
            //new WindowsOpenWebsiteAction(), // TODO
            new HotkeyAction(),
            //new MultiHotkeyAction(),
            new NotificationAction(),
            new MuteMicrophoneAction(),
            new PowerOptionAction(),
            new WindowSwitchAction(),
        };
        MacroDeckLogger.Information(this, $"Windows Utils plugin enabled. Actions={string.Join(", ", this.Actions.Select(action => action.Name))}");

        // 初始化全局节拍定时器，每 2000ms 触发一次
        // 用于驱动需要定期轮询的功能（如 StartApplicationAction 的按键状态同步）
        this.TickTimer = new System.Timers.Timer()
        {
            Enabled = true,
            Interval = 2000,
        };
        this.TickTimer.Start();
    }
}
