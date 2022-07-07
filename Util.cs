using System;
using System.Diagnostics;

namespace opprac1bolyuk
{
    public static class Util
    {
        public static void not(String text)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "/usr/bin/notify-send",
                Arguments = " -t 9000 bolyuk \"" +
                text + "\""
            };
            Process proc = new Process() { StartInfo = startInfo, };
            proc.Start();
        }
    }
}
