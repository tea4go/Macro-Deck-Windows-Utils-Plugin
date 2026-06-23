using System.Threading;

namespace SuchByte.WindowsUtils.Models;

/// <summary>
/// 多键序列中的延迟动作模型，执行时会使当前线程休眠指定的毫秒数
/// </summary>
public class MultiHotkeyDelayActionModel : IMultiHotkeyAction
{
    /// <summary>延迟时长（单位：毫秒），默认为 100ms</summary>
    public int DelayLengthMs { get; set; } = 100;

    /// <summary>
    /// 执行延迟：使当前线程等待 <see cref="DelayLengthMs"/> 毫秒
    /// </summary>
    public void Execute()
    {
        Thread.Sleep(this.DelayLengthMs);
    }
}
