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
            debts.Add(new Debt("Mie Kryds Nielsen", 689 , DateTime.Now));
            debts.Add(new Debt("Viggo", -100, DateTime.Now));
        }

        public ObservableCollection<Debt> Debts
        {
            get
            {
                return debts;
            }
        }

        public void AddNewDebt(TextBox Name, TextBox Amount)
        {
            if (Name.Text == "dummy" && Amount.Text == "000")
            {
                for (int i = 0; i < 99; i++)
                {
                    Debts.Add(new Debt("Dummy Data " + i, 00, DateTime.MinValue));
                }
                return;
            }
            if (Name.Text != "" && Amount.Text.Length != 0)
            {
                if ( -1 != findName(Name.Text)) // Hvis navnet er der.
                {
                    double add_val;
                    Debts[findName(Name.Text)].Sum += double.TryParse(Amount.Text, out add_val) ? add_val : Double.NaN;
                    Debts[findName(Name.Text)].addToHistory(add_val);
                    return;
                }
                double val;
                Debts.Add(new Debt(Name.Text, (double.TryParse(Amount.Text, out val) ? val : Double.NaN), DateTime.Now));
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

        public int findName(string name) // Tjekker om "name" er i debts, hvis det er retuneres indexet ,hvis det ikke er i debts retuneres -1
        {
            for (int i = 0; i <= (debts.Count-1) ; i++)
            {
                if (Debts[i].Name == name)
                {
                    return i;
                }
          
            }

            return -1;
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
