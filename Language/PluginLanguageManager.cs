using SuchByte.MacroDeck.Language;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace SuchByte.WindowsUtils.Language;

/// <summary>
/// 插件语言管理器，负责从嵌入资源加载对应居所语言的 XML 文件并反序列化为 <see cref="PluginStrings"/>。
/// 监听 Macro Deck 的居所语言切换事件与自动重新加载
/// </summary>
public static class PluginLanguageManager
{
    /// <summary>当前已加载的插件居所字符串对象，默认初始化为英文居所</summary>
    public static PluginStrings PluginStrings = new PluginStrings();

    /// <summary>
    /// 初始化语言管理器：立即加载当前语言，并注册语言切换事件处理器实现动态切换
    /// </summary>
    public static void Initialize()
    {
        LoadLanguage();
        // 订阅 Macro Deck 的语言切换事件，当用户在 Macro Deck 中切换语言时自动重载
        LanguageManager.LanguageChanged += (s, e) => LoadLanguage();
    }

    /// <summary>
    /// 根据 Macro Deck 当前设置的语言名称加载对应 XML 资源并反序列化为 <see cref="PluginStrings"/>
    /// </summary>
    private static void LoadLanguage()
    {
        // 获取 Macro Deck 当前设置的语言名称
        string languageName = LanguageManager.GetLanguageName();

        try
        {
            // 从嵌入资源读取 XML 内容并反序列化为 PluginStrings
            using TextReader reader = new StringReader(GetXMLLanguageResource(languageName));
            PluginStrings = (PluginStrings)new XmlSerializer(typeof(PluginStrings)).Deserialize(reader);
        }
        catch
        {
            //fallback - should never occur if things are done properly
            PluginStrings = new PluginStrings();
        }
    }

    /// <summary>
    /// 从程序集嵌入资源中读取指定语言的 XML 内容；若该语言资源不存在，回退到英文
    /// </summary>
    /// <param name="languageName">Macro Deck 语言名称（如 "Chinese"、"English"）</param>
    /// <returns>XML 语言文件的内容字符串</returns>
    private static string GetXMLLanguageResource(string languageName)
    {
        var assembly = typeof(PluginStrings).Assembly;
        // 若语言名称为空或嵌入资源中不存在对应的 xml，则回退到英文
        if (string.IsNullOrEmpty(languageName)
            || !assembly.GetManifestResourceNames().Any(name => name.EndsWith($"{languageName}.xml")))
        {
            languageName = "English"; //This should always be present as default, otherwise the code goes to fallback implementation.
        }

        // 构造嵌入资源的全限定名称（格式：命名空间.Resources.Languages.{languageName}.xml）
        string languageFileName = $"SuchByte.WindowsUtils.Resources.Languages.{languageName}.xml";

        using var resourceStream = assembly.GetManifestResourceStream(languageFileName);
        using var streamReader = new StreamReader(resourceStream);
        return streamReader.ReadToEnd();
    }
}
