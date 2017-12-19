using System;
using System.IO;

namespace FinalFantasyDAL
{
    public class ErrorLog
    {
        public void Log(Exception ex, string methodName, string methodLayer, string level)
        {
            ErrorLog error = new ErrorLog();
            string errorLog = String.Format("{0}-{1}-{2}-{3}-{4}", DateTime.Now, level, methodLayer, methodName, ex.Message);
            Console.WriteLine(errorLog);
            StreamWriter writer = new StreamWriter(@"C:\Users\Scott Frye\Documents\FinalFantasyErrorLog.txt", true);
            writer.WriteLine(errorLog);
            writer.Close();
            writer.Dispose();
        }
    }
}
