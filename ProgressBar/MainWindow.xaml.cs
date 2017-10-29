using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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


namespace ProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebClient webClient;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void DownloadFile(string urlAddresss,string location)
        {
            using(webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgresChanged);

                try
                {
                    webClient.DownloadFileAsync(new Uri(urlAddress.Text), location);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ProgresChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarDownload.Value = e.ProgressPercentage;
            labelPerc.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
           if(e.Cancelled)
            {
                MessageBox.Show("Pobieranie zostało przerwane","Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Pobieranie zakończone", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(urlAddress.Text))
            {
                DownloadFile(urlAddress.Text, Path.Combine(Directory.GetCurrentDirectory(), $"file.pdf"));
            }
        }
    

    }
}
