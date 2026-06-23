using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.ViewModels;
using System;

namespace SuchByte.WindowsUtils.Views;

/// <summary>
/// 多键序列动作的配置视图（View），继承自 ActionConfigControl，内嵌 ViewModel 层处理配置数据的加载和保存
/// </summary>
public partial class MultiHotkeyActionConfigView : ActionConfigControl
{
    /// <summary>当前视图的 ViewModel，负责配置模型与插件动作之间的数据传递</summary>
    private readonly MultiHotkeyActionConfigViewModel _viewModel;

    /// <summary>
    /// 构造函数：初始化并创建 ViewModel
    /// </summary>
    /// <param name="action">要配置的插件动作</param>
    public MultiHotkeyActionConfigView(PluginAction action)
    {
        InitializeComponent();
        this._viewModel = new MultiHotkeyActionConfigViewModel(action);
    }

    /// <summary>表单加载事件处理器（暂无额外逻辑）</summary>
    private void MultiHotkeyActionConfigView_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 用户点击保存按键时触发，将当前 UI 配置保存到插件动作
    /// </summary>
    /// <returns>保存成功返回 true，失败返回 false</returns>
    public override bool OnActionSave()
    {
        return this._viewModel.SaveConfig();
    }
}
