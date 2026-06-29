using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace SuchByte.WindowsUtils.Utils;

internal static class FontHelper
{
    private static readonly string ConfigPath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Macro Deck", "config.json");

    public static void ApplyMacroDeckFont(this Control root)
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
        try
        {
            var json = JObject.Parse(File.ReadAllText(ConfigPath));
            var family = json["Font"]?.ToString() ?? SystemFonts.DefaultFont.FontFamily.Name;
            var size = json["Font.Size"]?.Value<float>() ?? SystemFonts.DefaultFont.Size;
            var bold = json["Font.Bold"]?.Value<bool>() ?? false;
            var style = bold ? FontStyle.Bold : FontStyle.Regular;
            ApplyRecursive(root, family, size, style);
        }
        catch { }
    }

    private static void ApplyRecursive(Control c, string family, float size, FontStyle style)
    {
        c.Font = new Font(family, size, style);
        foreach (Control child in c.Controls)
            ApplyRecursive(child, family, size, style);
    }
}
