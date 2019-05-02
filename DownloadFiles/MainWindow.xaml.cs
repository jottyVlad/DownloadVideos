using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using VideoLibrary;
using System.IO;

namespace DownloadFiles
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var service = Client.For(YouTube.Default))
            {
                var video = service.GetVideo(this.textBox.Text);
                string folder = "C:\\Users\\Maxim\\Desktop\\";
                string path = System.IO.Path.Combine(folder, video.FullName);
                File.WriteAllBytes(path, video.GetBytes());
            }
        }
    }
}
