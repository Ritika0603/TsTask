using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;

namespace TeamScale.logger
{
    public class loggerWorker
    {
        public static bool addLog(string message)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(ConfigurationManager.AppSettings["logfile"].ToString()))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.WriteLine("-------------------------------------------------------------");
                    streamWriter.WriteLine("-------------------------------------------------------------");
                    streamWriter.Close();
                }
                return true;
            }
            catch(Exception ob)
            {
                return false;
            }
            
        }
    }
}