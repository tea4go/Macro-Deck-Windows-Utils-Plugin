using SuchByte.WindowsUtils.Models;

namespace SuchByte.WindowsUtils.ViewModels;

/// <summary>
/// 可序列化配置的 ViewModel 接口，定义加载配置和保存配置的标准方法，所有配置页 ViewModel 均需实现此接口
/// </summary>
internal interface ISerializableConfigViewModel
{
    /// <summary>当前接管的可序列化配置模型对象</summary>
    protected ISerializableConfiguration SerializableConfiguration { get; }

    /// <summary>将 UI 控件的当前状态应用到配置模型和插件动作</summary>
    void SetConfig();

    /// <summary>保存配置：成功返回 true，出错返回 false</summary>
    bool SaveConfig();
}
