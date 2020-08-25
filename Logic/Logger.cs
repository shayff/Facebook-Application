using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Logic
{
    public sealed class Logger
    {
        private const bool v_WriteToNewLine = true;
        private static readonly object s_LockInstance = new object();
        private static readonly object s_LockWrite = new object();
        private static readonly string r_FileAddress = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Logs.txt";
        private static Logger s_Instance = null;

        private Logger()
        {
            using (StreamWriter streamWriter = new StreamWriter(r_FileAddress, v_WriteToNewLine))
            {
                streamWriter.WriteLine("### New session - At:" + DateTime.Now + " ###");
            }
        }

        public static Logger Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_LockInstance)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new Logger();
                        }
                    }
                }

                return s_Instance;
            }
        }

        public void WriteMessage(string i_Message)
        {
            lock (s_LockWrite)
            {
                using (StreamWriter streamWriter = new StreamWriter(r_FileAddress, true))
                {
                    streamWriter.WriteLine(DateTime.Now + ": " + i_Message);
                }
            }
        }
    }
}
