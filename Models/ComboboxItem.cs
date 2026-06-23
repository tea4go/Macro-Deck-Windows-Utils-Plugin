namespace SuchByte.WindowsUtils.Models;

/// <summary>
/// 通用下拉框项模型，封装显示文本与实际值，便于下拉列表绑定
/// </summary>
public class ComboboxItem
{
    /// <summary>下拉框中显示给用户看的文本</summary>
    public string Text { get; set; }

    /// <summary>与显示文本对应的实际数据值</summary>
    public object Value { get; set; }

    /// <summary>
    /// 返回显示文本，使下拉框直接展示 Text 属性而非对象类型名
    /// </summary>
    public override string ToString()
    {
        return Text;
    }
}
