using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace Spice.CommanUtilities
{
    public static class Logger
    {
        public static void log(object message, string LogInDirectory)
        {
            var line = Environment.NewLine + Environment.NewLine;

            try
            {
                var fullFilePath = GenerateLogFile(LogInDirectory);
                StackTrace stackTrace = new StackTrace();

                // Get calling method name
                var logDetails = "Checkpoint : " + "/" + stackTrace.GetFrame(1).GetMethod().ReflectedType.Name + "/" + stackTrace.GetFrame(1).GetMethod().Name + line + "Details : " + JsonConvert.SerializeObject(message) + line;
                using (StreamWriter sw = File.AppendText(fullFilePath))
                {
                    sw.WriteLine("-----------Log Details on " + " " + DateTime.Now.ToString() + "-----------------");
                    sw.WriteLine("-------------------------------------------------------------------------------------");
                    sw.WriteLine(line);
                    sw.WriteLine(logDetails);
                    sw.WriteLine("--------------------------------*End*------------------------------------------");
                    sw.WriteLine(line);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        private static string GenerateLogFile(string LogDirectory)
        {
            string dev_status = Convert.ToString(ConfigurationManager.AppSettings["Server_Environment"]);

            string projectDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\")) + "Log";

            string server_directory = Environment.CurrentDirectory + "\\" + "Log";

            var baseLogPath = Path.Combine(dev_status == "DONE" ? server_directory : projectDirectory, LogDirectory);

            var dailyFolderPath = Path.Combine(baseLogPath, DateTime.Now.ToString("yyyyMMdd", CultureInfo.InvariantCulture));
            var fullFilePath = Path.Combine(dailyFolderPath, "LogFile_" + DateTime.Now.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + ".txt");

            if (!Directory.Exists(baseLogPath))
            {
                Directory.CreateDirectory(baseLogPath);
            }
            if (!Directory.Exists(dailyFolderPath))
            {
                Directory.CreateDirectory(dailyFolderPath);
            }
            if (!File.Exists(fullFilePath))
            {
                File.Create(fullFilePath).Dispose();
            }

            return fullFilePath;
        }

    }
}
