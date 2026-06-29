using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Icons;
using SuchByte.MacroDeck.Language;
using System;
using System.Windows.Forms;

namespace SuchByte.WindowsUtils.GUI;

/// <summary>
/// 图标包选择对话框：允许用户从已安装的非应用商店管理的图标包中选择一个将图标导入到其中
/// 如果没有可用图标包，则自动为当前用户创建一个
/// </summary>
public partial class IconPackSelector : DialogForm
{
    /// <summary>
    /// 获取用户选中的图标包名称
    /// </summary>
    public string IconPack
    {
        get
        {
            return this.iconPacks.Text;
        }
    }

    /// <summary>
    /// 构造函数：加载所有非应用商店管理的图标包到下拉框
    /// 如果当前没有任何可用图标包，则自动为当前用户创建一个名为 "Imported icons" 的图标包
    /// </summary>
    public IconPackSelector()
    {
        InitializeComponent();
        Utils.FontHelper.ApplyMacroDeckFont(this);

        this.btnOk.Text = LanguageManager.Strings.Ok;

        // 如果没有非应用商店管理的图标包，自动创建一个默认导入图标包
        if (IconManager.IconPacks.FindAll(i => !i.ExtensionStoreManaged).Count == 0)
        {
            IconManager.CreateIconPack("Imported icons", Environment.UserName, "1.0.0");
        }

        // 把所有非应用商店管理的图标包加入下拉框（过滤掉由应用商店自动管理的）
        foreach (IconPack iconPack in IconManager.IconPacks.FindAll(i => !i.ExtensionStoreManaged))
        {
            this.iconPacks.Items.Add(iconPack.Name);
        }
        this.iconPacks.SelectedIndex = 0;
    }

    /// <summary>
    /// 确认按键点击：将对话框结果设为 OK 并关闭
    /// </summary>
    private void BtnOk_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}
