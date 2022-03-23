using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWatcher
{
    public class Manager
    {
        public Boolean userWebBrowserIsSet { get; set; }
        public String userWebBrowserPath { get; set; }

        public Manager()
        {
            var createFileName = "AppSettings.txt";
            var createFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + createFileName;
            userWebBrowserPath = File.ReadAllTextAsync(createFilePath).Result;
        }

        public void CreateFileIfNotExists(String pathFromUsersWebBrowser)
        {
            var createFileName = "AppSettings.txt";
            var createFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + createFileName;
            if(!File.Exists(createFilePath))
            {
                try
                {
                    using (var stream = File.Create(createFilePath))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(pathFromUsersWebBrowser);
                        stream.Write(info, 0, info.Length);
                    }
                    userWebBrowserPath = pathFromUsersWebBrowser;
                    userWebBrowserIsSet = true;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    throw;
                }
                return;
            }
            userWebBrowserIsSet = true;
            userWebBrowserPath = File.ReadAllTextAsync(createFilePath).Result;
        }

        public void SetAndCheckIfSettingsFileExist()
        {
            var fileName = "AppSettings.txt";
            var filePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + fileName;
            userWebBrowserIsSet = File.Exists(filePath);
        }
    }
}
