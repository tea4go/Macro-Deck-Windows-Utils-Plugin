using System.Collections.Generic;
using System.Text.Json;

namespace SuchByte.WindowsUtils.Models;

/// <summary>
/// 多键序列动作的配置模型，存储一组动作列表及是否同步按键状态的开关
/// </summary>
internal class MultiHotkeyActionConfigModel : ISerializableConfiguration
{
    /// <summary>多键序列中所有动作的列表，每个元素可以是按键动作或延迟动作</summary>
    public List<IMultiHotkeyAction> MultiHotkeyActions { get; set; } = new List<IMultiHotkeyAction>();

    /// <summary>是否将按键状态与应用程序运行状态进行同步</summary>
    public bool SyncButtonState { get; set; } = false;

    /// <summary>将当前配置序列化为 JSON 字符串</summary>
    public string Serialize()
    {
        return JsonSerializer.Serialize(this);
    }

    /// <summary>
    /// 从 JSON 字符串反序列化为 <see cref="MultiHotkeyActionConfigModel"/>，字符串为空时返回默认实例
    /// </summary>
    /// <param name="config">JSON 配置字符串</param>
    public static MultiHotkeyActionConfigModel Deserialize(string config)
    {
        return ISerializableConfiguration.Deserialize<MultiHotkeyActionConfigModel>(config);
    }
}
