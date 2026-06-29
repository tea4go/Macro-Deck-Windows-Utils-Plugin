#if DEBUG
using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;

namespace SuchByte.WindowsUtils.Utils;

/// <summary>
/// 仅 Debug 配置编译。WinForms Designer (.NET 10, out-of-process) 在加载本插件时，
/// 会反射到基类 SuchByte.MacroDeck.GUI.CustomControls.ActionConfigControl，进而触发
/// Macro Deck 2.dll 的 &lt;Module&gt;.cctor 运行；该 cctor 内嵌的 Sentry source-generator 代码
/// (Sentry.Generated.BuildPropertyInitializer.Initialize) 强制加载 Sentry.dll。
///
/// 仅靠 PackageReference / Reference 不够：Designer Server 使用独立 AssemblyLoadContext，
/// 不会读 plugin 的 deps.json，也不响应 AppDomain.AssemblyResolve。
///
/// 解决方案分两步：
///   1) 触发编译器在 plugin DLL 的 AssemblyRef 表中包含 Sentry — 通过 typeof(SentryOptions)
///      让 plugin 在元数据层声明对 Sentry 的依赖；
///   2) ModuleInitializer 时把 fallback hook 注册到 plugin 实际所属的 ALC
///      (即 Designer 的隔离 ALC)，并立刻 force-load Sentry，让它驻留在 ALC 缓存里 —
///      之后 Macro Deck 2 cctor 触发的同名引用会命中缓存。
/// </summary>
internal static class DesignerAssemblyResolver
{
    private static readonly string[] ProbeDirs =
    {
        @"C:\Program Files\Macro Deck",
    };

    // 让编译器在 plugin DLL 的元数据 AssemblyRef 表里加入 Sentry。
    // 仅为 metadata 触发，不会真的执行 Sentry 代码。
    private static readonly Type _sentryAnchor = typeof(global::Sentry.SentryOptions);

#pragma warning disable CA2255 // ModuleInitializer 仅用于应用代码 — 此处即应用层 hook，符合设计意图
    [ModuleInitializer]
    internal static void Register()
#pragma warning restore CA2255
    {
        try
        {
            var pluginCtx = AssemblyLoadContext.GetLoadContext(typeof(DesignerAssemblyResolver).Assembly);
            if (pluginCtx != null)
            {
                pluginCtx.Resolving += OnResolving;
            }
            AssemblyLoadContext.Default.Resolving += OnResolving;

            // force-load 一次 Sentry，让它驻留在 ALC 缓存里。即使 plugin ModuleInitializer
            // 比 Macro Deck 2 cctor 晚运行也无妨 — 只要 Sentry 已加载，后续解析直接命中。
            _ = _sentryAnchor;
        }
        catch
        {
            // Designer 环境异常不应阻塞 plugin 加载；忽略即可
        }
    }

    private static Assembly OnResolving(AssemblyLoadContext ctx, AssemblyName name)
    {
        if (string.IsNullOrEmpty(name.Name)) return null;
        foreach (var dir in ProbeDirs)
        {
            if (!Directory.Exists(dir)) continue;
            var path = Path.Combine(dir, name.Name + ".dll");
            if (File.Exists(path))
            {
                try { return ctx.LoadFromAssemblyPath(path); }
                catch { /* 让下一个候选路径或默认机制处理 */ }
            }
        }
        return null;
    }
}
#endif
