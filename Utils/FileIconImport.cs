using System;
using SuchByte.MacroDeck.Icons;
using System.Drawing;
using System.Windows.Forms;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using SuchByte.WindowsUtils.Models;

namespace SuchByte.WindowsUtils.Utils;

/// <summary>
/// 文件图标导入工具类，提供从应用程序可执行文件提取图标并导入到 Macro Deck 图标包的功能
/// </summary>
public static class FileIconImport
{
    /// <summary>
    /// 从指定文件提取图标并导入到 Macro Deck 图标包中
    /// </summary>
    /// <param name="filePath">要提取图标的应用程序文件路径</param>
    /// <returns>导入成功返回包含图标包名和 ID 的模型，失败或取消返回 null</returns>
    public static IconImportModel ImportIcon(string filePath)
    {
        // 展示图标质量选择对话框让用户选择导入尺寸
        using (var iconImportQuality = new MacroDeck.GUI.Dialogs.IconImportQuality())
        {
            if (iconImportQuality.ShowDialog() == DialogResult.OK)
            {
                Image icon;

                // 使用 Shell32 API 获取文件的系统图标索引，再通过 Jumbo 列表获取 256x256 大图标
                IntPtr hIcon = ShellIcon.GetJumboIcon(ShellIcon.GetIconIndex(filePath));

                using (System.Drawing.Icon ico = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(hIcon).Clone())
                {
                    // 若用户指定了尺寸（Pixels > 0）则缩放图标，否则使用原始大小
                    icon = iconImportQuality.Pixels >= 0 ? ImageResize.Resize(ico.ToBitmap(), iconImportQuality.Pixels, iconImportQuality.Pixels) : ico.ToBitmap();

                    if (icon == null)
                    {
                        using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                        {
                            msgBox.ShowDialog(PluginLanguageManager.PluginStrings.ImportIcon, PluginLanguageManager.PluginStrings.FailedToImportIcon, MessageBoxButtons.OK);
                        }
                        return null;
                    }

                    // 展示图标包选择对话框，让用户选择要导入到哪个图标包
                    using (var iconPackSelector = new IconPackSelector())
                    {
                        if (iconPackSelector.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                // 将图标添加到选中的图标包中并返回模型
                                IconPack iconPack = IconManager.GetIconPackByName(iconPackSelector.IconPack);
                                MacroDeck.Icons.Icon macroDeckIcon = IconManager.AddIconImage(iconPack, icon);
                                using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                                {
                                    msgBox.ShowDialog(PluginLanguageManager.PluginStrings.ImportIcon, String.Format(PluginLanguageManager.PluginStrings.IconSuccessfullyImportedToX, iconPackSelector.IconPack), MessageBoxButtons.OK);
                                }
                                return new IconImportModel()
                                {
                                    IconPack = iconPack.Name,
                                    IconId = macroDeckIcon.IconId,
                                };
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        return null;
    }

}
