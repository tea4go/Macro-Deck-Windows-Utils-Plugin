using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using System.Diagnostics;

namespace SuchByte.WindowsUtils.Actions;

/// <summary>
/// 打开文件动作：使用系统默认关联程序打开指定路径的文件
/// </summary>
public class OpenFileAction : PluginAction
{
    /// <summary>动作显示名称</summary>
    public override string Name => PluginLanguageManager.PluginStrings.ActionOpenFile;

    /// <summary>动作描述</summary>
    public override string Description => PluginLanguageManager.PluginStrings.ActionOpenFile;

    /// <summary>支持配置界面</summary>
    public override bool CanConfigure => true;

    /// <summary>
    /// 动作触发：解析配置中的文件路径并调用系统默认程序将其打开
    /// 使用 UseShellExecute=true 确保使用系统关联的默认应用打开
    /// </summary>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        if (!string.IsNullOrWhiteSpace(this.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.Configuration);
                var path = configurationObject["path"].ToString();

                // UseShellExecute=true 表示让操作系统选择合适的程序来打开该文件
                var p = new Process
                {
                    StartInfo = new ProcessStartInfo(path)
                    {
                        UseShellExecute = true,
                    }
                };
                p.Start();
            }
            catch { }
        }
    }

    /// <summary>
    /// 返回动作的配置界面控件（文件选择模式）
    /// </summary>
    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new FileFolderSelector(this, actionConfigurator, SelectType.FILE);
    }
}
