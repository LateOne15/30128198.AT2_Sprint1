using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Astronomical
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            int[] ints = new int[24];
            Random rnd = new Random();
            for (int i = 0; i < 24; i++)
            {
                ints[i] = rnd.Next(10,91);
            }
            foreach(int i in ints)
            {
                lbxDataList.Items.Add(i);
            }
        }

        #region Messages
        private void DisplayMessage(string msg, string caption)
        {
            MessageBox.Show(msg, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DisplayError(string msg, string caption)
        {
            MessageBox.Show(msg, caption, MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        //private void DisplayStatus(string msg)
        //{
        //    txtStatus.Text = msg;
        //}
        #endregion

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            lbxDataList.SelectedItem = tbEdit.Text;
            tbEdit.Text= string.Empty;
        }
    }
}