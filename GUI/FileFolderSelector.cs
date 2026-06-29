using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Language;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;

namespace SuchByte.WindowsUtils.GUI;

/// <summary>
/// 文件/文件夹选择界面：用于选择文件路径或文件夹路径，支持拖放和浏览两种方式输入路径
/// 支持在保存时提示导入文件图标
/// </summary>
public partial class FileFolderSelector : ActionConfigControl
{
    /// <summary>当前正在配置的插件动作实例</summary>
    PluginAction pluginAction;

    /// <summary>选择类型：文件或文件夹</summary>
    SelectType type;

    /// <summary>
    /// 构造函数：根据选择类型初始化界面并配置拖放支持
    /// </summary>
    /// <param name="pluginAction">关联的插件动作</param>
    /// <param name="actionConfigurator">动作配置器（当前未使用）</param>
    /// <param name="selectType">指定是文件选择还是文件夹选择</param>
    public FileFolderSelector(PluginAction pluginAction, ActionConfigurator actionConfigurator, SelectType selectType)
    {
        this.pluginAction = pluginAction;
        this.type = selectType;
        InitializeComponent();
        Utils.FontHelper.ApplyMacroDeckFont(this);

        this.lblPath.Text = PluginLanguageManager.PluginStrings.Path;

        // 根据选择类型设置提示文本
        switch (this.type)
        {
            case SelectType.FOLDER:
                this.lblChoose.Text = PluginLanguageManager.PluginStrings.ChooseAFolderOrDragAndDrop;
                break;
            case SelectType.FILE:
                this.lblChoose.Text = PluginLanguageManager.PluginStrings.ChooseAFileOrDragAndDrop;
                break;
        }

        // 为整个界面注册拖放事件，支持从文件管理器拖入路径
        this.AllowDrop = true;
        this.DragEnter += FileFolderSelector_DragEnter;
        this.DragDrop += FileFolderSelector_DragDrop;

        this.LoadConfig();
    }

    /// <summary>
    /// 处理文件拖放事件：将拖入的第一个文件路径填入路径输入框
    /// </summary>
    private void FileFolderSelector_DragDrop(object sender, DragEventArgs e)
    {
        try
        {
            string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            this.path.Text = file;
        }
        catch { }
    }

    /// <summary>
    /// 处理拖拽进入事件：检查拖拽内容是否为文件，若是则显示「复制」拖放效果
    /// </summary>
    private void FileFolderSelector_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.Copy;
        }
    }

    /// <summary>
    /// 保存配置：校验路径类型与选择类型是否匹配，并提示是否导入文件图标
    /// 如果选择的路径类型（文件/文件夹）与预期不符，则弹出错误并阻止保存
    /// </summary>
    public override bool OnActionSave()
    {
        if (string.IsNullOrWhiteSpace(this.path.Text))
        {
            return false;
        }
        // 对于文件类型，提示用户是否导入文件类型图标
        if (this.type != SelectType.FOLDER)
        {
            using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
            {
                if (msgBox.ShowDialog(PluginLanguageManager.PluginStrings.ImportIcon, PluginLanguageManager.PluginStrings.QuestionImportFileTypesIcon, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        Utils.FileIconImport.ImportIcon(this.path.Text);
                    }
                    catch { }
                }
            }
        }
        // 通过位运算检查路径是否为目录类型
        FileAttributes attr = File.GetAttributes(this.path.Text);
        if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
        {
            // 路径是目录，但预期是文件时报错
            if (this.type == SelectType.FILE)
            {
                using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                {
                    msgBox.ShowDialog(LanguageManager.Strings.Error, PluginLanguageManager.PluginStrings.SelectedPathNotAFile, MessageBoxButtons.OK);
                }
                return false;
            }
        }
        else
        {
            // 路径是文件，但预期是目录时报错
            if (this.type == SelectType.FOLDER)
            {
                using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                {
                    msgBox.ShowDialog(LanguageManager.Strings.Error, PluginLanguageManager.PluginStrings.SelectedPathNotAFolder, MessageBoxButtons.OK);
                }
                return false;
            }
        }

        JObject configurationObject = JObject.FromObject(new
        {
            path = this.path.Text,
        });
        this.pluginAction.Configuration = configurationObject.ToString();
        this.pluginAction.ConfigurationSummary = this.path.Text;
        return true;
    }

    /// <summary>
    /// 从已保存配置中加载路径并填充到路径输入框
    /// </summary>
    private void LoadConfig()
    {
        if (!string.IsNullOrWhiteSpace(this.pluginAction.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.pluginAction.Configuration);
                this.path.Text = configurationObject["path"].ToString();
            }
            catch { }
        }
    }

    /// <summary>
    /// 浏览按键点击：根据选择类型打开对应的文件夹或文件选择对话框
    /// </summary>
    private void BtnBrowse_Click(object sender, EventArgs e)
    {
        switch (this.type)
        {
            case SelectType.FOLDER:
                this.ShowFolderBrowserDialog();
                break;
            case SelectType.FILE:
                ShowOpenFileDialog();
                break;
        }
    }

    /// <summary>
    /// 显示文件夹选择对话框并将选中的路径填入输入框
    /// </summary>
    private void ShowFolderBrowserDialog()
    {
        using (var folderBrowserDialog = new FolderBrowserDialog
        {
            ShowNewFolderButton = true,
            UseDescriptionForTitle = true,
        })
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.path.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }

    /// <summary>
    /// 显示文件打开对话框并将选中的文件路径填入输入框
    /// 对话框配置为允许输入不存在的路径，并且不解析快捷方式（支持直接输入 .lnk 快捷方式路径）
    /// </summary>
    private void ShowOpenFileDialog()
    {
        using (var openFileDialog = new OpenFileDialog
        {
            CheckFileExists = false,    // 允许输入不存在的文件路径
            CheckPathExists = false,    // 允许输入不存在的目录路径
            Filter = "All files (*.*)|*.*",
            SupportMultiDottedExtensions = true, // 支持多点扩展名（如 file.tar.gz）
            ValidateNames = false,      // 不对文件名进行合法性验证
            DereferenceLinks = false,   // 不解析快捷方式，直接返回 .lnk 路径
        })
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.path.Text = openFileDialog.FileName;
            }
        }
    }
}



public enum SelectType
{
    FOLDER,
    FILE,
}
