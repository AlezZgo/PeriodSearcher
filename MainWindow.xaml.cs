using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using PeriodSearch;

namespace Handler
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bit Files|*.bit";

            if (openFileDialog?.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                PathTextBox.Text = filePath;

                using (FileStream SourceStream = File.Open(filePath, FileMode.Open))
                {
                    byte[] result;  result = new byte[SourceStream.Length];
                    await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length);

                    PeriodSearcher periodSearcher = new PeriodSearcher(new BitArray(result));
                    if (periodSearcher.TryToFindPeriod(out IEnumerable<int> supposedPeriods))
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine("The most probable periods:");
                        foreach (var supposedPeriod in supposedPeriods)
                        {
                            stringBuilder.AppendLine(supposedPeriod.ToString());
                        }
                        MessageBox.Show(stringBuilder.ToString(),"Processing result");
                    }
                    else
                        MessageBox.Show("There is no period");
                }
            }
        }

    }
        
}
