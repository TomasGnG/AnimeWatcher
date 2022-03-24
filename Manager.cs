using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AnimeWatcher
{
    public class Manager
    {
        public Boolean userWebBrowserIsSet { get; set; }
        public String userWebBrowserPath { get; set; }
        public List<AnimeSeries> animeSeriesList { get; set; } = new List<AnimeSeries>();

        public Manager()
        {
            registerAllAnimesInFolder();
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
            if(userWebBrowserIsSet)
            {
                userWebBrowserPath = File.ReadAllText(filePath);
            }
        }

        private void registerAllAnimesInFolder()
        {
            var animeFolderPath = AppDomain.CurrentDomain.BaseDirectory + @"\animes\";

            AnimeSeries animeSeries;
            String[] fileLines;
            String animeName = "";
            Image animeImage = new Image();
            List<String> animeEpisodes = new List<String>();

            foreach (var fileInFolder in Directory.GetFiles(animeFolderPath))
            {
                fileLines = File.ReadAllLines(fileInFolder);
                
                animeName = fileLines[0].Substring("name".Length + 1);
                
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fileLines[1].Substring("image".Length + 1), UriKind.Absolute);
                bitmap.EndInit();
                animeImage.Source = bitmap;

                for (int i = 2; i < fileLines.Length; i++)
                {
                    animeEpisodes.Add(fileLines[i].Substring("1".Length + 1));
                }
            }

            animeSeries = new AnimeSeries(animeName, animeImage, animeEpisodes);
            animeSeriesList.Add(animeSeries);
        }
    }
}
