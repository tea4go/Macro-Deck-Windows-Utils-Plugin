namespace SuchByte.WindowsUtils.Models;

/// <summary>
/// 图标导入模型，记录导入的图标所属图标包名称及图标 ID
/// </summary>
public class IconImportModel
{
    /// <summary>图标所属的图标包名称</summary>
    public string IconPack { get; set; }

    /// <summary>图标在图标包中的唯一标识符</summary>
    public string IconId { get; set; }

    /// <summary>
    /// 返回格式为 "IconPack.IconId" 的字符串，便于显示和日志
    /// </summary>
    public override string ToString()
    {
        return $"{this.IconPack}.{this.IconId}";
    }

}
