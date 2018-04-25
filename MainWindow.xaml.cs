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

namespace U3Readbyline
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.ShowDialog();
            // webclient 

            System.IO.StreamReader streamReader = new System.IO.StreamReader(openFileDialog.FileName);
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("somefile.txt");

            try
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    MessageBox.Show(line);
                    streamWriter.WriteLine(line);
                }
                streamWriter.Write(streamReader.ReadToEnd());
                streamWriter.Flush();
                streamWriter.Close();
                streamWriter.Close();
                MessageBox.Show("I Have read everything!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "Error");
            }
        }
    }
}

