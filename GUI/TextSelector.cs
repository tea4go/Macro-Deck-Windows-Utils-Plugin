using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.WindowsUtils.Actions;
using SuchByte.WindowsUtils.Language;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SuchByte.WindowsUtils.GUI;

/// <summary>
/// 文本输入配置界面：配置要模拟键盘输入的文本内容，支持嵌入 Macro Deck 变量
/// </summary>
public partial class TextSelector : ActionConfigControl
{
    /// <summary>当前正在配置的输入文本动作实例</summary>
    WriteTextAction pluginAction;

    /// <summary>
    /// 构造函数：初始化界面并加载已有配置
    /// </summary>
    public TextSelector(WriteTextAction pluginAction)
    {
        this.pluginAction = pluginAction;
        InitializeComponent();

        this.btnAddVariable.Text = PluginLanguageManager.PluginStrings.AddVariable;
        this.textBox.PlaceHolderText = PluginLanguageManager.PluginStrings.TypeTextHere;

        this.LoadConfig();
    }

    /// <summary>
    /// 保存配置：文本不能为空，序列化并保存
    /// 配置摘要不超过 150 字符，超长则截断并加进略号
    /// </summary>
    public override bool OnActionSave()
    {
        if (String.IsNullOrWhiteSpace(this.textBox.Text))
        {
            return false;
        }

        JObject jObject = new JObject
        {
            ["text"] = this.textBox.Text,
        };

        this.pluginAction.Configuration = jObject.ToString();
        // 摘要不超过 150 字符，超长则截断取前 147 字符加进略号
        this.pluginAction.ConfigurationSummary = this.textBox.Text.Length <= 150 ? this.textBox.Text : (this.textBox.Text.Substring(0, 147) + "...");

        return true;
    }

    /// <summary>
    /// 从已保存配置中加载文本并填充到文本框
    /// </summary>
    private void LoadConfig()
    {
        if (!String.IsNullOrWhiteSpace(this.pluginAction.Configuration))
        {
            JObject jObject = JObject.Parse(this.pluginAction.Configuration);
            this.textBox.Text = jObject["text"].ToString();
        }
    }

    /// <summary>
    /// “添加变量” 按键点击：弹出右键菜单展示所有可用的 Macro Deck 变量
    /// 菜单在按键的左下角弹出
    /// </summary>
    private void BtnAddVariable_Click(object sender, EventArgs e)
    {
        // 每次弹出前先清空菜单项，确保显示最新的变量列表
        this.variablesContextMenu.Items.Clear();
        foreach (MacroDeck.Variables.Variable variable in MacroDeck.Variables.VariableManager.Variables)
        {
            ToolStripMenuItem item = new ToolStripMenuItem
            {
                ForeColor = Color.White,
                Text = variable.Name,
            };
            item.Click += AddVariableContextMenuItemClick;
            this.variablesContextMenu.Items.Add(item);
        }
        // 将菜单在按键的左下角展示，先将局部坐标转换为屏幕坐标
        this.variablesContextMenu.Show(PointToScreen(new Point(((ButtonPrimary)sender).Bounds.Left, ((ButtonPrimary)sender).Bounds.Bottom)));
    }

    /// <summary>
    /// 变量菜单项点击：将选中变量以 {variableName} 格式插入到当前光标位置
    /// 插入后将光标移动到插入内容的末尾
    /// </summary>
    private void AddVariableContextMenuItemClick(object sender, EventArgs e)
    {
        ToolStripMenuItem item = (ToolStripMenuItem)sender;
        // 记录当前光标位置以便插入后恢复
        var selectionIndex = this.textBox.SelectionStart;
        // 将 {variableName} 插入到光标位置
        this.textBox.Text = this.textBox.Text.Insert(selectionIndex, "{" + item.Text + "}");
        // 将光标移动到插入内容的末尾
        this.textBox.SelectionStart = selectionIndex + ("{" + item.Text + "}").Length;
    }
}
