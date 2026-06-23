using System.Text.Json;
using System.Text.Json.Serialization;

namespace SuchByte.WindowsUtils.Models;

/// <summary>
/// 启动应用程序动作的配置模型，存储应用路径、启动参数、管理员权限及启动方式等配置
/// </summary>
internal class StartApplicationActionConfigModel : ISerializableConfiguration
{
    /// <summary>
    /// 应用程序可执行文件路径。
    /// 使用 [JsonPropertyName("path")] 以保证与旧版本 JSON 配置的向后兼容
    /// </summary>
    [JsonPropertyName("path")] // To ensure backward compatibility with older versions of this plugin
    public string Path { get; set; } = "";

    /// <summary>
    /// 启动应用程序时传入的命令行参数。
    /// 使用 [JsonPropertyName("arguments")] 以保证与旧版本 JSON 配置的向后兼容
    /// </summary>
    [JsonPropertyName("arguments")] // To ensure backward compatibility with older versions of this plugin
    public string Arguments { get; set; } = "";

    /// <summary>是否以管理员权限运行应用程序（UAC 提权）</summary>
    public bool RunAsAdmin { get; set; } = false;

    /// <summary>是否将按键标识状态与应用程序运行状态进行同步</summary>
    public bool SyncButtonState { get; set; } = false;

    /// <summary>应用程序的操作方式：启动/停止/显示/隐藏</summary>
    public StartMethod StartMethod { get; set; } = StartMethod.Start;

    /// <summary>将当前配置序列化为 JSON 字符串</summary>
    public string Serialize()
    {
        return JsonSerializer.Serialize(this);
    }

    /// <summary>
    /// 从 JSON 字符串反序列化为 <see cref="StartApplicationActionConfigModel"/>，字符串为空时返回默认实例
    /// </summary>
    /// <param name="config">JSON 配置字符串</param>
    public static StartApplicationActionConfigModel Deserialize(string config)
    {
        return ISerializableConfiguration.Deserialize<StartApplicationActionConfigModel>(config);
    }
}

/// <summary>
/// 应用程序操作方式枚举
/// </summary>
public enum StartMethod
{
    /// <summary>启动应用程序</summary>
    Start,
    /// <summary>停止应用程序（Kill）</summary>
    Stop,
    /// <summary>展示应用程序窗口（前台）</summary>
    Show,
    /// <summary>隐藏应用程序窗口（最小化）</summary>
    Hide,
}
