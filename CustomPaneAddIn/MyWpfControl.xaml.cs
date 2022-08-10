using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomPaneAddIn
{
    /// <summary>
    /// Interaction logic for MyWpfControl.xaml
    /// </summary>
    public partial class MyWpfControl : UserControl
    {
        public MyWpfControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Text.Text = DateTime.Now.ToString();
        }
    }
}
