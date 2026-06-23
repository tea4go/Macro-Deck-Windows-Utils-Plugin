using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using System;
using System.Linq;

namespace SuchByte.WindowsUtils.Actions;

/// <summary>
/// 输入文本动作：将配置的文本内容模拟键盘输入到当前激活的输入框中
/// 支持嵌入 Macro Deck 变量，在输入时自动替换变量值
/// </summary>
public class WriteTextAction : PluginAction
{
    /// <summary>动作显示名称</summary>
    public override string Name => PluginLanguageManager.PluginStrings.ActionWriteText;

    /// <summary>动作描述</summary>
    public override string Description => PluginLanguageManager.PluginStrings.ActionWriteTextDescription;

    /// <summary>支持配置界面</summary>
    public override bool CanConfigure => true;

    /// <summary>
    /// 动作触发：解析配置中的文本，替换嵌入的变量占位符，并将最终文本模拟键盘输入
    /// 变量占位符格式为 {variableName}，替换时对大小写不敏感
    /// </summary>
    public override void Trigger(string clientId, ActionButton actionButton)
    {
        if (!string.IsNullOrWhiteSpace(this.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.Configuration);
                var text = configurationObject["text"].ToString();

                // 查找文本中所有嵌入的变量占位符 {varName}，匹配时对大小写不敏感
                var variables = MacroDeck.Variables.VariableManager.Variables.Where(x => text.ToLower().Contains("{" + x.Name.ToLower() + "}"));

                // 将每个匹配到的变量占位符替换为实际变量值，替换时对大小写不敏感
                foreach (MacroDeck.Variables.Variable variable in variables)
                {
                    text = text.Replace("{" + variable.Name + "}", variable.Value.ToString(), StringComparison.OrdinalIgnoreCase);
                }

                // 将处理后的文本模拟键盘输入到当前激活的输入框
                PluginInstance.Main.InputSimulator.Keyboard.TextEntry(text);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Warning(PluginInstance.Main, typeof(WriteTextAction) + ": " + ex.Message);
            }
        }
    }

    /// <summary>
    /// 返回动作的配置界面控件
    /// </summary>
    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new TextSelector(this);
    }
}
