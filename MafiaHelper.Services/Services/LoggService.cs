using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaHelper.Services.Services
{
    public static class LoggService
    {
        public static void Log(Exception ex,string additionalInfo="")
        {
            File.AppendAllText("Log.txt",
                $"*******************************" + $"{Environment.NewLine}" +
                $"Time: {DateTime.Now} " + $"{Environment.NewLine}"+
                $"ExceptionMessage: {ex.Message}"+ $"{Environment.NewLine}" +
                $"Type: {ex.GetType().ToString()}" + $"{Environment.NewLine}" +
                $"StackTrace: {ex.StackTrace}" + $"{Environment.NewLine}" +
                $"AdditionalInfo: {additionalInfo}" + $"{Environment.NewLine}" +
                "********************************"
                );
        }
    }
}
