using System;
using System.Runtime.InteropServices;

namespace CppSharp
{
    public enum TargetPlatform
    {
        Windows,
        Linux,
        Android,
        MacOS,
        iOS,
        WatchOS,
        TVOS,
        Emscripten,
    }

    public static class Platform
    {
        public static bool IsWindows
        {
            get
            {
                switch (Environment.OSVersion.Platform)
                {
                    case PlatformID.Win32NT:
                    case PlatformID.Win32S:
                    case PlatformID.Win32Windows:
                    case PlatformID.WinCE:
                        return true;
                }

                return false;
            }
        }

        public static bool IsLinux
        {
            get { return Environment.OSVersion.Platform == PlatformID.Unix; }
        }

        public static bool IsMono
        {
            get { return Type.GetType("Mono.Runtime") != null; }
        }

        public static bool IsUnixPlatform
        {
            get
            {
                var platform = Environment.OSVersion.Platform;
                return platform == PlatformID.Unix || platform == PlatformID.MacOSX;
            }
        }

        public static TargetPlatform Host
        {
            get
            {
                if (IsWindows)
                    return TargetPlatform.Windows;

                if (IsLinux)
                    return TargetPlatform.Linux;

                throw new NotImplementedException();
            }
        }
    }
}
