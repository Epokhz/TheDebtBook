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

namespace TheDebtBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAddNew_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as WindowViewModel;
            vm.AddNewDebt();
            ListboxDebts.SelectedIndex = ListboxDebts.Items.Count - 1;
            tbxName.Focus();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as WindowViewModel;
            vm.DeleteDebt();
            ListboxDebts.SelectedIndex = ListboxDebts.Items.Count +1;
            tbxName.Focus();
        }

        private void BtnHistory_Click(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win2.Show();
        }



    }
}
