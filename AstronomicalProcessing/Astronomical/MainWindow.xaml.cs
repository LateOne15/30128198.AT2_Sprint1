using System.ComponentModel;
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

            // Search directly through C# implementations instead of Binary Seach
            //int temp = int.Parse(tbSearch.Text);
            //bool found = lbxDataList.Items.Contains(temp);
            //if (found)
            //{
            //    lbxDataList.SelectedItem=temp;
            //    DisplayMessage("Match found!", "Found");
            //}
            //else
            //{
            //    DisplayError("No match found in list.", "Unsuccessful");
            //}
            //tbSearch.Text = string.Empty;
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {


            // Sort directly through C# implementations instead of Bubble Sort
            //List<int> ints = new List<int>();
            //foreach (int i in lbxDataList.Items)
            //{
            //    ints.Add(i);
            //}
            //ints.Sort();
            //lbxDataList.Items.Clear();
            //foreach (int i in ints)
            //{
            //    lbxDataList.Items.Add(i);
            //}
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int temp = int.Parse(tbEdit.Text);
            lbxDataList.Items.Insert(lbxDataList.SelectedIndex, temp);
            lbxDataList.Items.Remove(lbxDataList.SelectedItem);
            tbEdit.Text=string.Empty;
        }
    }
}