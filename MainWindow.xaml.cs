using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }


        private void ShowFileDialogIfBrowserIsNotSet()
        {
            Console.WriteLine(new Random().Next(1, 3));
            if (!manager.userWebBrowserIsSet)
            {
                var openFileDialog = new OpenFileDialog();
                MessageBox.Show("Wähle deinen Browser aus! (.exe Datei)");
                do
                {
                    openFileDialog.ShowDialog();
                } while (openFileDialog.FileName == "");
                
                manager.CreateFileIfNotExists(openFileDialog.FileName);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(manager.userWebBrowserPath, "https://voe.sx/9iuaz6uwjzr7/Ta%20Rascal%20Does%20Not%20Dream%20of%20Bunny%20Girl%20Senpai%2001%20Web%20720p%20AAC");
        }
    }
}
