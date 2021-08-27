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

namespace Final_Project
{
    /// <summary>
    /// Interaction logic for MediaAboutPage.xaml
    /// </summary>
    public partial class MediaAboutPage : Window
    {
        public MediaAboutPage()
        {
            InitializeComponent();
        }

        private void hlGithub_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/zachstultz");
        }

        private void hlEmail_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("zach-stultz@student.kirkwood.edu");
            MessageBox.Show("Email copied to Clipboard.", "Email Copied");
        }
    }
}
