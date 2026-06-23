using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Models;
using System;
using System.Collections.Generic;

namespace SuchByte.WindowsUtils.ViewModels;

/// <summary>
/// 多键序列动作的配置页 ViewModel，负责在配置模型和插件动作之间传递数据
/// </summary>
internal class MultiHotkeyActionConfigViewModel : ISerializableConfigViewModel
{
    /// <summary>当前正在配置的插件动作（用于保存配置时回写）</summary>
    private readonly PluginAction _action;

    /// <summary>多键序列配置模型，包含动作列表和同步按键状态的开关</summary>
    public MultiHotkeyActionConfigModel Configuration { get; set; }

    ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

    /// <summary>多键序列动作列表，代理访问配置模型的属性</summary>
    public List<IMultiHotkeyAction> MultiHotkeyActions
    {
        get => Configuration.MultiHotkeyActions;
        set => Configuration.MultiHotkeyActions = value;
    }

    /// <summary>是否同步按键状态，代理访问配置模型的属性</summary>
    public bool SyncButtonState
    {
        get => Configuration.SyncButtonState;
        set => Configuration.SyncButtonState = value;
    }

    /// <summary>
    /// 构造函数：从插件动作的 JSON 配置中反序列化配置模型
    /// </summary>
    /// <param name="action">要配置的插件动作</param>
    public MultiHotkeyActionConfigViewModel(PluginAction action)
    {
        this.Configuration = MultiHotkeyActionConfigModel.Deserialize(action.Configuration);
        this._action = action;
    }

    /// <summary>
    /// 保存配置：调用 SetConfig 并记录日志，异常时写入错误日志
    /// </summary>
    /// <returns>始终返回 true（即便出错也尝试继续）</returns>
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
    /// 将配置序列化并回写到插件动作，同时更新配置摘要（显示动作数量）
    /// </summary>
    public void SetConfig()
    {
        _action.ConfigurationSummary = $"{Configuration.MultiHotkeyActions.Count} actions";
        _action.Configuration = Configuration.Serialize();
    }
}
