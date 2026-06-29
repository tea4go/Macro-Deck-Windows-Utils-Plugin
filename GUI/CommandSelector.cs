using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Language;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using System;
using System.IO;
using System.Windows.Forms;

namespace SuchByte.WindowsUtils.GUI;

/// <summary>
/// 命令行动作配置界面，用于配置要执行的命令、工作目录及输出变量保存选项
/// </summary>
public partial class CommandSelector : ActionConfigControl
{
    /// <summary>当前正在配置的插件动作实例</summary>
    PluginAction pluginAction;

    /// <summary>
    /// 构造函数：初始化命令选择器界面并加载已有配置
    /// </summary>
    /// <param name="pluginAction">关联的插件动作对象，用于读写配置数据</param>
    public CommandSelector(PluginAction pluginAction)
    {
        this.pluginAction = pluginAction;

        InitializeComponent();
        Utils.FontHelper.ApplyMacroDeckFont(this);

        // 根据当前语言设置各控件的显示文本
        this.lblCommand.Text = PluginLanguageManager.PluginStrings.Command;
        this.lblWorkingDirectory.Text = PluginLanguageManager.PluginStrings.WorkingDirectory;
        this.checkSaveVariable.Text = PluginLanguageManager.PluginStrings.SaveOutputToVariable;
        this.workingDirectory.PlaceHolderText = PluginLanguageManager.PluginStrings.ChooseAFolderOrDragAndDrop;
        this.variableName.PlaceHolderText = PluginLanguageManager.PluginStrings.VariableName;

        // 初始化变量类型下拉框，支持四种常见数据类型
        this.variableType.Items.AddRange(new string[]
        {
            "String",
            "Integer",
            "Float",
            "Bool"
        });
        this.variableType.Text = "String"; // 默认选择字符串类型

        // 为工作目录输入框注册拖放事件，支持从文件管理器拖入路径
        this.workingDirectory.AllowDrop = true;
        this.workingDirectory.DragEnter += WorkingDirectory_DragEnter;
        this.workingDirectory.DragDrop += WorkingDirectory_DragDrop;

        // 加载已有配置（编辑已保存动作时恢复之前的配置值）
        this.LoadConfig();
    }

    /// <summary>
    /// 保存动作配置，校验输入合法性后将配置序列化为 JSON 字符串
    /// </summary>
    /// <returns>保存成功返回 true，输入校验失败返回 false</returns>
    public override bool OnActionSave()
    {
        // 命令文本为必填项，若为空则阻止保存
        if (String.IsNullOrWhiteSpace(this.command.Text))
        {
            return false;
        }

        // 若工作目录输入框不为空，则校验该路径是否为有效目录
        // 注意：条件为「不为空时才校验」，若为空则跳过校验（允许不填工作目录）
        if (String.IsNullOrWhiteSpace(this.workingDirectory.Text)) {
            try
            {
                FileAttributes attr = File.GetAttributes(this.workingDirectory.Text);
                // 使用位运算检查路径是否具有 Directory 标志，若没有则说明是文件路径，提示错误
                if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                {
                    using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                    {
                        msgBox.ShowDialog(LanguageManager.Strings.Error, PluginLanguageManager.PluginStrings.SelectedPathNotAFile, MessageBoxButtons.OK);
                    }
                    return false;
                }
            } catch {}
        }

        // 将界面输入序列化为 JSON 配置对象并保存到插件动作
        JObject configurationObject = JObject.FromObject(new
        {
            command = this.command.Text,
            workingDirectory = this.workingDirectory.Text,
            saveVariable = this.checkSaveVariable.Checked,
            variableName = this.variableName.Text,
            variableType = this.variableType.Text,
        });
        this.pluginAction.Configuration = configurationObject.ToString();
        // 配置摘要：显示命令文本，若指定了工作目录则附加 " in <目录路径>"
        this.pluginAction.ConfigurationSummary = this.command.Text + (!String.IsNullOrWhiteSpace(this.workingDirectory.Text) ? " in " + this.workingDirectory.Text : "");
        return true;
    }


    /// <summary>
    /// 处理工作目录输入框的文件拖放事件：将拖入的第一个文件/文件夹路径填入输入框
    /// </summary>
    private void WorkingDirectory_DragDrop(object sender, DragEventArgs e)
    {
        try
        {
            // 获取拖放数据中的第一个文件路径（支持多选时只取第一个）
            string path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            this.workingDirectory.Text = path;
        }
        catch { }
    }

    /// <summary>
    /// 处理拖拽进入事件：检查拖拽内容是否为文件，若是则显示「复制」拖放效果
    /// </summary>
    private void WorkingDirectory_DragEnter(object sender, DragEventArgs e)
    {
        // 仅当拖入内容包含文件路径数据时才允许拖放
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.Copy;
        }
    }

    /// <summary>
    /// 从插件动作的已保存配置中加载数据并填充到界面控件
    /// 仅在配置字符串非空时执行，解析失败时静默忽略（保持控件默认值）
    /// </summary>
    private void LoadConfig()
    {
        if (!string.IsNullOrWhiteSpace(this.pluginAction.Configuration))
        {
            try
            {
                // 将 JSON 配置字符串解析为对象，逐字段还原到界面控件
                JObject configurationObject = JObject.Parse(this.pluginAction.Configuration);
                this.command.Text = configurationObject["command"].ToString();
                this.workingDirectory.Text = configurationObject["workingDirectory"].ToString();
                // 使用 TryParse 安全转换布尔值，避免格式异常导致加载失败
                bool.TryParse(configurationObject["saveVariable"].ToString(), out bool saveVariable);
                this.checkSaveVariable.Checked = saveVariable;
                this.variableName.Text = configurationObject["variableName"].ToString();
                this.variableType.Text = configurationObject["variableType"].ToString();
            }
            catch { }
        }
    }

    /// <summary>
    /// 浏览按钮点击事件：打开文件夹选择对话框，将用户选择的路径填入工作目录输入框
    /// </summary>
    private void BtnBrowse_Click(object sender, EventArgs e)
    {
        using (var folderBrowserDialog = new FolderBrowserDialog
        {
            ShowNewFolderButton = true,   // 允许用户在对话框中新建文件夹
            UseDescriptionForTitle = true, // 使用描述文字作为对话框标题
        })
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.workingDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }

    /// <summary>
    /// "保存输出到变量" 复选框状态变更事件：根据是否勾选来显示/隐藏变量名和变量类型控件
    /// </summary>
    private void CheckSaveVariable_CheckedChanged(object sender, EventArgs e)
    {
        // 同步控制变量名输入框和类型下拉框的可见性，只在勾选时才显示
        this.variableName.Visible = this.checkSaveVariable.Checked;
        this.variableType.Visible = this.checkSaveVariable.Checked;
    }

    /// <summary>
    /// 工作目录标签点击事件（预留，当前无实现逻辑）
    /// </summary>
    private void lblWorkingDirectory_Click(object sender, EventArgs e)
    {

    }
}
