using System.Text.Json;

namespace SuchByte.WindowsUtils.Models;

/// <summary>
/// 可序列化配置的通用接口，实现此接口的配置模型可以被序列化为 JSON 并从 JSON 反序列化
/// </summary>
public interface ISerializableConfiguration
{
    /// <summary>将当前配置序列化为 JSON 字符串</summary>
    public string Serialize();

    /// <summary>
    /// 静态反序列化辅助方法：若配置字符串不为空则反序列化，否则返回默认实例
    /// </summary>
    /// <typeparam name="T">实现了 ISerializableConfiguration 且具有无参构造函数的类型</typeparam>
    /// <param name="configuration">JSON 配置字符串</param>
    /// <returns>反序列化后的配置对象，或新建的默认实例</returns>
    protected static T Deserialize<T>(string configuration) where T : ISerializableConfiguration, new() =>
        !string.IsNullOrWhiteSpace(configuration) ? JsonSerializer.Deserialize<T>(configuration) : new T();
}
