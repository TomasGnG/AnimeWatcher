using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimeWatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Manager manager;
        public MainWindow()
        {
            InitializeComponent();

            manager = new Manager();

            manager.SetAndCheckIfSettingsFileExist();
            ShowFileDialogIfBrowserIsNotSet();
            
            LoadAnimeComboBox();
        }

        private void LoadAnimeComboBox()
        {
            foreach (var item in manager.animeSeriesList)
            {
                animeComboBox.Items.Add(item.animeName);
            }
        }
        private void ShowFileDialogIfBrowserIsNotSet()
        {
            var projectName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
            if (!manager.userWebBrowserIsSet)
            {
                var openFileDialog = new OpenFileDialog();
                
                MessageBox.Show("Wähle deinen Browser aus! (.exe Datei)", projectName);
                do
                {
                    openFileDialog.ShowDialog();
                } while (openFileDialog.FileName == "" || !openFileDialog.FileName.EndsWith(".exe"));
                
                manager.CreateFileIfNotExists(openFileDialog.FileName);
            }
        }
        private void EditEverythingToAnimeSeries(String animeName)
        {
            foreach (var animeSeries in manager.animeSeriesList)
            {
                if(animeSeries.animeName == animeName)
                {
                    try
                    {
                        animePicturePreview.Source = animeSeries.animeImage.Source;
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                        throw;
                    }
                    
                    for (int i = 0; i < animeSeries.animeEpisodes.Count; i++)
                    {
                        episodeComboBox.Items.Add($"Folge {i+1}");
                    }
                }
            }

        }

        private void animeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditEverythingToAnimeSeries(animeComboBox.SelectedItem.ToString());
        }

        private void openEpisodeButton_Click(object sender, RoutedEventArgs e)
        {
            var url = "";
            foreach (var animeSeries in manager.animeSeriesList)
            {
                if (animeSeries.animeName == animeComboBox.SelectedValue.ToString())
                {
                    var episode = animeSeries.animeEpisodes[animeComboBox.SelectedIndex];
                    url = episode;

                    System.Diagnostics.Process.Start(manager.userWebBrowserPath, url);
                }
            }
        }
    }
}
