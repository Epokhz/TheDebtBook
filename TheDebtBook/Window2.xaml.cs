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

namespace TheDebtBook
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
   
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            FindingTarget();
            
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void FindingTarget()
        {
            var selected = ((MainWindow)Application.Current.MainWindow).ListboxDebts.SelectedIndex;
            var vm = DataContext as WindowViewModel;


            var name = vm.Debts[selected].Name;
            labelName.Content = name;
            
            

            
        }
    }
}
