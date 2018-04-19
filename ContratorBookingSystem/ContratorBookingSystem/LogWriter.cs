using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ContratorBookingSystem
{
    public class  LogWriter
    {
      static object obj = new object();
      public static void Write(string message, string file = "EVENT_LOG")
        {
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),file + ".txt"),true))
                {
                    writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " ---- " + message);
                }
            }
        }
        public static void Write(Exception ex)
        {
            Write("Exception ---" + ex.Message + ex.StackTrace + "----" + ex.Source + "---" + ex.InnerException);
        }
    }
}
