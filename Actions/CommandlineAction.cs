using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using System;
using System.Diagnostics;

namespace SuchByte.WindowsUtils.Actions;

/// <summary>
/// 命令行命令动作：执行用户配置的 cmd 命令，支持将命令输出保存到 Macro Deck 变量
/// </summary>
public class CommandlineAction : PluginAction
{
    /// <summary>动作显示名称，来自语言包</summary>
    public override string Name => PluginLanguageManager.PluginStrings.ActionCommandline;

    /// <summary>动作描述，来自语言包</summary>
    public override string Description => PluginLanguageManager.PluginStrings.ActionCommandlineDescription;

    /// <summary>该动作支持配置界面</summary>
    public override bool CanConfigure => true;

    /// <summary>
    /// 动作触发时执行：解析配置并通过 cmd.exe 运行配置的命令
    /// 如果启用了“保存输出到变量”，则捕获命令的标准输出并写入指定类型的 Macro Deck 变量
    /// </summary>
    /// <param name="clientId">触发动作的客户端 ID</param>
    /// <param name="actionButton">关联的按键</param>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        if (!string.IsNullOrWhiteSpace(this.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.Configuration);
                var workingDirectory = configurationObject["workingDirectory"].ToString();
                var command = configurationObject["command"].ToString();
                bool.TryParse(configurationObject["saveVariable"].ToString(), out bool saveVariable);

                // 使用 cmd.exe /C 执行命令：/C 表示执行完命令后自动退出
                // 若需保存输出，则启用 RedirectStandardOutput 以便读取输出内容
                var p = new Process
                {
                    StartInfo = new ProcessStartInfo("cmd.exe")
                    {
                        UseShellExecute = false,
                        WorkingDirectory = workingDirectory,
                        Arguments = "/C " + command,
                        RedirectStandardOutput = saveVariable,  // 仅当需要保存输出时才重定向
                        WindowStyle = ProcessWindowStyle.Hidden, // 隐藏 cmd 窗口，避免闪现黑色命令行
                    }
                };
                p.Start();
                if (saveVariable)
                {
                    // 读取命令全部输出并移除换行符（不同命令输出格式可能不同）
                    var output = p.StandardOutput.ReadToEnd().Replace(Environment.NewLine, String.Empty);
                    Debug.WriteLine(output);
                    var variableName = configurationObject["variableName"].ToString();
                    // 将字符串类型名转为 VariableType 枚举，对大小写不敏感
                    Enum.TryParse(typeof(VariableType), configurationObject["variableType"].ToString(), true, out object type);
                    VariableManager.SetValue(variableName, output, (VariableType) type, PluginInstance.Main, null);
                }
            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
        }
    }

    /// <summary>
    /// 返回动作的配置界面控件
    /// </summary>
    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new CommandSelector(this);
    }
}
