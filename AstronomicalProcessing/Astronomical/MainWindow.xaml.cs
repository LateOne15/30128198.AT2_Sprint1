using System.CodeDom;
using System.ComponentModel;
using System.Diagnostics.Metrics;
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

// Lleyton Eggins, Sprint 1
// Date: 11/09/25
// Version: 0.8
// Astronomical Processing
// Creates and displays a list of simulated neutrino data,
// which can be sorted, searched and edited using textboxes and buttons

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

        private void SortList()
        {
            List<int> ints = new List<int>();
            foreach (int i in lbxDataList.Items)
            {
                ints.Add(i);
            }
            int iterations = ints.Count;
            for (int i = 0; i < iterations - 1; i++)
            {
                for (int j = 0; j < iterations - i - 1; j++)
                {
                    if (ints[j] > ints[j + 1])
                    {
                        int temp = ints[j + 1];
                        ints[j + 1] = ints[j];
                        ints[j] = temp;
                    }
                }
            }
            lbxDataList.Items.Clear();
            foreach (int i in ints)
            {
                lbxDataList.Items.Add(i);
            }

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

        private int BinarySearch(int x)
        {
            SortList();
            List<int> ints = new List<int>();
            foreach (int i in lbxDataList.Items)
            {
                ints.Add(i);
            }
            int min = 0, max = ints.Count - 1, mid;
            while (min <= max)
            {
                mid = (min + max) >> 1;
                if (ints[mid] == x)
                {
                    return mid;
                }

                if (ints[mid] < x)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }
            return -1;

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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = tbSearch.Text;
            if (int.TryParse(searchTerm, out int searchInt))
            {
                int success = BinarySearch(searchInt);
                if (success != -1)
                {
                    lbxDataList.SelectedItem = lbxDataList.Items.GetItemAt(success);
                    DisplayMessage("Match found!", "Found");
                }
                else
                {
                    DisplayError("No match found in list.", "Unsuccessful");
                }
            }
            else
            {
                DisplayError("Please enter a valid integer.", "Input Error");
            }
            tbSearch.Text = string.Empty;


            
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            SortList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            string temp = tbEdit.Text;
            if (int.TryParse(temp, out int value))
            {
                lbxDataList.Items.Insert(lbxDataList.SelectedIndex, value);
                lbxDataList.Items.Remove(lbxDataList.SelectedItem);
            }
            else
            {
                DisplayError("Please enter a valid integer.","Input Error");
            }
            tbEdit.Text = string.Empty;
        }
    }
}