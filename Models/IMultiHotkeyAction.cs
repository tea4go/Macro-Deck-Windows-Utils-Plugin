namespace SuchByte.WindowsUtils.Models;

/// <summary>
/// 多键动作的执行单元接口，所有可加入多键动作序列的操作（按键、延迟等）均需实现此接口
/// </summary>
public interface IMultiHotkeyAction
{
    /// <summary>执行该动作（如按下按键、等待指定时间等）</summary>
    public void Execute();

}
