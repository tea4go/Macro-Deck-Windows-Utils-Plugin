using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Models;
using System;

namespace SuchByte.WindowsUtils.ViewModels;

/// <summary>
/// 启动应用程序动作的配置页 ViewModel，负责将 UI 控件状态与 <see cref="StartApplicationActionConfigModel"/> 和插件动作进行同步
/// </summary>
internal class StartApplicationActionConfigViewModel : ISerializableConfigViewModel
{
    /// <summary>当前正在配置的插件动作</summary>
    private readonly PluginAction _action;

    /// <summary>启动应用程序动作配置模型</summary>
    public StartApplicationActionConfigModel Configuration { get; set; }

    ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

    /// <summary>应用程序可执行文件路径，代理配置模型属性</summary>
    public string Path
    {
        get => Configuration.Path;
        set => Configuration.Path = value;
    }

    /// <summary>启动参数，代理配置模型属性</summary>
    public string Arguments
    {
        get => Configuration.Arguments;
        set => Configuration.Arguments = value;
    }

    /// <summary>是否以管理员权限运行，代理配置模型属性</summary>
    public bool RunAsAdmin
    {
        get => Configuration.RunAsAdmin;
        set => Configuration.RunAsAdmin = value;
    }

    /// <summary>是否同步按键状态，代理配置模型属性</summary>
    public bool SyncButtonState
    {
        get => Configuration.SyncButtonState;
        set => Configuration.SyncButtonState = value;
    }

    /// <summary>应用程序操作方式（启动/停止/显示/隐藏），代理配置模型属性</summary>
    public StartMethod StartMethod
    {
        get => Configuration.StartMethod;
        set => Configuration.StartMethod = value;
    }

    /// <summary>
    /// 构造函数：从插件动作的 JSON 配置中反序列化配置模型
    /// </summary>
    /// <param name="action">要配置的插件动作</param>
    public StartApplicationActionConfigViewModel(PluginAction action)
    {
        this.Configuration = StartApplicationActionConfigModel.Deserialize(action.Configuration);
        this._action = action;
    }

    /// <summary>
    /// 保存配置：调用 SetConfig 并记录日志，异常时写入错误日志
    /// </summary>
    /// <returns>始终返回 true</returns>
    public bool SaveConfig()
    {
        try
        {
            SetConfig();
            MacroDeckLogger.Info(PluginInstance.Main, $"{GetType().Name}: config saved");
        }
        catch (Exception ex)
        {
            MacroDeckLogger.Error(PluginInstance.Main, $"{GetType().Name}: Error while saving config: { ex.Message + Environment.NewLine + ex.StackTrace }");
        }
        return true;
    }

    /// <summary>
    /// 将配置序列化并回写到插件动作，同时将应用路径设为配置摘要
    /// </summary>
    public void SetConfig()
    {
        _action.ConfigurationSummary = Configuration.Path.ToString();
        _action.Configuration = Configuration.Serialize();
    }
}
