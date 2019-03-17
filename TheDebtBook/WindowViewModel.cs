using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using TheDebtBook;


namespace TheDebtBook
{
    public class WindowViewModel : INotifyPropertyChanged
    {
        
        private ObservableCollection<Debt> debts;

        public WindowViewModel()
        {
            debts = new ObservableCollection<Debt>();
            debts.Add(new Debt("Mie Kryds Nielsen", "689 kr", DateTime.Now));
            debts.Add(new Debt("Viggo", "-100 kr", DateTime.Now));
        
        }

        #region Properties

   

        public ObservableCollection<Debt> Debts
        {
            get
            {
                return debts;
            }
        }

        #endregion

        #region Methods

        public void AddNewDebt(TextBox Name, TextBox Amount)
        {
            if (Name.Text == "dummy" && Amount.Text == "dummy")
            {
                for (int i = 0; i < 99; i++)
                {
                    Debts.Add(new Debt("Dummy", "Data", DateTime.MinValue));
                }
                return;
            }
            if (Name.Text != "" && Amount.Text != "")
            {
                
                Debts.Add(new Debt(Name.Text, Amount.Text + " kr", DateTime.Now));
                return;
            }
            else
            {
                MessageBox.Show("En (Eller flere!) af felterne var tomme Prøv igen!");
            }
            
           
        }

        public void DeleteDebt()
        {
            var index = ((MainWindow) Application.Current.MainWindow).ListboxDebts.SelectedIndex;
            Debts.RemoveAt(index);
        }


        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
