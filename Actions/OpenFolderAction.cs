using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using System;
using System.Diagnostics;

namespace SuchByte.WindowsUtils.Actions;


/// <summary>
/// 打开文件夹动作：使用系统默认程序（通常是 Windows 资源管理器）打开指定目录
/// </summary>
public class OpenFolderAction : PluginAction
{
    /// <summary>动作显示名称</summary>
    public override string Name => PluginLanguageManager.PluginStrings.ActionOpenFolder;

    /// <summary>动作描述</summary>
    public override string Description => PluginLanguageManager.PluginStrings.ActionOpenFolderDescription;

    /// <summary>支持配置界面</summary>
    public override bool CanConfigure => true;

    /// <summary>
    /// 动作触发：解析配置中的目录路径并使用系统默认程序将其打开
    /// 使用 UseShellExecute=true 确保由系统选择合适的程序来处理该路径
    /// </summary>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        if (!String.IsNullOrWhiteSpace(this.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.Configuration);
                var path = configurationObject["path"].ToString();

                // UseShellExecute=true 让系统选择默认程序打开文件夹（通常是 Explorer）
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
    /// 返回动作的配置界面控件（文件夹选择模式）
    /// </summary>
    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new FileFolderSelector(this, actionConfigurator, SelectType.FOLDER);
    }
}
