
namespace SuchByte.WindowsUtils.Models;

/// <summary>
/// UWP（通用 Windows 平台）应用包模型，存储应用的显示名称和启动路径
/// </summary>
public class UWPPackageModel
{
    /// <summary>UWP 应用包的可读显示名称</summary>
    public string DisplayName { get; private set; }

    /// <summary>UWP 应用包的启动路径（shell: URI 或安装目录）</summary>
    public string Path { get; private set; }

    /// <summary>
    /// 构造函数：初始化 UWP 应用包模型
    /// </summary>
    /// <param name="name">UWP 应用的显示名称</param>
    /// <param name="path">UWP 应用的启动路径</param>
    public UWPPackageModel(string name, string path)
    {
        DisplayName = name;
        Path = path;
    }
}
