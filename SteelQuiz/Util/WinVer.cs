using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz.Util
{
    public static class WinVer
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern uint RtlGetVersion(out OsVersionInfo versionInformation); // return type should be the NtStatus enum

        [StructLayout(LayoutKind.Sequential)]
        public struct OsVersionInfo
        {
            private readonly uint OsVersionInfoSize;

            public readonly uint MajorVersion;
            public readonly uint MinorVersion;

            public readonly uint BuildNumber;

            public readonly uint PlatformId;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            private readonly string CSDVersion;
        }

        public static Version WindowsVersion()
        {
            try
            {
                var versionInfo = new OsVersionInfo();
                RtlGetVersion(out versionInfo);

                return new Version((int)versionInfo.MajorVersion, (int)versionInfo.MinorVersion, (int)versionInfo.BuildNumber);
            }
            catch
            {
                return new Version(0, 0, 0);
            }
        }
    }
}
