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

public class ApplicationLauncher
{
    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool IsIconic(IntPtr hWnd);

    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

    [DllImport("psapi.dll")]
    static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [In][MarshalAs(UnmanagedType.U4)] int nSize);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool CloseHandle(IntPtr hObject);

    private const int SW_MINIMIZE = 0;
    private const int SW_RESTORE = 9;

    public static bool IsRunning(string path)
    {
        bool isRunning = GetProcessByPath(path) != null;
        return isRunning;
    }

    public static void StartApplication(string path, string arguments, bool asAdmin)
    {
        var p = new Process
        {
            StartInfo = new ProcessStartInfo(path)
            {
                UseShellExecute = true,
                WorkingDirectory = Path.GetDirectoryName(path),
                Arguments = arguments,
                Verb = asAdmin ? "runas" : ""
            }
        };
        p.Start();
    }

    public static void KillApplication(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            MacroDeckLogger.Warning(Main.Instance, $"文件路径不能为空！");
            return;
        }

        // 获取文件的进程
        var p = GetProcessByPath(path);
        if (p == null) {
            MacroDeckLogger.Warning(Main.Instance, $"当前进程不存在({path})");
            return;
        }

        Process.GetProcessesByName(p.ProcessName).ToList().ForEach(p =>
        {
            MacroDeckLogger.Trace(Main.Instance, $"Killing Process ({p.Id}-{p.ProcessName}");
            p.Kill();
        });
    }

    public static void BringToBackground(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            MacroDeckLogger.Warning(Main.Instance, $"文件路径不能为空！");
            return;
        }

        var p = GetProcessByPath(path);
        if (p == null) {
            MacroDeckLogger.Warning(Main.Instance, $"当前进程不存在({path})");
            return;
        }

        IntPtr handle = p.MainWindowHandle;
        ShowWindow(handle, SW_MINIMIZE);
    }

    public static void BringToForeground(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            MacroDeckLogger.Warning(Main.Instance, $"文件路径不能为空！");
            return;
        }

        var p = GetProcessByPath(path);
        if (p == null) {
            MacroDeckLogger.Warning(Main.Instance, $"当前进程不存在({path})");
            return;
        }

        IntPtr handle = p.MainWindowHandle;
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

    public static Process GetProcessByPath(string path)
    {
        // 查找文件真实路径
        path = WindowsShortcut.GetShortcutTarget(path);

        // 查找文件所在进程
        return Process.GetProcesses().ToArray().Where(
            p => GetProcessFileName(p.Id).Equals(path, StringComparison.OrdinalIgnoreCase)
        ).OrderByDescending(p => p.Id).FirstOrDefault();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetProcessFileName(int pid)
    {
        var processHandle = OpenProcess(0x0400 | 0x0010, false, pid);
        if (processHandle == IntPtr.Zero)
        {
            return null;
        }

        try
        {
            const int lengthSb = 4000;
            var sb = new StringBuilder(lengthSb);
            var ppid = GetModuleFileNameEx(processHandle, IntPtr.Zero, sb, lengthSb);
            if (ppid == 0)
            {
                return null;
            }
            return sb.ToString();
        }
        finally
        {
            CloseHandle(processHandle);
        }
    }
}
