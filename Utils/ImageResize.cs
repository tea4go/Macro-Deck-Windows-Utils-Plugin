using System.Drawing;

namespace SuchByte.WindowsUtils.Utils;

/// <summary>
/// 图像缩放工具类，提供将位图缩放到指定分辨率的功能
/// </summary>
public class ImageResize
{
    /// <summary>
    /// 将指定位图缩放到指定宽度和高度，返回新的位图对象
    /// </summary>
    /// <param name="original">原始位图</param>
    /// <param name="width">目标宽度（像素）</param>
    /// <param name="height">目标高度（像素）</param>
    /// <returns>缩放后的新 Bitmap 对象</returns>
    public static Bitmap Resize(Bitmap original, int width, int height)
    {
        Bitmap result = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage(result))
        {
            // 使用 GDI+ 将原图绘制到新尺寸的画布上，实现缩放
            g.DrawImage(original, 0, 0, width, height);
        }

        return result;
    }


}
