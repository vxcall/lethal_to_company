using System.IO;

namespace lethal_to_company
{
    public class debug_console
    {
#if DEBUG
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool AllocConsole();
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);
        private readonly StreamWriter _stdOutWriter;
        private readonly StreamReader _stdInReader;
#endif

        public debug_console()
        {
#if DEBUG
            AllocConsole();
            Stream stdout = System.Console.OpenStandardOutput();
            Stream stdin = System.Console.OpenStandardInput();
            _stdOutWriter = new StreamWriter(stdout);
            _stdInReader = new StreamReader(stdin);
            _stdOutWriter.AutoFlush = true;

            AttachConsole(-1);
#endif
        }

        public void release()
        {
#if DEBUG
            FreeConsole();
#endif
        }

        public string get_line()
        {
#if DEBUG
            return _stdInReader.ReadLine();
#endif
        }
        public void write_line(string line)
        {
#if DEBUG
            _stdOutWriter.WriteLine(line);
            System.Console.WriteLine(line);
#endif
        }

    }
}
