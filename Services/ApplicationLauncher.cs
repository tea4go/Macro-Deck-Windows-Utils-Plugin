using SuchByte.MacroDeck.Logging;
using SuchByte.WindowsUtils.Utils;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace SuchByte.WindowsUtils.Services;

/// <summary>
/// 应用程序启动/停止/前台/后台等操作的服务类，
/// 通过 P/Invoke 调用 Windows API 实现窗口管理功能
/// </summary>
public class ApplicationLauncher
{
    /// <summary>Win32 API：设置窗口的显示状态（最小化、还原、隐藏等）</summary>
    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    /// <summary>Win32 API：将指定窗口带到前台（获得焦点）</summary>
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    /// <summary>Win32 API：判断窗口是否处于最小化状态</summary>
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool IsIconic(IntPtr hWnd);

    /// <summary>Win32 API：打开指定进程的句柄（用于查询进程文件路径）</summary>
    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

    /// <summary>Win32 API：获取进程主模块的文件全路径</summary>
    [DllImport("psapi.dll")]
    static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [In][MarshalAs(UnmanagedType.U4)] int nSize);

    /// <summary>Win32 API：关闭进程句柄，释放系统资源</summary>
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool CloseHandle(IntPtr hObject);

    private const int SW_MINIMIZE = 6;   // 6=SW_MINIMIZE(最小化到任务栏,可逆);0 是 SW_HIDE,会彻底隐藏窗口
    private const int SW_RESTORE = 9;

    /// <summary>
    /// 检查指定路径的应用程序是否正在运行
    /// </summary>
    /// <param name="path">应用程序可执行文件路径（支持 .lnk 快捷方式）</param>
    /// <returns>进程存在则返回 true，否则返回 false</returns>
    public static bool IsRunning(string path)
    {
        bool isRunning = GetProcessByPath(path) != null;
        return isRunning;
    }

    /// <summary>
    /// 启动应用程序
    /// </summary>
    /// <param name="path">可执行文件路径</param>
    /// <param name="arguments">启动参数</param>
    /// <param name="asAdmin">是否以管理员身份运行（使用 "runas" 动词触发 UAC）</param>
    public static void StartApplication(string path, string arguments, bool asAdmin)
    {
        var p = new Process
        {
            StartInfo = new ProcessStartInfo(path)
            {
                UseShellExecute = true,           // 必须为 true 才能使用 Verb（如 runas）
                WorkingDirectory = Path.GetDirectoryName(path),
                Arguments = arguments,
                Verb = asAdmin ? "runas" : ""     // "runas" 触发 Windows UAC 提权对话框
            }
        };
        p.Start();
    }

    /// <summary>
    /// 结束指定路径对应的应用程序的所有进程
    /// </summary>
    /// <param name="path">应用程序可执行文件路径</param>
    public static void KillApplication(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            MacroDeckLogger.Warning(Main.Instance, $"文件路径不能为空！", Array.Empty<object>());
            return;
        }

        // 获取文件的进程
        var p = GetProcessByPath(path);
        if (p == null) {
            MacroDeckLogger.Warning(Main.Instance, $"当前进程不存在({path})", Array.Empty<object>());
            return;
        }

        // 匹配进程名称并全部终止（处理同一应用多个进程实例的情况）
        Process.GetProcessesByName(p.ProcessName).ToList().ForEach(p =>
        {
            MacroDeckLogger.Debug(Main.Instance, $"Killing Process ({p.Id}-{p.ProcessName}");
            p.Kill();
        });
    }

    /// <summary>
    /// 将应用程序窗口最小化到任务栏（后台）
    /// </summary>
    /// <param name="path">应用程序可执行文件路径</param>
    public static void BringToBackground(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            MacroDeckLogger.Warning(Main.Instance, $"文件路径不能为空！", Array.Empty<object>());
            return;
        }

        var p = GetProcessByPath(path);
        if (p == null) {
            MacroDeckLogger.Warning(Main.Instance, $"当前进程不存在({path})", Array.Empty<object>());
            return;
        }

        IntPtr handle = p.MainWindowHandle;
        // SW_MINIMIZE = 6：最小化窗口到任务栏，可通过点击还原（区别于 SW_HIDE 彻底隐藏）
        ShowWindow(handle, SW_MINIMIZE);
    }

    /// <summary>
    /// 将应用程序窗口带到前台（如最小化则先还原再激活）
    /// </summary>
    /// <param name="path">应用程序可执行文件路径</param>
    public static void BringToForeground(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            MacroDeckLogger.Warning(Main.Instance, $"文件路径不能为空！", Array.Empty<object>());
            return;
        }

        var p = GetProcessByPath(path);
        if (p == null) {
            MacroDeckLogger.Warning(Main.Instance, $"当前进程不存在({path})", Array.Empty<object>());
            return;
        }

        IntPtr handle = p.MainWindowHandle;

        // 窗口被最小化时,Process.MainWindowHandle 会返回 0,
        // 此时按进程 ID 枚举窗口并恢复(WindowActivator 内部会处理 IsIconic 还原)。
        if (handle == IntPtr.Zero)
        {
            WindowActivator.ActivateWindowByProcessId(p.Id);
            return;
        }

        if (SetForegroundWindow(handle))
        {
            if (!IsIconic(handle))
            {
                return;
            }
        }

        // Fallback function
        ShowWindow(handle, SW_MINIMIZE);
        ShowWindow(handle, SW_RESTORE);
    }

    /// <summary>
    /// 根据可执行文件路径查找对应的系统进程
    /// </summary>
    /// <param name="path">可执行文件路径（支持 .lnk 快捷方式）</param>
    /// <returns>匹配的 Process 对象，未找到则返回 null</returns>
    public static Process GetProcessByPath(string path)
    {
        // 查找文件真实路径
        path = WindowsShortcut.GetShortcutTarget(path);

        // 查找文件所在进程
        // 注意:GetProcessFileName 对无法访问的系统进程会返回 null,
        // 必须用 string.Equals 做 null 安全比较,否则 null.Equals 会抛 NullReferenceException
        return Process.GetProcesses().ToArray().Where(
            p => string.Equals(GetProcessFileName(p.Id), path, StringComparison.OrdinalIgnoreCase)
        ).OrderByDescending(p => p.Id).FirstOrDefault();
    }

    /// <summary>
    /// 通过进程 ID 获取该进程的可执行文件全路径（使用 OpenProcess + GetModuleFileNameEx）
    /// </summary>
    /// <param name="pid">目标进程的进程 ID</param>
    /// <returns>进程可执行文件全路径，无权访问或失败时返回 null</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetProcessFileName(int pid)
    {
        // 0x0400 = PROCESS_QUERY_INFORMATION；0x0010 = PROCESS_VM_READ；两者组合可读取进程模块信息
        var processHandle = OpenProcess(0x0400 | 0x0010, false, pid);
        if (processHandle == IntPtr.Zero)
        {
            return null;
        }

        try
        {
            const int lengthSb = 4000;
            var sb = new StringBuilder(lengthSb);
            // GetModuleFileNameEx 返回实际写入的字符数，为 0 表示失败
            var ppid = GetModuleFileNameEx(processHandle, IntPtr.Zero, sb, lengthSb);
            if (ppid == 0)
            {
                return null;
            }
            return sb.ToString();
        }
        finally
        {
            // 无论成功与否都必须关闭句柄，防止句柄泄漏
            CloseHandle(processHandle);
        }
    }
}
