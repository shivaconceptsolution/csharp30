using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CommandExample
{
    /// <summary>
    /// Interaction logic for Openfileexample.xaml
    /// </summary>
    public partial class Openfileexample : Window
    {
        public Openfileexample()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
           
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                txtEditor.Text = File.ReadAllText(openFileDialog.FileName);

        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);

        }

        private void btnOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            using (var fbd = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void btnFont_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FontDialog fontDialog = new System.Windows.Forms.FontDialog();
          // fontDialog.Font = Font(txtEditor.FontFamily, txtEditor.FontSize);

            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var selectedFont = fontDialog.Font;
               txtEditor.FontSize = selectedFont.Size;
               txtEditor.FontFamily = new FontFamily(selectedFont.FontFamily.Name);
                //txtEditor.FontWeight = selectedFont.Bold ? "Bold" : "Regular";
                //txtEditor.FontStyle = selectedFont.Italic ? "Italic" : "Normal";
            }  
        }

        private void btnColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
            // fontDialog.Font = Font(txtEditor.FontFamily, txtEditor.FontSize);

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                //Color c = colorDialog.Color;
                 txtEditor.Background = new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B));
             //   txtEditor.Background = new SolidColorBrush(ColorConverter.ConvertFromString(colorDialog.Color.Name.ToString()));
                //txtEditor.FontFamily = new FontFamily(selectedFont.FontFamily.Name);
                //txtEditor.FontWeight = selectedFont.Bold ? "Bold" : "Regular";
                //txtEditor.FontStyle = selectedFont.Italic ? "Italic" : "Normal";
            }  
        }
    }
}
