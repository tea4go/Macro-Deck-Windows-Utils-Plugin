using SuchByte.MacroDeck.Logging;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace SuchByte.WindowsUtils.Utils;
public static class WindowActivator
{
    /// <summary>
    /// Defines how the window title should be matched against the pattern.
    /// </summary>
    public enum MatchMode
    {
        /// <summary>
        /// Matches if the pattern is found anywhere in the window title. (Default)
        /// </summary>
        Partial,
        /// <summary>
        /// Matches if the pattern is exactly equal to the window title.
        /// </summary>
        Full,
        /// <summary>
        /// Matches if the window title starts with the pattern.
        /// </summary>
        StartsWith,
        /// <summary>
        /// Matches if the window title ends with the pattern.
        /// </summary>
        EndsWith,
        /// <summary>
        /// Treats the pattern as a regular expression to match against the window title.
        /// </summary>
        Regex
    }

    // This class holds the state needed during the window enumeration.
    private class EnumWindowParams
    {
        public string Pattern { get; set; }
        public MatchMode MatchMode { get; set; }
        public bool CaseSensitive { get; set; }
        public Regex PatternRegex { get; set; }
        public int CurrentProcessId { get; set; }
        public bool IsAppActivated { get; set; }
    }

    /// <summary>
    /// Finds a window by its title and brings it to the foreground.
    /// This method is context-agnostic and will work in console, WinForms, or WPF applications.
    /// </summary>
    /// <param name="pattern">The title pattern to search for. Can be a literal string or a regex pattern.</param>
    /// <param name="matchMode">The mode for matching the pattern (Partial, Full, Regex, etc.). Defaults to Partial.</param>
    /// <param name="caseSensitive">If true, the search will be case-sensitive. Defaults to true.</param>
    /// <returns>True if a matching window was found and successfully activated, otherwise false.</returns>
    public static bool ActivateWindowByTitle(string pattern, MatchMode matchMode = MatchMode.Partial, bool caseSensitive = true)
    {
        if (string.IsNullOrEmpty(pattern))
        {
            throw new ArgumentException("Pattern cannot be null or empty.", nameof(pattern));
        }

        var enumParams = new EnumWindowParams
        {
            Pattern = pattern,
            MatchMode = matchMode,
            CaseSensitive = caseSensitive,
            IsAppActivated = false,
            CurrentProcessId = Process.GetCurrentProcess().Id
        };

        // Pre-compile Regex if in Regex mode
        if (matchMode == MatchMode.Regex)
        {
            try
            {
                var options = enumParams.CaseSensitive
                    ? RegexOptions.Compiled
                    : RegexOptions.IgnoreCase | RegexOptions.Compiled;

                enumParams.PatternRegex = new Regex(pattern, options);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Invalid regular expression: {ex.Message}", nameof(pattern), ex);
            }
        }

        NativeMethods.EnumWindows((hWnd, lParam) =>
        {
            NativeMethods.GetWindowThreadProcessId(hWnd, out uint windowPid);

            if (windowPid == enumParams.CurrentProcessId)
            {
                return true;
            }

            if (!IsWindowAppearingInTaskbar(hWnd))
            {
                return true;
            }

            if (!IsWindowTextMatch(hWnd, enumParams))
            {
                return true;
            }

            ForceActivateWindow(hWnd);

            IntPtr foregroundHwnd = NativeMethods.GetForegroundWindow();
            if (foregroundHwnd == hWnd)
            {
                enumParams.IsAppActivated = true;
                return false;
            }

            return true;
        }, IntPtr.Zero);

        return enumParams.IsAppActivated;
    }

    private static bool IsWindowAppearingInTaskbar(IntPtr hWnd)
    {
        var style = (WindowStyles)NativeMethods.GetWindowLongPtr(hWnd, (int)GetWindowLongFlags.GWL_STYLE);
        var exStyle = (WindowStylesEx)NativeMethods.GetWindowLongPtr(hWnd, (int)GetWindowLongFlags.GWL_EXSTYLE);

        if (!style.HasFlag(WindowStyles.WS_VISIBLE)) return false;
        if (exStyle.HasFlag(WindowStylesEx.WS_EX_TOOLWINDOW)) return false;
        if (exStyle.HasFlag(WindowStylesEx.WS_EX_NOREDIRECTIONBITMAP)) return false;

        IntPtr hOwnerWnd = NativeMethods.GetWindow(hWnd, GetWindowCmd.GW_OWNER);
        if (hOwnerWnd != IntPtr.Zero && (!exStyle.HasFlag(WindowStylesEx.WS_EX_APPWINDOW) || NativeMethods.IsIconic(hOwnerWnd)))
        {
            return false;
        }

        return true;
    }

    private static bool IsWindowTextMatch(IntPtr hWnd, EnumWindowParams param)
    {
        string text = GetWindowText(hWnd);
        if (string.IsNullOrEmpty(text))
        {
            return false;
        }

        if (param.MatchMode == MatchMode.Regex)
        {
            return param.PatternRegex.IsMatch(text);
        }

        var comparisonType = param.CaseSensitive
            ? StringComparison.Ordinal
            : StringComparison.OrdinalIgnoreCase;

        switch (param.MatchMode)
        {
            case MatchMode.Full:
                return text.Equals(param.Pattern, comparisonType);
            case MatchMode.StartsWith:
                return text.StartsWith(param.Pattern, comparisonType);
            case MatchMode.EndsWith:
                return text.EndsWith(param.Pattern, comparisonType);
            case MatchMode.Partial:
            default:
                return text.IndexOf(param.Pattern, comparisonType) >= 0;
        }
    }

    public static void ForceActivateWindow(IntPtr hWnd)
    {
        if (hWnd == IntPtr.Zero) return;

        if (NativeMethods.IsIconic(hWnd))
        {
            NativeMethods.ShowWindowAsync(hWnd, ShowWindowCommands.Restore);
        }

        IntPtr foregroundHwnd = NativeMethods.GetForegroundWindow();
        if (foregroundHwnd == hWnd) return;

        uint foregroundThreadId = NativeMethods.GetWindowThreadProcessId(foregroundHwnd, out _);
        uint thisThreadId = NativeMethods.GetCurrentThreadId();

        bool doAttach = (foregroundThreadId != thisThreadId);

        if (doAttach)
        {
            NativeMethods.AttachThreadInput(thisThreadId, foregroundThreadId, true);
        }

        try
        {
            NativeMethods.SetForegroundWindow(hWnd);
            NativeMethods.SetWindowPos(hWnd, IntPtr.Zero, 0, 0, 0, 0, SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_SHOWWINDOW | SetWindowPosFlags.SWP_ASYNCWINDOWPOS);
            NativeMethods.BringWindowToTop(hWnd);
            NativeMethods.ShowWindowAsync(hWnd, ShowWindowCommands.Show);
            NativeMethods.SetFocus(hWnd);
        }
        finally
        {
            if (doAttach)
            {
                NativeMethods.AttachThreadInput(thisThreadId, foregroundThreadId, false);
            }
        }
    }

    private static string GetWindowText(IntPtr hWnd)
    {
        int length = NativeMethods.GetWindowTextLength(hWnd);
        if (length == 0) return string.Empty;

        var sb = new StringBuilder(length + 1);
        NativeMethods.GetWindowText(hWnd, sb, sb.Capacity);
        return sb.ToString();
    }

    #region P/Invoke Definitions

    private static class NativeMethods
    {
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)] public static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)] public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")][return: MarshalAs(UnmanagedType.Bool)] public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
        [DllImport("user32.dll")] public static extern IntPtr GetWindow(IntPtr hWnd, GetWindowCmd uCmd);
        [DllImport("user32.dll")] public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")][return: MarshalAs(UnmanagedType.Bool)] public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")] public static extern IntPtr SetFocus(IntPtr hWnd);
        [DllImport("user32.dll")][return: MarshalAs(UnmanagedType.Bool)] public static extern bool BringWindowToTop(IntPtr hWnd);
        [DllImport("user32.dll")][return: MarshalAs(UnmanagedType.Bool)] public static extern bool ShowWindowAsync(IntPtr hWnd, ShowWindowCommands nCmdShow);
        [DllImport("user32.dll")][return: MarshalAs(UnmanagedType.Bool)] public static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32.dll")] public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("kernel32.dll")] public static extern uint GetCurrentThreadId();
        [DllImport("user32.dll")][return: MarshalAs(UnmanagedType.Bool)] public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
        [DllImport("user32.dll", SetLastError = true)][return: MarshalAs(UnmanagedType.Bool)] public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SetWindowPosFlags uFlags);
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")] private static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")] private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);
        public static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex) => IntPtr.Size == 8 ? GetWindowLongPtr64(hWnd, nIndex) : GetWindowLongPtr32(hWnd, nIndex);
    }

    #region P/Invoke Enums and Flags
    private enum GetWindowLongFlags { GWL_STYLE = -16, GWL_EXSTYLE = -20 }
    [Flags] private enum WindowStyles : uint { WS_VISIBLE = 0x10000000 }
    [Flags] private enum WindowStylesEx : uint { WS_EX_TOOLWINDOW = 0x00000080, WS_EX_APPWINDOW = 0x00040000, WS_EX_NOREDIRECTIONBITMAP = 0x00200000 }
    private enum GetWindowCmd : uint { GW_OWNER = 4 }
    private enum ShowWindowCommands { Show = 5, Restore = 9 }
    [Flags] private enum SetWindowPosFlags : uint { SWP_ASYNCWINDOWPOS = 0x4000, SWP_NOMOVE = 0x0002, SWP_NOSIZE = 0x0001, SWP_SHOWWINDOW = 0x0040 }
    #endregion

    #endregion
}