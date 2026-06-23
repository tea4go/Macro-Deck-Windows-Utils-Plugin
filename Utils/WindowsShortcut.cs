using System.IO;

namespace SuchByte.WindowsUtils.Utils;

/// <summary>
/// Windows 快捷方式（.lnk 文件）解析工具类，通过追查 .lnk 文件的二进制格式获取实际目标路径
/// </summary>
internal class WindowsShortcut
{
    /// <summary>
    /// 获取快捷方式指向的实际目标路径。
    /// 如果输入文件不是 .lnk 快捷方式，则直接返回原路径
    /// </summary>
    /// <param name="file">快捷方式文件路径或普通文件路径</param>
    /// <returns>实际目标文件路径；解析失败时返回空字符串</returns>
    public static string GetShortcutTarget(string file)
    {
        try
        {
            // 非 .lnk 文件直接返回原路径
            if (Path.GetExtension(file).ToLower() != ".lnk")
            {
                return file;
            }

            FileStream fileStream = File.Open(file, FileMode.Open, FileAccess.Read);
            using (BinaryReader fileReader = new BinaryReader(fileStream))
            {
                fileStream.Seek(0x14, SeekOrigin.Begin);     // Seek to flags
                uint flags = fileReader.ReadUInt32();        // Read flags
                if ((flags & 1) == 1)                       // 标志第 1 位为 1 表示 .lnk 文件包含 Shell ItemID 列表
                {                      // Bit 1 set means we have to
                                       // skip the shell item ID list
                    fileStream.Seek(0x4c, SeekOrigin.Begin); // Seek to the end of the header
                    uint offset = fileReader.ReadUInt16();   // Read the length of the Shell item ID list
                    fileStream.Seek(offset, SeekOrigin.Current); // Seek past it (to the file locator info)
                }

                long fileInfoStartsAt = fileStream.Position; // Store the offset where the file info
                                                             // structure begins
                uint totalStructLength = fileReader.ReadUInt32(); // read the length of the whole struct
                fileStream.Seek(0xc, SeekOrigin.Current); // seek to offset to base pathname
                uint fileOffset = fileReader.ReadUInt32(); // read offset to base pathname
                                                           // the offset is from the beginning of the file info struct (fileInfoStartsAt)
                fileStream.Seek((fileInfoStartsAt + fileOffset), SeekOrigin.Begin); // Seek to beginning of
                                                                                    // base pathname (target)
                long pathLength = (totalStructLength + fileInfoStartsAt) - fileStream.Position - 2; // read
                                                                                                    // the base pathname. I don't need the 2 terminating nulls.
                char[] linkTarget = fileReader.ReadChars((int)pathLength); // should be unicode safe
                var link = new string(linkTarget);

                // 处理包含双空字符分隔符的路径（UNC 路径格式）
                int begin = link.IndexOf("\0\0");
                if (begin > -1)
                {
                    // 提取双反斜杠开头的第二部分路径并拼接两部分
                    int end = link.IndexOf("\\\\", begin + 2) + 2;
                    end = link.IndexOf('\0', end) + 1;

                    string firstPart = link.Substring(0, begin);
                    string secondPart = link.Substring(end);

                    return firstPart + secondPart;
                }
                else
                {
                    return link;
                }
            }
        }
        catch
        {
            return "";
        }
    }
}
