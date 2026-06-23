using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using SuchByte.WindowsUtils.Models;
using SuchByte.WindowsUtils.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SuchByte.WindowsUtils.GUI;

/// <summary>
/// 启动应用程序动作的配置视图，允许用户选择应用路径、启动参数、操作方式等，支持拖放和文件选择器
/// </summary>
public partial class StartApplicationActionConfigView : ActionConfigControl
{
    /// <summary>当前视图的 ViewModel</summary>
    private readonly StartApplicationActionConfigViewModel _viewModel;

    /// <summary>当前配置的插件动作</summary>
    private readonly PluginAction _action;

    /// <summary>
    /// 构造函数：初始化控件、设置居所文本、操作方式列表，并启用拖放功能
    /// </summary>
    /// <param name="action">要配置的插件动作</param>
    public StartApplicationActionConfigView(PluginAction action)
    {
        InitializeComponent();

        // 使用 ??= 确保只在 action 为空时才赋值（实际上 action 始终不为空）
        this._action ??= action;

        this.lblPath.Text = PluginLanguageManager.PluginStrings.Path;
        this.lblArguments.Text = PluginLanguageManager.PluginStrings.Arguments;
        this.path.PlaceHolderText = PluginLanguageManager.PluginStrings.ChooseAFileOrDragAndDrop;

        // 填充操作方式下拉列表
        this.method.Items.AddRange(new[] { PluginLanguageManager.PluginStrings.MethodStart,
                                           PluginLanguageManager.PluginStrings.MethodStop,
                                           PluginLanguageManager.PluginStrings.MethodShow,
                                           PluginLanguageManager.PluginStrings.MethodHide,
                                         });

        // 同时为输入框和容器本身都启用拖放，确保拖放到任意位置都能捕获事件
        this.path.AllowDrop = true;
        this.path.DragEnter += ApplicationSelector_DragEnter;
        this.path.DragDrop += ApplicationSelector_DragDrop;
        this.AllowDrop = true;
        this.DragEnter += ApplicationSelector_DragEnter;
        this.DragDrop += ApplicationSelector_DragDrop;


        this._viewModel = new StartApplicationActionConfigViewModel(action);
    }

    /// <summary>
    /// 拖放放下事件：获取拖放的文件路径并填入路径输入框
    /// </summary>
    private void ApplicationSelector_DragDrop(object sender, DragEventArgs e)
    {
        try
        {
            // 取文件列表的第一个文件路径
            string file = ((string[])e.Data.GetData(DataFormats.FileDrop)).FirstOrDefault();
            this.path.Text = file;
        }
        catch { }
    }

    /// <summary>
    /// 拖放进入事件：检查拖放内容是否为文件，是则设置拖放效果为复制
    /// </summary>
    private void ApplicationSelector_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.Copy;
        }
    }

    /// <summary>
    /// 表单加载事件：从 ViewModel 将已保存的配置回填到 UI 控件
    /// </summary>
    private void StartApplicationActionConfigView_Load(object sender, EventArgs e)
    {
        this.path.Text = this._viewModel.Path;
        this.arguments.Text = this._viewModel.Arguments;
        // 根据已保存的 StartMethod 枚举设置对应的中文居所文本
        switch (this._viewModel.StartMethod)
        {
            case StartMethod.Start:
                this.method.Text = PluginLanguageManager.PluginStrings.MethodStart;
                break;
            case StartMethod.Show:
                this.method.Text = PluginLanguageManager.PluginStrings.MethodShow;
                break;
            case StartMethod.Hide:
                this.method.Text = PluginLanguageManager.PluginStrings.MethodHide;
                break;
            case StartMethod.Stop:
                this.method.Text = PluginLanguageManager.PluginStrings.MethodStop;
                break;
        }
        this.checkRunAsAdmin.Checked = this._viewModel.RunAsAdmin;
        this.checkSyncButtonState.Checked = this._viewModel.SyncButtonState;
    }

    /// <summary>
    /// 用户点击保存时触发：校验路径、将 UI 状态同步到 ViewModel，并提示是否导入应用图标
    /// </summary>
    /// <returns>路径不为空且保存成功时返回 true，否则返回 false</returns>
    public override bool OnActionSave()
    {
        if (string.IsNullOrWhiteSpace(this.path.Text))
        {
            return false;
        }
        this._viewModel.Path = this.path.Text;
        this._viewModel.Arguments = this.arguments.Text;
        // 将下拉框显示文本转换为对应的枚举值
        if (this.method.Text.Equals(PluginLanguageManager.PluginStrings.MethodStart))
        {
            this._viewModel.StartMethod = StartMethod.Start;
        }
        else if (this.method.Text.Equals(PluginLanguageManager.PluginStrings.MethodShow))
        {
            this._viewModel.StartMethod = StartMethod.Show;
        }
        else if (this.method.Text.Equals(PluginLanguageManager.PluginStrings.MethodHide))
        {
            this._viewModel.StartMethod = StartMethod.Hide;
        }
        else if (this.method.Text.Equals(PluginLanguageManager.PluginStrings.MethodStop))
        {
            this._viewModel.StartMethod = StartMethod.Stop;
        }
        this._viewModel.RunAsAdmin = this.checkRunAsAdmin.Checked;
        this._viewModel.SyncButtonState = this.checkSyncButtonState.Checked;



        // 提示用户是否导入应用程序图标
        using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
        {
            if (msgBox.ShowDialog(PluginLanguageManager.PluginStrings.ImportIcon, PluginLanguageManager.PluginStrings.QuestionImportFilesIcon, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var iconModel = Utils.FileIconImport.ImportIcon(this.path.Text);
                    if (iconModel != null)
                    {
                    }
                }
                catch (Exception ex)
                {
                    MacroDeckLogger.Error(Main.Instance, $"Failed to import the file icon: {ex.Message + Environment.NewLine + ex.StackTrace}");
                }
            }
        }
        return this._viewModel.SaveConfig();
    }

    /// <summary>
    /// 浏览按钮点击事件：打开文件选择对话框让用户选择可执行文件
    /// </summary>
    private void BtnBrowse_Click(object sender, EventArgs e)
    {
        using (var openFileDialog = new OpenFileDialog
        {
            Title = "Start application",
            CheckFileExists = false,      // 允许输入不存在的文件路径
            CheckPathExists = false,      // 允许输入不存在的目录路径
            DefaultExt = "exe",
            Filter = "Applications (*.exe)|*.exe|Shortcuts (*.ink)|*.ink|All files (*.*)|*.*",
            SupportMultiDottedExtensions = true,  // 支持多点扩展名（如 file.tar.gz）
            ValidateNames = false,        // 不对文件名进行合法性验证
            DereferenceLinks = false,     // 不解析快捷方式，直接返回 .lnk 路径
        })
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.path.Text = openFileDialog.FileName;
            }
        }
    }

}
