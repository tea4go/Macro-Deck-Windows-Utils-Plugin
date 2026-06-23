using WindowsInput;

namespace SuchByte.WindowsUtils.Models;

/// <summary>
/// 多键序列中的按键动作模型，支持按下（Down）和松开（Up）两种操作
/// </summary>
public class MultiHotkeyKeyActionModel : IMultiHotkeyAction
{
    /// <summary>此次按键动作的操作类型（按下或松开）</summary>
    public MultiHotkeyKeyMethod MultiHotkeyKeyMethod { get; set; } = MultiHotkeyKeyMethod.Down;

    /// <summary>要模拟的虚拟按键代码</summary>
    public VirtualKeyCode KeyCode;

    /// <summary>
    /// 根据 <see cref="MultiHotkeyKeyMethod"/> 执行按键操作：按下或松开指定的虚拟键
    /// </summary>
    public void Execute()
    {
        switch (MultiHotkeyKeyMethod)
        {
            case MultiHotkeyKeyMethod.Down:
                // 按下指定虚拟键
                Main.Instance.InputSimulator.Keyboard.KeyDown(this.KeyCode);
                break;
            case MultiHotkeyKeyMethod.Up:
                // 松开指定虚拟键
                Main.Instance.InputSimulator.Keyboard.KeyUp(this.KeyCode);
                break;
        }
    }
}

/// <summary>
/// 多键按键动作的操作类型枚举
/// </summary>
public enum MultiHotkeyKeyMethod
{
    /// <summary>按下键（KeyDown）</summary>
    Down,
    /// <summary>松开键（KeyUp）</summary>
    Up,
}
