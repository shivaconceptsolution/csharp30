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
using System.Windows.Shapes;

namespace CommandExample
{
    /// <summary>
    /// Interaction logic for ExecuteDialog.xaml
    /// </summary>
    public partial class ExecuteDialog : Window
    {
        public ExecuteDialog()
        {
            InitializeComponent();
        }

        private void btnEnterName_Click(object sender, RoutedEventArgs e)
        {
            CustomDialogExample inputDialog = new CustomDialogExample("Please enter your name:", " ");
            if (inputDialog.ShowDialog() == true)
                lblName.Text = inputDialog.Answer;

        }
    }
}
