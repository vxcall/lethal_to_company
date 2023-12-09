using System;
using System.IO;

namespace lethal_to_company
{
    class debug_log
    {
#if DEBUG
        private StreamWriter log_file;
        private bool usingTimeStamps = true;
#endif
        public debug_log(bool useTimeStamps)
        {
#if DEBUG
            usingTimeStamps = useTimeStamps;
            log_file = File.AppendText($"log.txt");
#endif
        }
        public void Log(string msg)
        {
#if DEBUG
            log_file.WriteLine($"{(usingTimeStamps ? $"[{DateTime.Now.ToLongTimeString()}]" : "") }\t[LOG]:{msg}");
            log_file.Flush();
#endif
        }
        public void Error(string msg)
        {
#if DEBUG
            log_file.WriteLine($"{(usingTimeStamps ? $"[{DateTime.Now.ToLongTimeString()}]" : "") }\t[ERR]:{msg}");
            log_file.Flush();
#endif
        }
        public void Info(string msg)
        {
#if DEBUG
            log_file.WriteLine($"{(usingTimeStamps ? $"[{DateTime.Now.ToLongTimeString()}]" : "") }\t[INF]:{msg}");
            log_file.Flush();
#endif
        }
        public void RawLog(string msg)
        {
#if DEBUG
            log_file.WriteLine(msg);
            log_file.Flush();
#endif
        }
    }
}
